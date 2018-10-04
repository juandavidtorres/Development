using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PosConfiguracion;

namespace PosConfiguracion
{
    public partial class ValidarUsuario : Form
    {
        public ValidarUsuario()
        {
            InitializeComponent();
        }

        private void gsInicioSesion_EventoAutenticacionApropada(Guid UserId)
        {
            frmMain.UserId = UserId;
        }

        private void gsInicioSesion_EventoCerrarFormulario()
        {
            this.Close();
        }
    }
}
