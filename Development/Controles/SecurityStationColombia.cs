using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Controles
{
    public partial class SecurityStationColombia : UserControl
    {
        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler RolesEvent;
        public event EventHandler UsuarioEvent;
        public event EventHandler RolesUsuarioEvent;
        public event EventHandler CambiarEvent;
        public event EventHandler PermisosEvent;
        public event EventHandler DesbloquearEvent;
        public event EventHandler SalirEvent;

        public SecurityStationColombia()
        {
            InitializeComponent();
        }

        public bool Roles
        {
            get { return btnRoles.Enabled; }
            set { btnRoles.Enabled = value; }
        }

        public bool Usuario
        {
            get { return btnUsuario.Enabled; }
            set { btnUsuario.Enabled = value; }
        }

        public bool RolesUsuario
        {
            get { return btnRolesUsuario.Enabled; }
            set { btnRolesUsuario.Enabled = value; }
        }

        public bool Cambiar
        {
            get { return btnCambiar.Enabled; }
            set { btnCambiar.Enabled = value; }
        }

        public bool Permisos
        {
            get { return btnPermisos.Enabled; }
            set { btnPermisos.Enabled = value; }
        }

        public bool Desbloquear
        {
            get { return btnDesbloquear.Enabled; }
            set { btnDesbloquear.Enabled = value; }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (SalirEvent != null)
            {
                SalirEvent(sender, e);
            }
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            if (UsuarioEvent != null)
            {
                UsuarioEvent(sender, e);
            }
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            if (RolesEvent != null)
            {
                RolesEvent(sender, e);
            }
        }

        private void btnRolesUsuario_Click(object sender, EventArgs e)
        {
            if (RolesUsuarioEvent != null)
            {
                RolesUsuarioEvent(sender, e);
            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (CambiarEvent!= null)
            {
                CambiarEvent(sender, e);
            }
        }

        private void btnPermisos_Click(object sender, EventArgs e)
        {
            if (PermisosEvent != null)
            {
                PermisosEvent(sender, e);
            }
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            if (DesbloquearEvent != null)
            {
                DesbloquearEvent(sender, e);
            }
        }
    }
}
