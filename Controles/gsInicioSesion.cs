using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using POSstation.Fabrica;
using System.Web.Security;

namespace Controles
{
    public partial class gsInicioSesion : UserControl
    {
        #region EVENTOS
        public delegate void EventoCierreFormulario();
        public event EventoCierreFormulario EventoCerrarFormulario;

        public delegate void EventoAutenticacionExitosa(Guid UserId);
        public event EventoAutenticacionExitosa EventoAutenticacionApropada;
        #endregion

        Helper oHelper = new Helper();

        public gsInicioSesion()
        {
            InitializeComponent();
        }

        private void btnLogearse_Click(object sender, EventArgs e)
        {
            ValidarUsuario();
        }

        private void ValidarUsuario()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtDocumento.Text.Trim()))
                {
                    if (!string.IsNullOrEmpty(txtClave.Text.Trim()))
                    {
                        if (Membership.ValidateUser(txtDocumento.Text, txtClave.Text))
                        {
                            Guid UserId = oHelper.ValidarUsuarioASPNet(txtDocumento.Text);
                            EventoAutenticacionApropada(UserId);
                            EventoCerrarFormulario();
                        }
                        else
                        {
                            MessageBox.Show("El usuario o la contraseña no son validos", "GASOLUTION SAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAUCE COL.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarControles();
            }
        }

        private void LimpiarControles() 
        {
            txtClave.Clear();
            txtDocumento.Clear();        
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EventoCerrarFormulario();
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                ValidarUsuario();
            }
        }

        private void pbImagenLogin_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
