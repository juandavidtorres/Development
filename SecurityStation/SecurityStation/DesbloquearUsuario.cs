using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using System.Web.Security;

namespace SecurityStation
{
    public partial class DesbloquearUsuario : UserControl
    {
        public event EventHandler EventoCerrar;
        private Helper oHelper = new Helper();
        private Properties.Settings settings = new Properties.Settings();

        public DesbloquearUsuario()
        {
            InitializeComponent();
        }

        private void mnuGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbUsuario.Text))
                {
                    MembershipUser usuario = Membership.GetUser(cmbUsuario.Text);
                    usuario.UnlockUser();
                    this.popup.ContentText = "Operacion realizada exitosamente";
                    this.popup.Popup();
                }
                else
                    throw new Exception("No hay un usuario Disponible");
                

            }
            catch (Exception ex)
            {
                
                this.popup.ContentText = ex.Message.ToString();
                this.popup.Popup();
            }
        }

        private void DesbloquearUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                this.cmbUsuario.DisplayMember = "UserName";
                this.cmbUsuario.ValueMember = "UserId";
                this.cmbUsuario.DataSource = oHelper.RecuperarUsuariosxAplicacion(settings.ApplicationMembership);                
            }
            catch (Exception ex)
            {

                this.popup.ContentText = ex.Message.ToString();
                this.popup.Popup();
            }
        }

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //this.Dispose();
            EventoCerrar(sender, e);
        }
    }
}
