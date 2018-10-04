using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using PosStation.gsClientes;
using PosSation.gsCreditos;
using gasolutions.gsPrecioClienteCredito;
using Controles;
using gasolutions.UInterface;
using gasolutions;
using System.Diagnostics;
using POSstation.Fabrica;
using POSAdministracion;


namespace PosStation.MenuGerenciamiento
{
    public partial class MenuGerenciamiento : UserControl
    {

        #region "   Declaracion de Variables    "

        Helper oHelper = new Helper();
        Instancias oInstancia = new Instancias();
        gsCliente oCliente = new gsCliente();
        Vehiculos oVehiculo = new Vehiculos();
        gsCreditos oCreditos = new gsCreditos();
        gsPrepago oRecargas = new gsPrepago();
        gsRestricciones.gsRestricciones oRestriccion = new gsRestricciones.gsRestricciones();
        gsKilometraje oKilometraje = new gsKilometraje();
        gsPrecioClienteCredito oPrecioCliente = new gsPrecioClienteCredito();
        gsRenovarCredito oRenovarCredito = new gsRenovarCredito();
        gsTarjeta oTarjeta = new gsTarjeta();

        public Control OControl = new Control();
        Boolean ClienteEnUso;
        Boolean VehiculoEnUso;
        Boolean CreditoEnUso;
        Boolean RecargasEnUso;
        Boolean RestriccionEnUso;
        Boolean Precio;
        Boolean KilometrajeEnUso;
        Boolean TarjetaEnUso;

        List<Control> oArray = new List<Control>();
        public static Nullable<Guid> _UserId = null;

        public static Nullable<Guid> UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        #endregion



        public delegate void EventHandlerClickOption(object sender, EventArgs e, string namebutton);
        public event EventHandlerClickOption ClickOption;

        public delegate void EventHandler(object sender, EventArgs e);


        public MenuGerenciamiento()
        {
            InitializeComponent();
        }

        public void IniciarForma()
        {
            this.Controls.Remove(OControl);
            IniciarBotones();
            AplicarPermisosPorAcciones();
        }





        public class EventMenuGerenciamiento : EventArgs
        {

            public readonly string iPlaca;
            public readonly Boolean iEstado;

            public EventMenuGerenciamiento(string s, Boolean Estado)
            {

            }

        }
        public delegate void WorkerEndHandler(object o, EventMenuGerenciamiento e);

        public event EventHandler oClosed;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            oClosed(sender, e);
        }

        private void MenuGerenciamientoInicio(object sender, EventArgs e)
        {
            try
            {
                bool enEjecucion;

                // comprobando la cantidad de elementos del array
                enEjecucion = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1;

                if (enEjecucion)
                {
                    //this.Close();
                }



                oCliente.Visible = false;
                oCliente.MostrarVehiculo += new PosStation.gsClientes.WorkerEndHandler(this.oCliente_MostrarVehiculo);
                oCliente.oClosed += new System.EventHandler(this.oCliente_oClosed);
                this.Controls.Add(oCliente);

                oCreditos.Visible = false;
                oCreditos.oClosed += new System.EventHandler(this.oCreditos_oClosed);
                this.Controls.Add(oCreditos);

                oVehiculo.Visible = false;
                oVehiculo.MostrarCredito += new gasolutions.WorkerEndHandler(oVehiculo_MostrarCredito);
                oVehiculo.oClosed += new System.EventHandler(this.oVehiculo_oClosed);
                this.Controls.Add(oVehiculo);

                oRestriccion.Visible = false;
                oRestriccion.oClosed += new System.EventHandler(oRestriccion_oClosed);
                this.Controls.Add(oRestriccion);

                oRecargas.Visible = false;
                oRecargas.oClosed += new System.EventHandler(oRecargas_oClosed);
                this.Controls.Add(oRecargas);

                oKilometraje.Visible = false;
                oKilometraje.oClosed += new System.EventHandler(oKilometraje_oClosed);
                this.Controls.Add(oKilometraje);

                oPrecioCliente.Visible = false;
                oPrecioCliente.oClosed += new System.EventHandler(oPrecioCliente_oClosed);
                this.Controls.Add(oPrecioCliente);

                oRenovarCredito.Visible = false;
                oRenovarCredito.oClosed += new System.EventHandler(this.oRenovarCredito_oClosed);
                this.Controls.Add(oRenovarCredito);

                oTarjeta.Visible = false;
                oTarjeta.oClosed += new System.EventHandler(this.oCreditos_oClosed);
                this.Controls.Add(oTarjeta);

                ValidarUsuario validacion = new ValidarUsuario();
                validacion.ShowDialog();

                if (_UserId == null)
                {
                    // this.Close();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void oCliente_MostrarVehiculo(object sender, EventCliente e)
        {
            OControl = oVehiculo;
            VehiculoEnUso = true;
            oVehiculo.oClosed += new System.EventHandler(this.oVehiculo_oClosed);
            this.Controls.Add(oVehiculo);


            oArray.Add(oVehiculo);
            ControlVisibleenPantalla();
            oVehiculo.Placa = e.iPlaca;
            oVehiculo.IniciarForma();

        }

        private void oCliente_oClosed(object sender, EventArgs e)
        {
            ClienteEnUso = false;
            oArray.Remove(oCliente);
            ControlVisibleenPantalla();
            //IniciarBotones();
        }

        public void oVehiculo_oClosed(object sender, EventArgs e)
        {
            VehiculoEnUso = false;
            oArray.Remove(oVehiculo);
            ControlVisibleenPantalla();
            //IniciarBotones();
        }

        private void oVehiculo_MostrarCredito(object sender, gasolutions.EventVehiculo e)
        {
            //oCreditos = new gsCreditos();
            OControl = oCreditos;
            CreditoEnUso = true;
            oCreditos.oClosed += new System.EventHandler(this.oCreditos_oClosed);
            this.Controls.Add(oCreditos);

            //if (CreditoEnUso == false)
            //{
            oArray.Add(oCreditos);
            ControlVisibleenPantalla();
            oCreditos.Credito = Int32.Parse(e.TheString);
            oCreditos.IniciarForma();
            //   CreditoEnUso = true;
            //}                     

        }


        private void oRestriccion_oClosed(object sender, EventArgs e)
        {
            RestriccionEnUso = false;
            oArray.Remove(oRestriccion);
            ControlVisibleenPantalla();
            //IniciarBotones();

        }

        private void oKilometraje_oClosed(object sender, EventArgs e)
        {
            KilometrajeEnUso = false;
            oArray.Remove(oKilometraje);
            ControlVisibleenPantalla();
            //IniciarBotones();
        }

        void oPrecioCliente_oClosed(object sender, EventArgs e)
        {
            Precio = false;
            oArray.Remove(oPrecioCliente);
            ControlVisibleenPantalla();
            //IniciarBotones();
        }

        private void oCreditos_oClosed(object sender, EventArgs e)
        {
            CreditoEnUso = false;
            oArray.Remove(oCreditos);
            ControlVisibleenPantalla();
            //IniciarBotones();
            //oCreditos = null;
        }

        private void oRenovarCredito_oClosed(object sender, EventArgs e)
        {
            oArray.Remove(oRenovarCredito);
            ControlVisibleenPantalla();
        }

        private void oCreditos_oEventSaldos(object sender, EventCredito e)
        {
            oRecargas.Visible = false;
            oRecargas.oClosed += new System.EventHandler(this.oRecargas_oClosed);
            this.Controls.Add(oRecargas);

            try
            {
                //oInstancia.AbrirVentana(typeof(Facturar));
                if (RecargasEnUso == false)
                {
                    OControl = oRecargas;
                    RecargasEnUso = true;
                    oArray.Add(oRecargas);
                    ControlVisibleenPantalla();
                    oRecargas.Documento = e.Documento;
                    oRecargas.IniciarForma();
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }

        }

        private void oRecargas_oClosed(object sender, EventArgs e)
        {
            RecargasEnUso = false;
            oArray.Remove(oRecargas);
            //ControlVisibleenPantalla();
        }

        private void oTarjeta_oClosed(object sender, EventArgs e)
        {
            oTarjeta.Visible = false;
            oArray.Remove(oTarjeta);
            ControlVisibleenPantalla();
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

        private void btnCliente_Click(object sender, EventArgs e)
        {
            oCliente.Visible = false;
            oCliente.MostrarVehiculo += new PosStation.gsClientes.WorkerEndHandler(this.oCliente_MostrarVehiculo);
            oCliente.oClosed += new System.EventHandler(this.oCliente_oClosed);
            this.Controls.Add(oCliente);

            try
            {
                OControl = oCliente;
                if (ClienteEnUso == false)
                {
                    oArray.Add(oCliente);
                    ControlVisibleenPantalla();
                    oCliente.IniciarForma();

                    ClienteEnUso = true;

                }
                else
                {
                    OControl.Visible = true;
                }
                OcultarBotones();
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void btnVehiculo_Click(object sender, EventArgs e)
        {
            oVehiculo.Visible = false;
            oVehiculo.MostrarCredito += new gasolutions.WorkerEndHandler(oVehiculo_MostrarCredito);
            oVehiculo.oClosed += new System.EventHandler(this.oVehiculo_oClosed);
            this.Controls.Add(oVehiculo);

            try
            {
                OControl = oVehiculo;
                if (VehiculoEnUso == false)
                {
                    oArray.Add(oVehiculo);
                    ControlVisibleenPantalla();
                    oVehiculo.Placa = "";
                    oVehiculo.IniciarForma();
                    VehiculoEnUso = true;
                }
                else
                {
                    OControl.Visible = true;
                }
                OcultarBotones();
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }
        private void btnKilometraje_Click(object sender, EventArgs e)
        {
            oKilometraje.Visible = false;
            oKilometraje.oClosed += new System.EventHandler(oKilometraje_oClosed);
            this.Controls.Add(oKilometraje);

            try
            {
                OControl = oKilometraje;
                if (KilometrajeEnUso == false)
                {
                    KilometrajeEnUso = true;
                    oArray.Add(oKilometraje);
                    ControlVisibleenPantalla();
                    oKilometraje.IniciarForma();

                }
                else
                {
                    OControl.Visible = true;
                }
                OcultarBotones();
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }

        }

        private void btnPrecioCliente_Click(object sender, EventArgs e)
        {
            oPrecioCliente.Visible = false;
            oPrecioCliente.oClosed += new System.EventHandler(oPrecioCliente_oClosed);
            this.Controls.Add(oPrecioCliente);
            try
            {
                OControl = oPrecioCliente;
                if (Precio == false)
                {
                    Precio = true;
                    oArray.Add(oPrecioCliente);
                    ControlVisibleenPantalla();

                }
                else
                {
                    OControl.Visible = true;
                }
                OcultarBotones();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show((ex.Message));

            }

        }

        private void btnRestricciones_Click(object sender, EventArgs e)
        {
            oRestriccion.Visible = false;
            oRestriccion.oClosed += new System.EventHandler(oRestriccion_oClosed);
            this.Controls.Add(oRestriccion);

            try
            {
                OControl = oRestriccion;
                if (RestriccionEnUso == false)
                {
                    RestriccionEnUso = true;
                    oArray.Add(oRestriccion);
                    ControlVisibleenPantalla();
                    oRestriccion.IniciarForma();

                }
                else
                {
                    OControl.Visible = true;
                }
                OcultarBotones();
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void btnCredito_Click(object sender, EventArgs e)
        {
            //oCreditos = new gsCreditos();
            oCreditos.Visible = false;
            oCreditos.oClosed += new System.EventHandler(this.oCreditos_oClosed);
            this.Controls.Add(oCreditos);
            try
            {
                OControl = oCreditos;
                if (CreditoEnUso == false)
                {
                    oArray.Add(oCreditos);
                    ControlVisibleenPantalla();
                    oCreditos.Credito = 0;
                    oCreditos.IniciarForma();
                    //oCreditos.Visible = true;
                    CreditoEnUso = true;

                }
                else
                {
                    OControl.Visible = true;
                }
                OcultarBotones();
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void OcultarBotones()
        {
            btnCliente.Visible = false;
            btnCredito.Visible = false;
            btnKilometraje.Visible = false;
            btnPrecioCliente.Visible = false;
            btnRestricciones.Visible = false;
            btnVehiculo.Visible = false;
            btnRenovarCupo.Visible = false;
            btnTarjetas.Visible = false;
        }
        private void IniciarBotones()
        {
            btnCliente.Visible = true;
            btnCredito.Visible = true;
            btnKilometraje.Visible = true;
            btnPrecioCliente.Visible = true;
            btnRestricciones.Visible = true;
            btnVehiculo.Visible = true;
            btnRenovarCupo.Visible = true;
            btnTarjetas.Visible = true;
        }
        private void AplicarPermisosPorAcciones()
        {
            try
            {
                Helper oHelper = new Helper();

                if (MainForm.UserId.HasValue)
                {
                    btnCliente.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.ABMClientes);
                    btnCredito.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.ABMCreditos);
                    btnKilometraje.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.KilometrajeVentas);
                    btnPrecioCliente.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.PrecioCliente);
                    btnRestricciones.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.RestriccionVehiculos);
                    btnVehiculo.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.ABMVehiculos);
                    btnRenovarCupo.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.RenovarCupoVehiculo);
                    btnTarjetas.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.TarjetasPrepago);
                }
                else
                {
                    MessageBox.Show("El usuario actual no se ha podido autenticar en el sistema");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRenovarCupo_Click(object sender, EventArgs e)
        {
            oRenovarCredito.Visible = false;
            oRenovarCredito.oClosed += new System.EventHandler(this.oRenovarCredito_oClosed);
            this.Controls.Add(oRenovarCredito);
            try
            {
                OControl = oRenovarCredito;
                //if (CreditoEnUso == false)
                //{
                    oArray.Add(oRenovarCredito);
                    ControlVisibleenPantalla();
                    oRenovarCredito.IniciarFormRenovacion();
                    CreditoEnUso = true;
                //}
                //else
                //    OControl.Visible = true;
                
                OcultarBotones();
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void MenuGerenciamiento_Load(object sender, EventArgs e)
        {

        }

        private void btnTarjetas_Click(object sender, EventArgs e)
        {
            oTarjeta.Visible = false;
            oTarjeta.oClosed += new System.EventHandler(oRestriccion_oClosed);
            this.Controls.Add(oTarjeta);

            try
            {
                OControl = oTarjeta;
                if (RestriccionEnUso == false)
                {
                    TarjetaEnUso = true;
                    oArray.Add(oTarjeta);
                    ControlVisibleenPantalla();       

                }
                else
                {
                    OControl.Visible = true;
                }
                OcultarBotones();
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }
    

    }
}
