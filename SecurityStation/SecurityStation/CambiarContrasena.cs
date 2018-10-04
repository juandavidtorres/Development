using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Web.Security;
using POSstation.Fabrica;
using POSstation.AccesoDatos;


namespace SecurityStation
{
    public partial class CambiarContrasena : UserControl
    {
        public event EventHandler EventoCerrar;

        public CambiarContrasena()
        {
            InitializeComponent();
        }

        public void IniciarForma()
        {
            try
            {
                Helper oHelper = new Helper();
                Properties.Settings settings = new Properties.Settings();
                DataTable tableUsuarios = oHelper.RecuperarUsuariosxAplicacion("FullStation");

                this.cmbUsuarios.DisplayMember = "UserName";
                this.cmbUsuarios.ValueMember = "UserId";
                this.cmbUsuarios.DataSource = tableUsuarios;

                this.cmbUsuarios.SelectedIndex = -1;
                this.txtConfirmarContrasena.Text = string.Empty;
                this.txtContrasena.Text = string.Empty;
                this.cmbUsuarios.Focus();
            }
            catch (Exception ex)
            {
                this.popupNotifier1.ContentText = ex.Message.ToString();
                this.popupNotifier1.Popup();
            }
        }

        //private bool Validations()
        //{
        //    bool Validado = true;

        //    this.errorProvider1.Clear();

        //    if (string.IsNullOrEmpty(this.txtContrasena.Text))
        //    {
        //        this.errorProvider1.SetError(this.txtContrasena, "La Contraseña es obligatoria");
        //        Validado = false;
        //        return false;
        //    }

        //    if (string.IsNullOrEmpty(this.txtConfirmarContrasena.Text))
        //    {
        //        this.errorProvider1.SetError(this.txtConfirmarContrasena, "Debe confirmar la contraseña");
        //        Validado = false;
        //        return false;
                
        //    }

        //    if (this.txtContrasena.Text.ToString() != this.txtConfirmarContrasena.Text.ToString())
        //    {
        //        this.errorProvider1.SetError(this.txtConfirmarContrasena, "Las contraseñas no son iguales");
        //        Validado = false;
        //        return false;
        //    }

        //    if (this.cmbUsuarios.Text == "")
        //    {
        //        this.errorProvider1.SetError(this.cmbUsuarios, "Debe seleccionar el usuario");
        //        Validado = false;
        //        return false;
        //    }

        //    return Validado;

        //}

        private void Notificacion(string Texto)
        {
            this.popupNotifier1.ContentText = Texto;
            this.popupNotifier1.Popup();
        }
        
        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //this.Dispose();
            EventoCerrar(sender, e);
        }

        private void mnuGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Validations();         
                string oldContrasena = Membership.GetUser(this.cmbUsuarios.Text).ResetPassword();
                Membership.GetUser(this.cmbUsuarios.Text).ChangePassword(oldContrasena, this.txtConfirmarContrasena.Text);
                Notificacion("La contraseña ha sido cambiada con exito al usuario " + this.cmbUsuarios.Text);
                txtContrasena.Text = "";
                txtConfirmarContrasena.Text = "";
                
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("La longitud del parámetro 'newPassword' tiene que ser mayor que o igual "))
                {
                    Notificacion("La longitud de la nueva contraseña debe ser mayor a 4");
                }
                else
                {
                    Notificacion(ex.Message.ToString());
                }
            }
        }

        private void mnuNuevo_Click(object sender, EventArgs e)
        {
            this.cmbUsuarios.SelectedIndex = -1;
            this.txtConfirmarContrasena.Text = string.Empty;
            this.txtContrasena.Text = string.Empty;
            this.cmbUsuarios.Focus();
        }

        private void Validations()
        {           
            try
            {

                this.errorProvider1.Clear();

                if (string.IsNullOrEmpty(this.txtContrasena.Text))
                {
                   throw new Exception("La Contraseña es obligatoria");                         
                }

                if (string.IsNullOrEmpty(this.txtConfirmarContrasena.Text))
                {
                    throw new Exception("Debe confirmar la contraseña");       
                }

                if (this.txtContrasena.Text.ToString() != this.txtConfirmarContrasena.Text.ToString())
                {
                    throw new Exception("Las contraseñas no son iguales");                      
                }

                if (this.cmbUsuarios.Text == "")
                {
                    throw new Exception("Debe seleccionar el usuario");                 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           

        }
    }
}
