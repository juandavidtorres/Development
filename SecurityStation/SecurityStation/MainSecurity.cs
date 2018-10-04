using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Web.Security;
using POSstation.Fabrica;
using POSstation.AccesoDatos;
namespace SecurityStation
{
    public partial class MainSecurity : Form
    {
        Helper oHelper = new Helper();
        bool ucRoleActivo;
        bool ucUsuarioActivo;
        bool ucRoleUsuarioAcivo;
        bool ucCambiarContrasena;
        bool ucPermisos;
        bool ucDesbloequo;

        Role oRole = new Role();
        Usuario oUsuario = new Usuario();
        UsuarioRole oUsuarioRole = new UsuarioRole();
        CambiarContrasena oCambiarContraseña = new CambiarContrasena();
        Permisos oPermisos = new Permisos();
        DesbloquearUsuario oDesbloqueo = new DesbloquearUsuario();

        List<Control> arrayUserControls = new List<Control>();


        public MainSecurity()
        {
            InitializeComponent();
        }

        private void MainSecurity_Load(object sender, EventArgs e)
        {
            try
            {
                //Verifico que esté conectada la llave HASP
           //     gasolutionsHasp.IsHasp();

                if (!Seguridad.EsAdministradorEds())
                {
                    MessageBox.Show("El usuario no tiene permisos para ejecutar esta aplicación", Application.ExecutablePath, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

               // RecuperarDatosBasicos(oHelper);

                oRole.Visible = false;
                oRole.EventoCerrar += new EventHandler(this.Roles_Cerrar);
                this.pnlPrincipal.Controls.Add(oRole);

                oUsuario.Visible = false;
                oUsuario.EventoCerrar += new EventHandler(this.Usuario_Cerrar);
                this.pnlPrincipal.Controls.Add(oUsuario);

                oUsuarioRole.Visible = false;
                oUsuarioRole.EventoCerrar += new EventHandler(this.RoleUsuario_Cerrar);
                this.pnlPrincipal.Controls.Add(oUsuarioRole);

                oCambiarContraseña.Visible = false;
                oCambiarContraseña.EventoCerrar += new EventHandler(this.CambiarContrasena_Cerrar);
                this.pnlPrincipal.Controls.Add(oCambiarContraseña);

                oPermisos.Visible = false;
                oPermisos.EventoCerrar += new EventHandler(this.Permisos_Cerrar);
                this.pnlPrincipal.Controls.Add(oPermisos);

                oDesbloqueo.Visible = true;
                oDesbloqueo.EventoCerrar += new EventHandler(this.Bloqueo_Cerrar);
                this.pnlPrincipal.Controls.Add(oDesbloqueo);
            }
            catch (GasolutionsHaspException ex)
            {
                MessageBox.Show(SecurityStation.Properties.Resources.LlaveHaspNoEncontrada, Application.ExecutablePath, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {
               

                if (ex.Message.Contains("Error en la relación de confianza entre la estación de trabajo y el dominio principal"))
                {
                    MessageBox.Show("Revise que el usuario tenga los permisos correspondientes, remitirse al manual de usuario de la aplicacion para verificar las condiciones necesarias para ejecutar el modulo de seguridad", Application.ExecutablePath, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
                else
                    MessageBox.Show(ex.Message, Application.ExecutablePath, MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }

        #region Methods

        //private void RecuperarDatosBasicos(Helper oHelper)
        //{
        //    try
        //    {
        //        InformacionEstacion oEstacion = oHelper.RecuperarDatosEstacion();

        //        this.datosGenerales1.Codigo = oEstacion.Codigo;
        //        this.datosGenerales1.Nombre = oEstacion.Nombre;
        //        this.datosGenerales1.Nit = oEstacion.Nit;
        //        this.datosGenerales1.Direccion = oEstacion.Direccion;
        //        this.datosGenerales1.Telefono = oEstacion.Telefono;
        //        this.datosGenerales1.Ciudad = oEstacion.Ciudad;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private void ControlVisibleenPantalla()
        {
            Int16 Max = Int16.Parse((arrayUserControls.Count - 1).ToString());

            for (Int16 i = 0; i <= Max; ++i)
            {
                if (Max == i)
                {
                    arrayUserControls[i].Visible = true;
                }
                else
                {
                    arrayUserControls[i].Visible = false;
                }

            }
        }

        private void Roles_Cerrar(object sender, EventArgs e)
        {
            ucRoleActivo = false;
            arrayUserControls.Remove(oRole);
            ControlVisibleenPantalla();
        }

        private void Usuario_Cerrar(object sender, EventArgs e)
        {
            ucUsuarioActivo = false;
            arrayUserControls.Remove(oUsuario);
            ControlVisibleenPantalla();
        }

        private void RoleUsuario_Cerrar(object sender, EventArgs e)
        {
            ucRoleUsuarioAcivo = false;
            arrayUserControls.Remove(oUsuarioRole);
            ControlVisibleenPantalla();
        }

        private void CambiarContrasena_Cerrar(object sender, EventArgs e)
        {
            ucCambiarContrasena = false;
            arrayUserControls.Remove(oCambiarContraseña);
            ControlVisibleenPantalla();
        }

        private void Permisos_Cerrar(object sender, EventArgs e)
        {
            ucPermisos = false;
            arrayUserControls.Remove(oPermisos);
            ControlVisibleenPantalla();
        }

        private void Bloqueo_Cerrar(object sender, EventArgs e)
        {
            ucDesbloequo = false;
            arrayUserControls.Remove(oDesbloqueo);
            ControlVisibleenPantalla();
        }
        #endregion


        private void securityStationColombia1_RolesEvent(object sender, EventArgs e)
        {
            try
            {
                if (ucRoleActivo == false)
                {
                    arrayUserControls.Add(oRole);
                    ControlVisibleenPantalla();
                    oRole.IniciarForma();
                    ucRoleActivo = true;

                    ucUsuarioActivo = false;
                    ucRoleUsuarioAcivo = false;
                    ucCambiarContrasena = false;
                    ucPermisos = false;
                }

            }
            catch (Exception ex)
            {
                this.Popup.ContentText = ex.Message.ToString();
                this.Popup.Popup();
            }
        }

        private void securityStationColombia1_UsuarioEvent(object sender, EventArgs e)
        {
            try
            {
                if (ucUsuarioActivo == false)
                {
                    arrayUserControls.Add(oUsuario);
                    ControlVisibleenPantalla();
                    oUsuario.IniciarForma();
                    ucUsuarioActivo = true;

                    ucRoleActivo = false;
                    ucRoleUsuarioAcivo = false;
                    ucCambiarContrasena = false;
                    ucPermisos = false;
                }

            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void securityStationColombia1_RolesUsuarioEvent(object sender, EventArgs e)
        {
            try
            {
                if (ucRoleUsuarioAcivo == false)
                {
                    arrayUserControls.Add(oUsuarioRole);
                    ControlVisibleenPantalla();
                    oUsuarioRole.CargarDatosIniciales();
                    ucRoleUsuarioAcivo = true;

                    ucRoleActivo = false;
                    ucUsuarioActivo = false;
                    ucCambiarContrasena = false;
                    ucPermisos = false;

                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void securityStationColombia1_CambiarEvent(object sender, EventArgs e)
        {
            try
            {
                if (ucCambiarContrasena == false)
                {
                    arrayUserControls.Add(oCambiarContraseña);
                    ControlVisibleenPantalla();
                    oCambiarContraseña.IniciarForma();
                    ucCambiarContrasena = true;

                    ucRoleActivo = false;
                    ucRoleUsuarioAcivo = false;
                    ucUsuarioActivo = false;
                    ucPermisos = false;
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void securityStationColombia1_PermisosEvent(object sender, EventArgs e)
        {
            try
            {
                if (ucPermisos == false)
                {
                    arrayUserControls.Add(oPermisos);
                    ControlVisibleenPantalla();
                    oPermisos.CargarDatosIniciales();
                    ucPermisos = true;

                    ucRoleActivo = false;
                    ucRoleUsuarioAcivo = false;
                    ucUsuarioActivo = false;
                    ucCambiarContrasena = false;
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void securityStationColombia1_DesbloquearEvent(object sender, EventArgs e)
        {
            try
            {
                if (ucDesbloequo == false)
                {
                    arrayUserControls.Add(oDesbloqueo);
                    ControlVisibleenPantalla();

                    ucDesbloequo = true;

                    ucRoleActivo = false;
                    ucRoleUsuarioAcivo = false;
                    ucUsuarioActivo = false;
                    ucPermisos = false;
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void securityStationColombia1_SalirEvent(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿ Desea cerrar la aplicación Security Station ?", "Security Station",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.Close();
                    this.Dispose();
                    Application.Exit();
                }
            }
            catch (InvalidOperationException)
            {
                Popup.ContentText = "\t\t\tData Administrador\n\nEl formulario se ha cerrado mientras se creaba un identificador.";
                Popup.Popup();
            }
        }
    }
}
