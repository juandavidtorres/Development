using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controles
{
    public partial class MnuDSPosColombia : UserControl
    {

        public delegate void EventHandlerClickOption(object sender, EventArgs e, string namebutton);
       
        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler CarasEvent;
        public event EventHandler GalsolinaEvent;
        public event EventHandler GasEvent;
        public event EventHandler CarasTurnoAbiertoEvent;
        public event EventHandler SalirEvent;
        public event EventHandler VentasEstacion;
        public event EventHandler CarasSinTurnoAbiertoEvent;
        


        public MnuDSPosColombia()
        {
            InitializeComponent();
        }

       public bool Caras
        {
            get { return BtnCaras.Enabled; }
            set { BtnCaras.Enabled = value; }
        }



        public bool Gasolina
        {
            get { return BtnGasolina.Enabled; }
            set { BtnGasolina.Enabled = value; }
        }

        public bool Gas
        {
            get { return BtnGas.Enabled; }
            set { BtnGas.Enabled = value; }
        }


        public bool CarasTurnoAbierto
        {
            get { return BtnAbiertos.Enabled; }
            set { BtnAbiertos.Enabled = value; }
        }   
        
        
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            if (SalirEvent != null)
            {
                SalirEvent(sender, e);
            }
        }


        private void BtnCaras_Click(object sender, EventArgs e)
        {
            if (CarasEvent != null)
            {
                CarasEvent(sender, e);
            }
        }

        private void BtnGasolina_Click(object sender, EventArgs e)
        {
            if (GalsolinaEvent != null)
            {
                GalsolinaEvent(sender, e);
            }
        }

        private void BtnGas_Click(object sender, EventArgs e)
        {
            if (GasEvent != null)
            {
                GasEvent(sender, e);
            }
        }

        private void BtnAbiertos_Click(object sender, EventArgs e)
        {
            if (CarasTurnoAbiertoEvent != null)
            {
                CarasTurnoAbiertoEvent(sender, e);
            }
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            if (VentasEstacion!=null)
            {
                VentasEstacion(sender, e);  
            }

        }

        private void BtnCerrados_Click(object sender, EventArgs e)
        {

            if (CarasSinTurnoAbiertoEvent != null)
            {
                CarasSinTurnoAbiertoEvent(sender, e);
            }
        }



   
    }
}
