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
    public partial class UsuarioRole : UserControl
    {
        public event EventHandler EventoCerrar;
        private Helper oHelper = new Helper();
        private Properties.Settings settings = new Properties.Settings();

        public UsuarioRole()
        {
            InitializeComponent();
        }

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //this.Dispose();
            EventoCerrar(sender, e);
        }

        #region Methods

        private void CargarUsuarios()
        {
            try
            {
                this.cmbUsuario.DisplayMember = "UserName";
                this.cmbUsuario.ValueMember = "UserId";
                this.cmbUsuario.DataSource = oHelper.RecuperarUsuariosxAplicacion(settings.ApplicationMembership);
            }
            catch (Exception ex)
            {
                this.popupNotifier1.ContentText = ex.Message.ToString();
                this.popupNotifier1.Popup();
            }
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
                this.popupNotifier1.ContentText = ex.Message.ToString();
                this.popupNotifier1.Popup();
            }
        }

        private void CargarUsuariosxRole()
        {
            try
            {
                DataTable tableUsuariosxRole;
                tableUsuariosxRole = oHelper.RecuperarUsuariosporRole(this.cmbRole.Text, settings.ApplicationMembership);
                this.dgrUsuariosxRole.DataSource = tableUsuariosxRole;
            }
            catch (Exception ex)
            {
                Notificacion(ex.Message.ToString());
            }
        }

        public void CargarDatosIniciales()
        {
            CargarRoles();
            CargarUsuarios();
        }

        #endregion

        private void mnuNuevo_Click(object sender, EventArgs e)
        {
            CargarDatosIniciales();
        }

        private void mnuGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validations())
                {
                    Notificacion("Se presentaron errores al asignar el usuario al grupo seleccionado");

                }
                else
                {
                    if (Roles.IsUserInRole(this.cmbUsuario.Text, this.cmbRole.Text))
                    {
                        Notificacion("Este usuario ya se encuentra en el grupo seleccionado");
                    }
                    else
                    {
                        string[] usuarios;
                        usuarios = new string[1];
                        usuarios[0] = this.cmbUsuario.Text;
                        Roles.AddUsersToRole(usuarios, this.cmbRole.Text);
                        Notificacion("Usuario asignado al grupo correctamente");
                        CargarUsuariosxRole();
                    }
                }
            }
            catch (Exception ex)
            {
                Notificacion(ex.Message.ToString());
            }
        }

        private void Notificacion(string TextoNotificacion)
        {
            this.popupNotifier1.ContentText = TextoNotificacion;
            this.popupNotifier1.Popup();
        }

        private bool Validations()
        {
            bool Validado = true;

            this.errorProvider1.Clear();

            if (this.cmbUsuario.Text == "")
            {
                this.errorProvider1.SetError(this.cmbUsuario, "Debe seleccionar el usuario");
                Validado = false;
                return false;
            }

            if (this.cmbRole.Text == "")
            {
                this.errorProvider1.SetError(this.cmbRole, "Debe seleccionar el Grupo");
                Validado = false;
                return false;
            }

            return Validado;

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //cargar usuarios del grupo seleccionado
                CargarUsuariosxRole();
            }
            catch (Exception ex)
            {
                Notificacion(ex.Message.ToString());
            }
        }

        private void dgrUsuariosxRole_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (e.Row.Index != -1)
                {
                    if (!string.IsNullOrEmpty(this.dgrUsuariosxRole.Rows[e.Row.Index].Cells["UserName"].Value.ToString()))
                    {
                        if (MessageBox.Show("¿Desea desasociar el usuario que se encuentra en la posición #" + (e.Row.Index + 1) + "?", "FullStation®",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                             MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            String usuario = this.dgrUsuariosxRole.Rows[e.Row.Index].Cells["UserName"].Value.ToString();
                            Roles.RemoveUserFromRole(usuario, cmbRole.Text);
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
