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
    public partial class Usuario : UserControl
    {
        public event EventHandler EventoCerrar;

        public Usuario()
        {
            InitializeComponent();
        }

        public void IniciarForma()
        {
            try
            {
                DatosIniciales();

                CargarUsuarios();

            }
            catch (Exception ex)
            {
                this.PopUp.ContentText = ex.Message.ToString();
                this.PopUp.Popup();
            }
        }

        private void CargarUsuarios()
        {
            Helper oHelper = new Helper();
            Properties.Settings settings = new Properties.Settings();
            this.dgrUsuarios.DataSource = oHelper.RecuperarUsuariosxAplicacion(settings.ApplicationMembership);
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
                //if (!Validations())
                //{
                //    this.PopUp.ContentText = "Debe registrar todos los campos";
                //    this.PopUp.Popup();
                //}
                //else
                //{
                try
                {
                    Validations();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                Membership.CreateUser(this.txtNombreUsuario.Text.Trim().ToString(), this.txtContrasena.Text.Trim().ToString());

                DatosIniciales();

                CargarUsuarios();

                this.PopUp.ContentText = "Usuario Creado correctamente";
                this.PopUp.Popup();
                //}                   

            }
            catch (Exception ex)
            {
                this.PopUp.ContentText = ex.Message.ToString();
                this.PopUp.Popup();
            }
        }

        private void DatosIniciales()
        {
            this.txtContrasena.Text = string.Empty;
            this.txtNombreUsuario.Text = string.Empty;
            this.txtConfirmarContrasena.Text = string.Empty;
            this.txtNombreUsuario.Focus();
        }

        private void mnuNuevo_Click(object sender, EventArgs e)
        {
            DatosIniciales();
        }

        private void Validations()
        {
            
                this.errorProvider1.Clear();

                if (string.IsNullOrEmpty(this.txtNombreUsuario.Text))
                {
                   // this.errorProvider1.SetError(this.txtNombreUsuario, "El Nombre de usuario es obligatorio");
                   
                    throw new Exception("El Nombre de usuario es obligatorio");
                }

                if (string.IsNullOrEmpty(this.txtContrasena.Text))
                {
                    //this.errorProvider1.SetError(this.txtContrasena, "La contraseña es obligatoria");
                                   
                    throw new Exception("La contraseña es obligatoria");
                }

                if (this.txtConfirmarContrasena.Text != this.txtContrasena.Text)
                {
                    //this.errorProvider1.SetError(this.txtConfirmarContrasena, "Las contraseñas no son iguales");
                    
                    throw new Exception("Las contraseñas no son iguales");
                }
            
           
            
        }

       
    }
}
