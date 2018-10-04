using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using System.Collections;
using PosStation.Generaciones;
using PosStation.MenuAdministracionEds;
using PosStation.MenuGerenciamiento;
using PosStation.MenuFinanciera;
using POSstation.Fabrica;
using PayOffice;

namespace gasolutions.UInterface
{
    public partial class MainForm : Form
    {
        #region "   Declaracion de Variables    "

        Helper oHelper = new Helper();
        Instancias oInstancia = new Instancias();
        MenuAdministracionEds oMenuAdministracion = new MenuAdministracionEds();
        MenuGerenciamiento oMenuGerenciamiento = new MenuGerenciamiento();
        MenuFinanciera oMenuFinanciera = new MenuFinanciera();

        public enum Options
        {
            Administracion,
            Gerenciamiento,
            Financiera,
            Ninguna
        };

        Options option = Options.Ninguna;

        Generacion oFacturacion = new Generacion();
      
              
        List<Control> oArray = new List<Control>();
        public static Nullable<Guid> _UserId = null;

        public static Nullable<Guid> UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        #endregion

        public MainForm()
        {
            InitializeComponent();
        }
       


        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                bool enEjecucion;
                // comprobando la cantidad de elementos del array
                enEjecucion = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1;

                if (enEjecucion)
                {
                    this.Close();
                }

               
                oMenuAdministracion.Visible = false;
                oMenuAdministracion.oClosed += new PosStation.MenuAdministracionEds.MenuAdministracionEds.EventHandler(this.oMenuAdministracion_oClosed);
                this.pnlPrincipal.Controls.Add(oMenuAdministracion);


                oMenuFinanciera.Visible = false;
                //oMenuFinanciera.oClosed += new PosStation.MenuFinanciera.MenuFinanciera.EventHandler(this.oMenuFinanciera_oClosed);
                this.pnlPrincipal.Controls.Add(oMenuFinanciera);

                oMenuGerenciamiento.Visible = false;
                oMenuGerenciamiento.oClosed += new PosStation.MenuGerenciamiento.MenuGerenciamiento.EventHandler(this.oMenuFinanciera_oClosed);
                this.pnlPrincipal.Controls.Add(oMenuGerenciamiento);
               
                ValidarUsuario validacion = new ValidarUsuario();
                validacion.ShowDialog();

                if (_UserId == null)
                {
                    this.Close();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void dataAdminMenuColombia1_SalirEvent(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea cerrar la aplicación Data Administrator?", "Data Administrator",
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

        private void dataAdminMenuColombia1_MenuAdministarEdsEvent(object sender, EventArgs e)
        {
            try
            {
                if (option != Options.Administracion)
                {
                    oMenuAdministracion.IniciarForma();
                    oArray.Add(oMenuAdministracion);
                    ControlVisibleenPantalla();
                    option = Options.Administracion;
                }
                                                                              
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }

        }

        private void dataAdminMenuColombia1_MenuGerenciamientoEvent(object sender, EventArgs e)
        {
            try
            {

                if (option != Options.Gerenciamiento)
                {
                    oMenuGerenciamiento.IniciarForma();
                    oArray.Add(oMenuGerenciamiento);
                    ControlVisibleenPantalla();
                    option = Options.Gerenciamiento;
                }

               
           }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }

        }

        private void dataAdminMenuColombia1_MenuFinancieraEvent(object sender, EventArgs e)
        {
            try
            {

                if (option != Options.Financiera)
                {
                    oArray.Add(oMenuFinanciera);
                    oMenuFinanciera.Reset();
                    ControlVisibleenPantalla();
                    option = Options.Financiera;
                }              
               
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

               
        private void ControlVisibleenPantalla()
        {
            Int16 Max = Int16.Parse((oArray.Count - 1).ToString());

            for (Int16 i = 0; i <= Max; ++i)
            {
                if (Max == i)
                {
                    oArray[i].Visible = true;
                }
                else
                {
                    oArray[i].Visible = false;
                }

            }
        }
          

        private void oMenuAdministracion_oClosed(object sender, EventArgs e)
        {
            oArray.Remove(oMenuAdministracion);
            ControlVisibleenPantalla();
        }
        private void oMenuGerenciamiento_oClosed(object sender, EventArgs e)
        {
            oArray.Remove(oMenuGerenciamiento);
            ControlVisibleenPantalla();
        }
        private void oMenuFinanciera_oClosed(object sender, EventArgs e)
        {
            oArray.Remove(oMenuFinanciera);
            ControlVisibleenPantalla();
        }
           
    
    }
}



//using System;
//using System.Diagnostics;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;
//using POSstation.AccesoDatos;
//using System.Collections;
//using PosStation.gsClientes;
//using PosSation.gsCreditos;
//using PosStation.gsChips;
//using PosStation.gsEmpleados;
//using PosStation.Generacion;
//using PosStation.MenuAdministracionEds;
//using PosStation.gsPagoFacturas;
//using POSstation.Fabrica;
//using PayOffice;

//namespace gasolutions.UInterface
//{
//    public partial class MainForm : Form
//    {
//        #region "   Declaracion de Variables    "

//        Helper oHelper = new Helper();
//        Instancias oInstancia = new Instancias();
//        gsCliente oCliente = new gsCliente();
//        gsCreditos oCreditos = new gsCreditos();
//        gsChips oChips = new gsChips();
//        gsEmpleados oEmpleados = new gsEmpleados();
//        Generacion oFacturacion = new Generacion();
//        gsPagoFacturas oPagos = new gsPagoFacturas();
//        gsRestricciones.gsRestricciones oRestriccion = new gsRestricciones.gsRestricciones();
//        gsPrepago oRecargas = new gsPrepago();
//        Vehiculos oVehiculo = new Vehiculos();
//        gsTransportadora oTransportadora = new gsTransportadora();
//        gsConsigTransportadora oConsigTransportadora = new gsConsigTransportadora();
//        gsResolucion oResolucionCanastilla = new gsResolucion();
//        gsKilometraje oKilometraje = new gsKilometraje();
//        gsOrdenPedido oOrdenPedido = new gsOrdenPedido();
        
//        gsCheques oCheque = new gsCheques();
//        gsFinacieras oFinanciera = new gsFinacieras();
//        DataAdminFullStationPeru.gsDevoluciones Devoluciones = new DataAdminFullStationPeru.gsDevoluciones();
//        gsPrecioClienteCredito.gsPrecioClienteCredito oPrecioCliente = new gsPrecioClienteCredito.gsPrecioClienteCredito();
//        gsTipoVehiculo oTipoVehiculo = new gsTipoVehiculo();

//        Boolean CreditoEnUso;
//        Boolean VehiculoEnUso;
//        Boolean ClienteEnUso;
//        Boolean ChipsEnUso;
//        Boolean OrdenEnUso;
//        Boolean EmpleadoEnUso;
//        Boolean PagosEnUso;
//        Boolean RecargasEnUso;
//        Boolean RestriccionEnUso;
//        Boolean TransportadoraEnUso;
//        Boolean ConsigTransportadoraEnUso;
//        Boolean ResolucionEnUso;
//        Boolean KilometrajeEnUso;
//        Boolean VentasFueraDeSistemas;
//        Boolean Cheques;
//        Boolean Financiera;
//        Boolean devolucion;
//        Boolean TipoVehiculoEnUso;
//        Boolean Precio;

//        List<Control> oArray = new List<Control>();
//        public static Nullable<Guid> _UserId = null;

//        public static Nullable<Guid> UserId
//        {
//            get { return _UserId; }
//            set { _UserId = value; }
//        }

//        #endregion

//        public MainForm()
//        {
//            InitializeComponent();
//        }

//        private void MainForm_Load(object sender, EventArgs e)
//        {
//            try
//            {
//                //gasolutionsHasp.IsHasp();

//                bool enEjecucion;

//                // comprobando la cantidad de elementos del array
//                enEjecucion = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1;

//                if (enEjecucion)
//                {
//                    this.Close();
//                }

//                RecuperarDatosBasicos(oHelper);


                    //oCliente.Visible = false;
                    //oCliente.MostrarVehiculo += new PosStation.gsClientes.WorkerEndHandler(this.oCliente_MostrarVehiculo);
                    //oCliente.oClosed += new EventHandler(this.oCliente_oClosed);
                    //this.pnlPrincipal.Controls.Add(oCliente);

//                oCreditos.Visible = false;
//                oCreditos.oClosed += new EventHandler(this.oCreditos_oClosed);
//                oCreditos.oEventSaldos += new PosSation.gsCreditos.WorkerEndHandler(this.oCreditos_oEventSaldos);
//                this.pnlPrincipal.Controls.Add(oCreditos);

//                oVehiculo.Visible = false;
//                oVehiculo.MostrarCredito += new WorkerEndHandler(oVehiculo_MostrarCredito);
//                oVehiculo.oClosed += new EventHandler(this.oVehiculo_oClosed);
//                this.pnlPrincipal.Controls.Add(oVehiculo);

//                oChips.Visible = false;
//                oChips.oClosed += new EventHandler(this.oChips_oClosed);
//                this.pnlPrincipal.Controls.Add(oChips);

//                oEmpleados.Visible = false;
//                oEmpleados.oClosed += new EventHandler(this.oEmpleados_oClosed);
//                oEmpleados.VisualizarIdentificadores += new gsEmpleados.WorkerEndHandler(oEmpleados_VisualizarIdentificadores);
//                this.pnlPrincipal.Controls.Add(oEmpleados);

//                oFacturacion.Visible = false;
//                oFacturacion.oClosed += new EventHandler(this.oFacturacion_oClosed);
//                this.pnlPrincipal.Controls.Add(oFacturacion);

//                oPagos.Visible = false;
//                oPagos.oClosed += new EventHandler(this.oPagos_oClosed);
//                this.pnlPrincipal.Controls.Add(oPagos);

//                oRecargas.Visible = false;
//                oRecargas.oClosed += new EventHandler(oRecargas_oClosed);
//                this.pnlPrincipal.Controls.Add(oRecargas);

//                oRestriccion.Visible = false;
//                oRestriccion.oClosed += new EventHandler(oRestriccion_oClosed);
//                this.pnlPrincipal.Controls.Add(oRestriccion);

//                oTransportadora.Visible = false;
//                oTransportadora.oClosed += new EventHandler(oTransportadora_oClosed);
//                this.pnlPrincipal.Controls.Add(oTransportadora);

//                oConsigTransportadora.Visible = false;
//                oConsigTransportadora.oClosed += new EventHandler(oConsigTransportadora_oClosed);
//                this.pnlPrincipal.Controls.Add(oConsigTransportadora);

//                oResolucionCanastilla.Visible = false;
//                oResolucionCanastilla.oClosed += new EventHandler(oResolucionCanastilla_oClosed);
//                this.pnlPrincipal.Controls.Add(oResolucionCanastilla);

//                oKilometraje.Visible = false;
//                oKilometraje.oClosed += new EventHandler(oKilometraje_oClosed);
//                this.pnlPrincipal.Controls.Add(oKilometraje);

           

//                oOrdenPedido.Visible = false;
//                oOrdenPedido.oClosed += new EventHandler(oOrdenPedido_oClosed);
//                this.pnlPrincipal.Controls.Add(oOrdenPedido);

//                oCheque.Visible = false;
//                oCheque.oClosed += new EventHandler(oCheques_oClosed);
//                this.pnlPrincipal.Controls.Add(oCheque);

//                oFinanciera.Visible = false;
//                oFinanciera.oClosed += new EventHandler(oFinanciera_oClosed);
//                this.pnlPrincipal.Controls.Add(oFinanciera);

//                Devoluciones.Visible = false;
//                Devoluciones.EventoCerrar += new EventHandler(oDevoluciones_oClosed);
//                this.pnlPrincipal.Controls.Add(Devoluciones);

//                oTipoVehiculo.Visible = false;
//                oTipoVehiculo.oClosed += new EventHandler(oTipoVehiculo_oClosed);
//                this.pnlPrincipal.Controls.Add(oTipoVehiculo);

//                oPrecioCliente.Visible = false;
//                oPrecioCliente.oClosed += new EventHandler(oPrecioCliente_oClosed);
//                this.pnlPrincipal.Controls.Add(oPrecioCliente);

//                ValidarUsuario validacion = new ValidarUsuario();
//                validacion.ShowDialog();

//                if (_UserId == null)
//                {
//                    this.Close();
//                    this.Dispose();
//                }

//                //AplicarPermisosPorAcciones();

//            }

         
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }


//        /*
//        private void AplicarPermisosPorAcciones()
//        {
//            try
//            {
//                Helper oHelper = new Helper();

//                if (_UserId.HasValue)
//                {
//                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesDataAdminColombia.ABMEmpleados))
//                    {
//                        this.mnuEmpleado.Enabled = false;
//                    }

//                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesDataAdminColombia.ABMClientes))
//                    {
//                        this.mnuCliente.Enabled = false;
//                    }

//                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesDataAdminColombia.ABMVehiculos))
//                    {
//                        this.mnuVehiculo.Enabled = false;
//                    }

//                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesDataAdminColombia.ABMCreditos))
//                    {
//                        this.mnuCredito.Enabled = false;
//                    }

//                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesDataAdminColombia.RestriccionVehiculos))
//                    {
//                        this.mnuRestriccion.Enabled = false;
//                    }

//                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesDataAdminColombia.InactivacionChips))
//                    {
//                        this.mnuChip.Enabled = false;
//                    }

//                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesDataAdminColombia.ResolucionesFacturacion))
//                    {
//                        this.mnuResolucion.Enabled = false;
//                    }

//                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesDataAdminColombia.ABMTransportadoras))
//                    {
//                        this.mnuTransportadoras.Enabled = false;
//                    }

//                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesDataAdminColombia.ConsignacionesTransportadora))
//                    {
//                        this.mnuConsigTransportadora.Enabled = false;
//                    }

//                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesDataAdminColombia.AutorizacionCheques))
//                    {
//                        this.tlbCheque.Enabled = false;
//                    }

//                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesDataAdminColombia.KilometrajeVentas))
//                    {
//                        this.mnuKilometraje.Enabled = false;
//                    }

//                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesDataAdminColombia.DevolucionCheques))
//                    {
//                        this.tsbDevoluciones.Enabled = false;
//                    }

//                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesDataAdminColombia.SolicitudOrdenPedidoCombustible))
//                    {
//                        this.mnuOrden.Enabled = false;
//                    }

//                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesDataAdminColombia.ABMFinancieras))
//                    {
//                        this.tlsFinancienras.Enabled = false;
//                    }

//                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesDataAdminColombia.VentasFueraSistema))
//                    {
//                        this.tlbVentaSinSistemas.Enabled = false;
//                    }

//                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesDataAdminColombia.TiposVehiculo))
//                    {
//                        this.mnuTipoVehiculo.Enabled = false;
//                    }

//                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesDataAdminColombia.PrecioCliente))
//                    {
//                        this.mnuPrecio.Enabled = false;
//                    }
//                }
//                else
//                {
//                    MessageBox.Show("El usuario actual no se ha podido autenticar en el sistema");
//                    Application.Exit();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }
//         */

//        private void oEmpleados_VisualizarIdentificadores(object o, EventIdentificador e)
//        {
//            try
//            {
//                frmIdentificador ofrmIdentificador = new frmIdentificador();
//                ofrmIdentificador.IdEmpleado = e.IdEmpleado;
//                ofrmIdentificador.ShowDialog();
//                ofrmIdentificador.StartPosition = FormStartPosition.CenterScreen;
//            }
//            catch (Exception ex)
//            {
//                Popup.ContentText = ex.Message;
//                Popup.Popup();
//            }
//        }


//        private void RecuperarDatosBasicos(Helper oHelper)
//        {
//            try
//            {
//                //InformacionEstacion oEstacion = oHelper.RecuperarDatosEstacion();

//                // this.datosGenerales1.Codigo = oEstacion.Codigo;
//                // this.datosGenerales1.Nombre = oEstacion.Nombre;
//                // this.datosGenerales1.Nit = oEstacion.Nit;
//                // this.datosGenerales1.Direccion = oEstacion.Direccion;
//                // this.datosGenerales1.Telefono = oEstacion.Telefono;
//                // this.datosGenerales1.Ciudad = oEstacion.Ciudad;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

    

//        private void oCliente_MostrarVehiculo(object sender, EventCliente e)
//        {
//            VehiculoEnUso = true;
//            oArray.Add(oVehiculo);
//            ControlVisibleenPantalla();
//            oVehiculo.Placa = e.iPlaca;
//            oVehiculo.IniciarForma();
//        }

//        private void oCliente_oClosed(object sender, EventArgs e)
//        {
//            ClienteEnUso = false;
//            oArray.Remove(oCliente);
//            ControlVisibleenPantalla();
//        }

     
//        public void oVehiculo_oClosed(object sender, EventArgs e)
//        {
//            VehiculoEnUso = false;
//            oArray.Remove(oVehiculo);
//            ControlVisibleenPantalla();
//        }

//        private void mnuEmpleado_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                //if (Factory.Seguridad.EsAdministrador())
//                if (EmpleadoEnUso == false)
//                {
//                    oArray.Add(oEmpleados);
//                    oEmpleados.IniciarForma();
//                    ControlVisibleenPantalla();
//                    EmpleadoEnUso = true;
//                }
//                //else
//                //    MessageBox.Show("El Usuario " + Factory.Seguridad.Usuario() + " no tiene los Permisos para Ejecutar la aplicacion");
//            }
//            catch (Exception ex)
//            {
//                Popup.ContentText = ex.Message;
//                Popup.Popup();
//            }
//        }

//        private void oEmpleados_oClosed(object sender, EventArgs e)
//        {
//            EmpleadoEnUso = false;
//            oArray.Remove(oEmpleados);
//            ControlVisibleenPantalla();
//        }

//        private void mnuCredito_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                if (CreditoEnUso == false)
//                {
//                    oArray.Add(oCreditos);
//                    ControlVisibleenPantalla();
//                    oCreditos.Credito = 0;
//                    oCreditos.IniciarForma();
//                    //oCreditos.Visible = true;
//                    CreditoEnUso = true;
//                }
//            }
//            catch (Exception ex)
//            {
//                Popup.ContentText = ex.Message;
//                Popup.Popup();
//            }
//        }

//        private void oCreditos_oClosed(object sender, EventArgs e)
//        {
//            CreditoEnUso = false;
//            oArray.Remove(oCreditos);
//            ControlVisibleenPantalla();

//        }

//        private void oCreditos_oEventSaldos(object sender, EventCredito e)
//        {
//            try
//            {
//                //oInstancia.AbrirVentana(typeof(Facturar));
//                if (RecargasEnUso == false)
//                {
//                    RecargasEnUso = true;
//                    oArray.Add(oRecargas);
//                    ControlVisibleenPantalla();
//                    oRecargas.Documento = e.Documento;
//                    oRecargas.IniciarForma();
//                }
//            }
//            catch (Exception ex)
//            {
//                Popup.ContentText = ex.Message;
//                Popup.Popup();
//            }

//        }

//        private void oRecargas_oClosed(object sender, EventArgs e)
//        {
//            RecargasEnUso = false;
//            oArray.Remove(oRecargas);
//            ControlVisibleenPantalla();
//        }

//        private void oFacturacion_oClosed(object sender, EventArgs e)
//        {
//            oArray.Remove(oFacturacion);
//            ControlVisibleenPantalla();
//            OrdenEnUso = false;
//        }

     

//        private void oChips_oClosed(object sender, EventArgs e)
//        {
//            ChipsEnUso = false;
//            oArray.Remove(oChips);
//            ControlVisibleenPantalla();
//        }

//        private void oVehiculo_MostrarCredito(object sender, EventVehiculo e)
//        {
//            CreditoEnUso = true;
//            oArray.Add(oCreditos);
//            ControlVisibleenPantalla();
//            oCreditos.Credito = Int32.Parse(e.TheString);
//            oCreditos.IniciarForma();

//        }



//        private void ControlVisibleenPantalla()
//        {
//            Int16 Max = Int16.Parse((oArray.Count - 1).ToString());

//            for (Int16 i = 0; i <= Max; ++i)
//            {
//                if (Max == i)
//                {
//                    oArray[i].Visible = true;
//                }
//                else
//                {
//                    oArray[i].Visible = false;
//                }

//            }
//        }

   
//        private void oPagos_oClosed(object sender, EventArgs e)
//        {
//            PagosEnUso = false;
//            oArray.Remove(oPagos);
//            ControlVisibleenPantalla();
//        }

//        private void oRestriccion_oClosed(object sender, EventArgs e)
//        {
//            RestriccionEnUso = false;
//            oArray.Remove(oRestriccion);
//            ControlVisibleenPantalla();

//        }


//        private void oTransportadora_oClosed(object sender, EventArgs e)
//        {
//            TransportadoraEnUso = false;
//            oArray.Remove(oTransportadora);
//            ControlVisibleenPantalla();
//        }

//        private void oConsigTransportadora_oClosed(object sender, EventArgs e)
//        {
//            ConsigTransportadoraEnUso = false;
//            oArray.Remove(oConsigTransportadora);
//            ControlVisibleenPantalla();
//        }

//        private void oResolucionCanastilla_oClosed(object sender, EventArgs e)
//        {
//            ResolucionEnUso = false;
//            oArray.Remove(oResolucionCanastilla);
//            ControlVisibleenPantalla();
//        }



//        private void oKilometraje_oClosed(object sender, EventArgs e)
//        {
//            KilometrajeEnUso = false;
//            oArray.Remove(oKilometraje);
//            ControlVisibleenPantalla();
//        }




       


//        private void oCheques_oClosed(object sender, EventArgs e)
//        {
//            Cheques = false;
//            oArray.Remove(oCheque);
//            ControlVisibleenPantalla();
//        }


//        private void oFinanciera_oClosed(object sender, EventArgs e)
//        {
//            Financiera = false;
//            oArray.Remove(oFinanciera);
//            ControlVisibleenPantalla();
//        }
//        private void oDevoluciones_oClosed(object sender, EventArgs e)
//        {
//            devolucion = false;
//            oArray.Remove(Devoluciones);
//            ControlVisibleenPantalla();
//        }
//        void oOrdenPedido_oClosed(object sender, EventArgs e)
//        {
//            OrdenEnUso = false;
//            oArray.Remove(oOrdenPedido);
//            ControlVisibleenPantalla();
//        }

//           void oTipoVehiculo_oClosed(object sender, EventArgs e)
//        {
//            TipoVehiculoEnUso = false;
//            oArray.Remove(oTipoVehiculo);
//            ControlVisibleenPantalla();
//        }

//        void oPrecioCliente_oClosed(object sender, EventArgs e)
//        {
//            Precio = false;
//            oArray.Remove(oPrecioCliente);
//            ControlVisibleenPantalla();
//        }

//        private void tlbBottom_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
//        {

//        }

//        private void ControlPrincipal_Load(object sender, EventArgs e)
//        {

//        }

        
//        private void dataAdminMenuColombia1_SalirEvent(object sender, EventArgs e)
//        {
//            try
//            {
//                if (MessageBox.Show("¿Desea cerrar la aplicación Data Administrator?", "Data Administrator",
//                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
//                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
//                {
//                    this.Close();
//                    this.Dispose();
//                    Application.Exit();
//                }
//            }
//            catch (InvalidOperationException)
//            {
//                Popup.ContentText = "\t\t\tData Administrador\n\nEl formulario se ha cerrado mientras se creaba un identificador.";
//                Popup.Popup();
//            }
//        }

//        private void dataAdminMenuColombia1_ClienteEvent(object sender, EventArgs e)
//        {
//            try
//            {
//                if (ClienteEnUso == false)
//                {
//                    oArray.Add(oCliente);
//                    ControlVisibleenPantalla();
//                    oCliente.IniciarForma();
//                    //oCliente.Visible = true;
//                    ClienteEnUso = true;
//                }

//            }
//            catch (Exception ex)
//            {
//                Popup.ContentText = ex.Message;
//                Popup.Popup();
//            }
//        }

//        private void dataAdminMenuColombia1_TipoVehiculoEvent(object sender, EventArgs e)
//        {
//            try
//            {
//                if (TipoVehiculoEnUso == false)
//                {
//                    TipoVehiculoEnUso = true;
//                    oTipoVehiculo.IniciarForma();
//                    oArray.Add(oTipoVehiculo);
//                    ControlVisibleenPantalla();
//                }
//            }
//            catch (Exception ex)
//            {
//                Popup.ContentText = ex.Message;
//                Popup.Popup();
//            }
            
//        }

//        private void dataAdminMenuColombia1_RestriccionesEvent(object sender, EventArgs e)
//        {
//            try
//            {
//                if (RestriccionEnUso == false)
//                {
//                    RestriccionEnUso = true;
//                    oArray.Add(oRestriccion);
//                    ControlVisibleenPantalla();
//                    oRestriccion.IniciarForma();
//                }
//            }
//            catch (Exception ex)
//            {
//                Popup.ContentText = ex.Message;
//                Popup.Popup();
//            }
//        }

//        private void dataAdminMenuColombia1_IdentificadorEvent(object sender, EventArgs e)
//        {
//            try
//            {
//                if (ChipsEnUso == false)
//                {
//                    oArray.Add(oChips);
//                    oChips.IniciarControl();
//                    ControlVisibleenPantalla();
//                    ChipsEnUso = true;
//                }
//            }
//            catch (Exception ex)
//            {
//                Popup.ContentText = ex.Message;
//                Popup.Popup();
//            }
//        }

//        private void dataAdminMenuColombia1_VehiculoEvent(object sender, EventArgs e)
//        {
//            try
//            {
//                if (VehiculoEnUso == false)
//                {
//                    oArray.Add(oVehiculo);
//                    ControlVisibleenPantalla();
//                    oVehiculo.Placa = "";
//                    oVehiculo.IniciarForma();
//                    //oVehiculo.Visible = true;
//                    VehiculoEnUso = true;
//                }

//            }
//            catch (Exception ex)
//            {
//                Popup.ContentText = ex.Message;
//                Popup.Popup();
//            }
//        }

//        private void dataAdminMenuColombia1_TransportadoraEvent(object sender, EventArgs e)
//        {
//            try
//            {
//                if (TransportadoraEnUso == false)
//                {
//                    TransportadoraEnUso = true;
//                    oArray.Add(oTransportadora);
//                    ControlVisibleenPantalla();
//                    oTransportadora.IniciarForma();
//                }
//            }
//            catch (Exception ex)
//            {
//                Popup.ContentText = ex.Message;
//                Popup.Popup();
//            }
//        }

//        private void dataAdminMenuColombia1_ConsignacionEvent(object sender, EventArgs e)
//        {
//            try
//            {
//                if (ConsigTransportadoraEnUso == false)
//                {
//                    ConsigTransportadoraEnUso = true;
//                    oArray.Add(oConsigTransportadora);
//                    ControlVisibleenPantalla();
//                    oConsigTransportadora.IniciarForma();
//                }
//            }
//            catch (Exception ex)
//            {
//                Popup.ContentText = ex.Message;
//                Popup.Popup();
//            }
//        }

//        private void dataAdminMenuColombia1_ResolucionesEvent(object sender, EventArgs e)
//        {
//            try
//            {
//                if (ResolucionEnUso == false)
//                {
//                    ResolucionEnUso = true;
//                    oArray.Add(oResolucionCanastilla);
//                    ControlVisibleenPantalla();
//                    oResolucionCanastilla.IniciarForma();
//                }
//            }
//            catch (Exception ex)
//            {
//                Popup.ContentText = ex.Message;
//                Popup.Popup();
//            }
//        }

//        private void dataAdminMenuColombia1_KilometrajeEvent(object sender, EventArgs e)
//        {
//            try
//            {
//                if (KilometrajeEnUso == false)
//                {
//                    KilometrajeEnUso = true;
//                    oArray.Add(oKilometraje);
//                    ControlVisibleenPantalla();
//                    oKilometraje.IniciarForma();
//                }
//            }
//            catch (Exception ex)
//            {
//                Popup.ContentText = ex.Message;
//                Popup.Popup();
//            }
//        }

//        private void dataAdminMenuColombia1_OrdenesEvent(object sender, EventArgs e)
//        {
//            try
//            {
//                //oInstancia.AbrirVentana(typeof(Facturar));
//                if (OrdenEnUso == false)
//                {
//                    OrdenEnUso = true;
//                    oArray.Add(oOrdenPedido);
//                    ControlVisibleenPantalla();
//                    oOrdenPedido.IniciarForma();
//                }
//            }
//            catch (Exception ex)
//            {
//                Popup.ContentText = ex.Message;
//                Popup.Popup();
//            }
//        }

//        private void dataAdminMenuColombia1_PagosEvent(object sender, EventArgs e)
//        {
//            try
//            {
//                if (PagosEnUso == false)
//                {
//                    PagosEnUso = true;
//                    oArray.Add(oPagos);
//                    ControlVisibleenPantalla();
//                    oPagos.IniciarControl();
//                }
//            }
//            catch (Exception ex)
//            {
//                Popup.ContentText = ex.Message;
//                Popup.Popup();
//            }
//        }

      
//        private void dataAdminMenuColombia1_ChequesEvent(object sender, EventArgs e)
//        {
//            try
//            {
//                if (Cheques == false)
//                {
//                    Cheques = true;
//                    oArray.Add(oCheque);
//                    ControlVisibleenPantalla();
//                }
//            }
//            catch (System.Exception ex)
//            {
//                MessageBox.Show((ex.Message));

//            }
//        }

//        private void dataAdminMenuColombia1_FinancierasEvent(object sender, EventArgs e)
//        {
//            try
//            {
//                if (Financiera == false)
//                {
//                    Financiera = true;
//                    oArray.Add(oFinanciera);
//                    ControlVisibleenPantalla();
//                }
//            }
//            catch (System.Exception ex)
//            {
//                MessageBox.Show((ex.Message));

//            }
//        }

//        private void dataAdminMenuColombia1_PrecioClienteEvent(object sender, EventArgs e)
//        {
//            try
//            {
//                if (Precio == false)
//                {
//                    Precio = true;
//                    oArray.Add(oPrecioCliente);
//                    ControlVisibleenPantalla();
//                }
//            }
//            catch (System.Exception ex)
//            {
//                MessageBox.Show((ex.Message));

//            }
//        }

//        private void dataAdminMenuColombia1_DevolucionesEvent(object sender, EventArgs e)
//        {
//            try
//            {
//                if (devolucion == false)
//                {
//                    devolucion = true;
//                    oArray.Add(Devoluciones);
//                    ControlVisibleenPantalla();
//                }
//            }
//            catch (System.Exception ex)
//            {
//                MessageBox.Show((ex.Message));

//            }
//        }

       
//    }
//}