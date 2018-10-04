using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace gasolutions.UInterface
{
    public partial class Impresion : Form
    {
        #region " Declaracion de Variables "
            Int32 _IdConsignacionTransp;
        #endregion

        #region " Declaracion de Propiedades "
        
        public Int32 IdConsignacionTransp
        {
            set 
            {
                _IdConsignacionTransp = value;
            }
        }

        #endregion

        public Impresion()
        {
            InitializeComponent();
        }

        private void Impresion_Load(object sender, EventArgs e)
        {

            if (_IdConsignacionTransp > 0)
            {

                this.recuperarConsignacionTransporIdTableAdapter.Fill(this.impresionConsignacion.RecuperarConsignacionTransporId, _IdConsignacionTransp);
                this.reportViewer1.RefreshReport();
            }
            else
            {
                this.Close();
                throw new Exception("No existe un número de consigancion para imprimir");
            }
        }
    }
}