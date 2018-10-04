using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using gasolutions;

namespace gasolutions.UInterface
{
    public partial class frmIdentificador : Form
    {
        public Int32 IdEmpleado
        {
            get 
            {
                return this.ieIdentificador.IdEmpleado;
            }
            set 
            {
                this.ieIdentificador.IdEmpleado = value;
            }
        }
        public frmIdentificador()
        {
            InitializeComponent();
        }

        private void frmIdentificador_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.ieIdentificador.IdEmpleado > 0)
                {                   
                    this.ieIdentificador.OClose += new EventHandler(ieIdentificador_OClose);
                }
                else
                {
                    throw new Exception("Debe Seleccionar un empleado Valido");
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void ieIdentificador_OClose(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}