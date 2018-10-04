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
    public partial class Role : UserControl
    {
        public event EventHandler EventoCerrar;

        public Role()
        {
            InitializeComponent();
        }

        public void IniciarForma()
        {
            try
            {
                CargarRoles();
            }
            catch (Exception ex)
            {
                this.popupNotifier1.ContentText = ex.Message.ToString();
                this.popupNotifier1.Popup();
            }
        }

        private void CargarRoles()
        {
            System.Data.DataTable oTableRoles;
            Helper oHelper = new Helper();
            oTableRoles = oHelper.RecuperarRolesxAplicacion("fullstation");
            this.drgRoles.DataSource = oTableRoles;
        }

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //this.Dispose();
            EventoCerrar(sender, e);
        }


        private void mnuNuevo_Click(object sender, EventArgs e)
        {
            this.txtNombreRol.Text = string.Empty;
            this.txtNombreRol.Focus();
        }

        private void mnuGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validations())
                {
                    Notificacion("Debe registrar todos los campos");
                }
                else
                {
                    if (Roles.RoleExists(this.txtNombreRol.Text))
                    {
                        Notificacion("Este nombre de grupo de usuarios ya se encuentra registrado");
                    }
                    else
                    {
                        Roles.CreateRole(this.txtNombreRol.Text);
                        CargarRoles();
                        this.txtNombreRol.Text = string.Empty;
                        this.txtNombreRol.Focus();
                        Notificacion("Grupo de usuario creado exitosamente");
                    }

                }
            }
            catch (Exception ex)
            {
                this.popupNotifier1.ContentText = ex.Message.ToString();
                this.popupNotifier1.Popup();
            }
        }

        private void Notificacion(string Texto)
        {
            this.popupNotifier1.ContentText = Texto;
            this.popupNotifier1.Popup();
        }


        private bool Validations()
        {
            bool Validado = true;

            this.errorProvider1.Clear();

            if (string.IsNullOrEmpty(this.txtNombreRol.Text))
            {
                this.errorProvider1.SetError(this.txtNombreRol, "El Nombre del rol es obligatorio");
                Validado = false;
            }

            return Validado;

        }

        private void drgRoles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

    }
}
