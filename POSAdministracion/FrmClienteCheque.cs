using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace gasolutions.UInterface
{
    public partial class FrmClienteCheque : Form
    {
        public delegate void CerrarFormulario();
        public event CerrarFormulario Cierre;

        public FrmClienteCheque()
        {
            InitializeComponent();
        }

        private void FrmClienteCheque_Load(object sender, EventArgs e)
        {
            try
            {                
                gsAgregarCheque.CerrarForm += new gsAgregarMontoCheque.CerrarFormulario(Cerrar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gasolutions SAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Cerrar() 
        {
            Cierre();        
        }

     

    }
}
