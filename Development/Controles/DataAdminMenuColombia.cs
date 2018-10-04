using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Controles
{

    public partial class DataAdminMenuColombia : UserControl
    {
        public delegate void EventHandlerClickOption(object sender, EventArgs e, string namebutton);
        public event EventHandlerClickOption ClickOption;

        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler MenuAdministarEdsEvent;
        public event EventHandler MenuGerenciamientoEvent;
        public event EventHandler MenuFinancieraEvent;
        public event EventHandler SalirEvent;


        public bool MenuAdministarEds
        {
            get { return BtnMenuAdministrarEds.Enabled; }
            set { BtnMenuAdministrarEds.Enabled = value; }
        }



        public bool MenuGerenciamiento
        {
            get { return BtnGerenciamiento.Enabled; }
            set { BtnGerenciamiento.Enabled = value; }
        }

        public bool MenuFinanciera
        {
            get { return BtnFinanciera.Enabled; }
            set { BtnFinanciera.Enabled = value; }
        }
        

        public DataAdminMenuColombia()
        {
            InitializeComponent();
        }


        private void BtnAdministrarEds_Click(object sender, EventArgs e)
        {
            if (MenuAdministarEdsEvent != null)
            {
                MenuAdministarEdsEvent(sender, e);
            }
        }

        private void BtnGerenciamiento_Click(object sender, EventArgs e)
        {
            if (MenuGerenciamientoEvent != null)
            {
                MenuGerenciamientoEvent(sender, e);
            }
        }

        private void BtnFinanciera_Click(object sender, EventArgs e)
        {
            if (MenuFinancieraEvent != null)
            {
                MenuFinancieraEvent(sender, e);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (SalirEvent != null)
            {
                SalirEvent(sender, e);
            }
        }

    }
}



//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Text;
//using System.Windows.Forms;

//namespace Controles
//{

//    public partial class DataAdminMenuColombia : UserControl
//    {
//        public delegate void EventHandlerClickOption(object sender, EventArgs e, string namebutton);
//        public event EventHandlerClickOption ClickOption;

//        public delegate void EventHandler (object sender, EventArgs e);
//        public event EventHandler ClienteEvent;
//        public event EventHandler TipoVehiculoEvent;
//        public event EventHandler RestriccionesEvent;
//        public event EventHandler IdentificadorEvent;
//        public event EventHandler VehiculoEvent;
//        public event EventHandler TransportadoraEvent;
//        public event EventHandler ConsignacionEvent;
//        public event EventHandler ResolucionesEvent;
//        public event EventHandler KilometrajeEvent;
//        public event EventHandler OrdenesEvent;
//        public event EventHandler PagosEvent;
//        public event EventHandler VentasRecuperadasEvent;
//        public event EventHandler ChequesEvent;
//        public event EventHandler FinancierasEvent;
//        public event EventHandler PrecioClienteEvent;
//        public event EventHandler DevolucionesEvent;
//        public event EventHandler SalirEvent;



//        public bool Cliente
//        {
//            get { return BtnCliente.Enabled; }
//            set { BtnCliente.Enabled = value; }
//        }

//        public bool TipoVehiculo
//        {
//            get { return BtnTipoVehiculo.Enabled; }
//            set { BtnTipoVehiculo.Enabled = value; }
//        }

//        public bool Restricciones
//        {
//            get { return BtnRestricciones.Enabled; }
//            set { BtnRestricciones.Enabled = value; }
//        }

//        public bool Identificador
//        {
//            get { return BtnIdentificador.Enabled; }
//            set { BtnIdentificador.Enabled = value; }
//        }

//        public bool Vehiculo
//        {
//            get { return BtnVehiculo.Enabled; }
//            set { BtnVehiculo.Enabled = value; }
//        }

//        public bool Transportadora
//        {
//            get { return BtnTransportadoras.Enabled; }
//            set { BtnTransportadoras.Enabled = value; }
//        }

//        public bool Consignacion
//        {
//            get { return BtnConsignacion.Enabled; }
//            set { BtnConsignacion.Enabled = value; }
//        }

//        public bool Resoluciones
//        {
//            get { return BtnResoluciones.Enabled; }
//            set { BtnResoluciones.Enabled = value; }
//        }

//        public bool Kilometraje
//        {
//            get { return BtnKilometraje.Enabled; }
//            set { BtnKilometraje.Enabled = value; }
//        }

//        public bool Ordenes
//        {
//            get { return BtnOrdenes.Enabled; }
//            set { BtnOrdenes.Enabled = value; }
//        }

//        public bool Pagos
//        {
//            get { return BtnPagos.Enabled; }
//            set { BtnPagos.Enabled = value; }
//        }

//        public bool VentasRecuperadas
//        {
//            get { return BtnVentasRecuperadas.Enabled; }
//            set { BtnVentasRecuperadas.Enabled = value; }
//        }

//        public bool Cheques
//        {
//            get { return BtnCheques.Enabled; }
//            set { BtnCheques.Enabled = value; }
//        }

//        public bool Financieras
//        {
//            get { return BtnFinancieras.Enabled; }
//            set { BtnFinancieras.Enabled = value; }
//        }

//        public bool PrecioCliente
//        {
//            get { return BtnPrecioCliente.Enabled; }
//            set { BtnPrecioCliente.Enabled = value; }
//        }

//        public bool Devoluciones
//        {
//            get { return BtnDevoluciones.Enabled; }
//            set { BtnDevoluciones.Enabled = value; }
//        }


//        private void BtnSalir_Click(object sender, EventArgs e)
//        {
//            if (SalirEvent != null)
//            {
//                SalirEvent(sender, e);
//            }
//        }

//        public DataAdminMenuColombia()
//        {
//            InitializeComponent();
//        }

//        private void BtnCliente_Click(object sender, EventArgs e)
//        {
//            if (ClienteEvent != null) 
//            {
//                ClienteEvent(sender, e);
//            }
//        }

//        private void BtnTipoVehiculo_Click(object sender, EventArgs e)
//        {
//            if (TipoVehiculoEvent != null)
//            {
//                TipoVehiculoEvent(sender, e);
//            }
//        }

//        private void BtnRestricciones_Click(object sender, EventArgs e)
//        {
//            if (RestriccionesEvent != null)
//            {
//                RestriccionesEvent(sender, e);
//            }
//        }

//        private void BtnIdentificador_Click(object sender, EventArgs e)
//        {
//            if (IdentificadorEvent != null)
//            {
//                IdentificadorEvent(sender, e);
//            }
//        }

//        private void BtnVehiculo_Click(object sender, EventArgs e)
//        {
//            if (VehiculoEvent != null)
//            {
//                VehiculoEvent(sender, e);
//            }
//        }

//        private void BtnTransportadoras_Click(object sender, EventArgs e)
//        {
//            if (TransportadoraEvent != null)
//            {
//                TransportadoraEvent(sender, e);
//            }
//        }

//        private void BtnConsignacion_Click(object sender, EventArgs e)
//        {
//            if (ConsignacionEvent != null)
//            {
//                ConsignacionEvent(sender, e);
//            }
//        }

//        private void BtnResoluciones_Click(object sender, EventArgs e)
//        {
//            if (ResolucionesEvent != null)
//            {
//                ResolucionesEvent(sender, e);
//            }
//        }

//        private void BtnKilometraje_Click(object sender, EventArgs e)
//        {
//            if (KilometrajeEvent != null)
//            {
//                KilometrajeEvent(sender, e);
//            }
//        }

//        private void BtnOrdenes_Click(object sender, EventArgs e)
//        {
//            if (OrdenesEvent != null)
//            {
//                OrdenesEvent(sender, e);
//            }
//        }

//        private void BtnPagos_Click(object sender, EventArgs e)
//        {
//            if (PagosEvent != null)
//            {
//                PagosEvent(sender, e);
//            }
//        }

//        private void BtnVentasRecuperadas_Click(object sender, EventArgs e)
//        {
//            if (VentasRecuperadasEvent != null)
//            {
//                VentasRecuperadasEvent(sender, e);
//            }
//        }

//        private void BtnCheques_Click(object sender, EventArgs e)
//        {
//            if (ChequesEvent != null)
//            {
//                ChequesEvent(sender, e);
//            }
//        }

//        private void BtnFinancieras_Click(object sender, EventArgs e)
//        {
//            if (FinancierasEvent != null)
//            {
//                FinancierasEvent(sender, e);
//            }
//        }

//        private void BtnPrecioCliente_Click(object sender, EventArgs e)
//        {
//            if (PrecioClienteEvent != null)
//            {
//                PrecioClienteEvent(sender, e);
//            }
//        }

//        private void BtnDevoluciones_Click(object sender, EventArgs e)
//        {
//            if (DevolucionesEvent != null)
//            {
//                DevolucionesEvent(sender, e);
//            }
//        }

//        private void BtnSalir_Click_1(object sender, EventArgs e)
//        {
//            if (SalirEvent != null)
//            {
//                SalirEvent(sender, e);
//            }
//        }

        
//    }
//}
