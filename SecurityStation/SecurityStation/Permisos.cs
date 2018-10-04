using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.Fabrica;
using POSstation.AccesoDatos;
using System.Web.Security;

namespace SecurityStation
{
    public partial class Permisos : UserControl
    {
        public event EventHandler EventoCerrar;
        private Helper oHelper = new Helper();
        private Properties.Settings settings = new Properties.Settings();

        public Permisos()
        {
            InitializeComponent();
        }

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //this.Dispose();
            EventoCerrar(sender, e);
        }

        public void CargarDatosIniciales()
        {
            CargarRoles();
        }

        private void CargarRoles()
        {
            try
            {
                this.cmbRole.DisplayMember = "RoleName";
                this.cmbRole.ValueMember = "RoleId";
                this.cmbRole.DataSource = oHelper.RecuperarRolesxAplicacion(settings.ApplicationMembership);
            }
            catch (Exception ex)
            {
                this.PopUp.ContentText = ex.Message.ToString();
                this.PopUp.Popup();
            }
        }

        private void Notificacion(string TextoNotificacion)
        {
            this.PopUp.ContentText = TextoNotificacion;
            this.PopUp.Popup();
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //cargar permisos por grupo seleccionado
                CargarPermisosPorRole();
            }
            catch (Exception ex)
            {
                Notificacion(ex.Message.ToString());
            }
        }

        private void CargarPermisosPorRole()
        {
            try
            {
                DataTable tablePermisosxRole;
                tablePermisosxRole = oHelper.RecuperarAccionesPorRole(this.cmbRole.Text);
                this.grdPermisos.DataSource = tablePermisosxRole;
            }
            catch (Exception ex)
            {
                Notificacion(ex.Message.ToString());
            }
        }

        private void grdPermisos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (grdPermisos.Columns[e.ColumnIndex].Name.Equals("Valor"))
                    {
                        Int32 IdAccion = Int32.Parse(grdPermisos.Rows[e.RowIndex].Cells["IdAccion"].Value.ToString());
                        Guid IdRole = (Guid)grdPermisos.Rows[e.RowIndex].Cells["IdRole"].Value;
                        Boolean EsPermitido = Boolean.Parse(grdPermisos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                        oHelper.ActualizarPermisosPorAccion(IdAccion, IdRole, EsPermitido);
                    }
                }
            }
            catch (Exception ex)
            {
                Notificacion(ex.Message.ToString());
            }
        }

        private void chkTodas_Click(object sender, EventArgs e)
        {
             try 
             {
                 Int32 IdAccion = 0;
                 Guid IdRole;
                 Boolean EsPermitido = false;

                 for (int i = 0; i < grdPermisos.Rows.Count;i++ ) {
                     IdAccion = Int32.Parse(grdPermisos.Rows[i].Cells["IdAccion"].Value.ToString());
                     IdRole = (Guid)grdPermisos.Rows[i].Cells["IdRole"].Value;
                     EsPermitido = Boolean.Parse(grdPermisos.Rows[i].Cells["Valor"].Value.ToString());


                     if (chkTodas.Checked && !EsPermitido)
                     {
                         oHelper.ActualizarPermisosPorAccion(IdAccion, IdRole, chkTodas.Checked);
                     }
                     else if (!chkTodas.Checked && EsPermitido)
                     {
                         oHelper.ActualizarPermisosPorAccion(IdAccion, IdRole, chkTodas.Checked);
                     }
                 
                 }
                 CargarPermisosPorRole();
                 
             }
             catch (Exception ex)
             {
                 Notificacion(ex.Message.ToString());
             }
           
      
        }
    }
}
