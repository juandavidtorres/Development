using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Controles
{
    public partial class FSConfigColombia : UserControl
    {
        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler OtrosEvent;
        public event EventHandler LectoresEvent;
        public event EventHandler ConfigEvent;
        public event EventHandler EstacionEvent;
        public event EventHandler LiquidoEvent;
        public event EventHandler UnidadEvent;
        public event EventHandler SobretasaEvent;
        public event EventHandler TarjetaEvent;
        public event EventHandler SalirEvent;
        public event EventHandler FormaPagoEvent;
        public event EventHandler BonosEvent;

        public bool FormaPago
        {
            get { return BtnFormaPago.Enabled; }
            set { BtnFormaPago.Enabled = value; }
        }

        public bool Otros
        {
            get { return BtnOtros.Enabled; }
            set { BtnOtros.Enabled = value; }
        }

        public bool Lectores
        {
            get { return BtnLectores.Enabled; }
            set { BtnLectores.Enabled = value; }
        }

        public bool Config
        {
            get { return BtnConfig.Enabled; }
            set { BtnConfig.Enabled = value; }
        }

        public bool Estacion
        {
            get { return BtnEstacion.Enabled; }
            set { BtnEstacion.Enabled = value; }
        }

        public bool Liquido
        {
            get { return BtnLiquido.Enabled; }
            set { BtnLiquido.Enabled = value; }
        }

        public bool Unidad
        {
            get { return BtnUnidad.Enabled; }
            set { BtnUnidad.Enabled = value; }
        }

        public bool Sobretasa
        {
            get { return BtnSobreTasa.Enabled; }
            set { BtnSobreTasa.Enabled = value; }
        }
        public bool Tarjeta
        {
            get { return BtnTarjeta.Enabled; }
            set { BtnTarjeta.Enabled = value; }
        }

        public FSConfigColombia()
        {
            InitializeComponent();
        }

        private void BtnOtros_Click(object sender, EventArgs e)
        {
            if (OtrosEvent != null)
            {
                OtrosEvent(sender, e);
            }
        }

        private void BtnLectores_Click(object sender, EventArgs e)
        {
            if (LectoresEvent != null)
            {
                LectoresEvent(sender, e);
            }
        }

        private void BtnConfig_Click(object sender, EventArgs e)
        {
            if (ConfigEvent != null)
            {
                ConfigEvent(sender, e);
            }
        }

        private void BtnEstacion_Click(object sender, EventArgs e)
        {
            if (EstacionEvent != null)
            {
                EstacionEvent(sender, e);
            }
        }

        private void BtnLiquido_Click(object sender, EventArgs e)
        {
            if (LiquidoEvent != null)
            {
                LiquidoEvent(sender, e);
            }
        }

        private void BtnUnidad_Click(object sender, EventArgs e)
        {
            if (UnidadEvent != null)
            {
                UnidadEvent(sender, e);
            }
        }

        private void BtnSobreTasa_Click(object sender, EventArgs e)
        {
            if (SobretasaEvent != null)
            {
                SobretasaEvent(sender, e);
            }
        }

        private void BtnTarjeta_Click(object sender, EventArgs e)
        {
            if (TarjetaEvent != null)
            {
                TarjetaEvent(sender, e);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (SalirEvent != null)
            {
                SalirEvent(sender, e);
            }
        }

        private void BtnFormaPago_Click(object sender, EventArgs e)
        {
            if (FormaPagoEvent != null)
            {
                FormaPagoEvent(sender, e);
            }
        }

        private void BtnBono_Click(object sender, EventArgs e)
        {
            if (BonosEvent != null)
            {
                BonosEvent(sender, e);
            }
        }
    }
}
