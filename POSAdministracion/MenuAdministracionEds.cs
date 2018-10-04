using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using PosStation.gsEmpleados;
using Controles;
using gasolutions.UInterface;
using PosStation.gsResoluciones;
using gasolutions.gsTipoVehiculos;
using PosStation.gsChips;
using POSstation.Fabrica;


namespace PosStation.MenuAdministracionEds
{

    public partial class MenuAdministracionEds : UserControl
    {

        #region "   Declaracion de Variables    "
        Helper oHelper = new Helper();
        Instancias oInstancia = new Instancias();
        gsEmpleado oEmpleados = new gsEmpleado();
        gsTipoVehiculo oTipoVehiculo = new gsTipoVehiculo();
        gsChip oChips = new gsChip();
        gsResolucion oResolucionCanastilla = new gsResolucion();
        UInterface.PromocionHoraFeliz oPromocion = new UInterface.PromocionHoraFeliz();
        VentasFueraSistemas oVentasFueraDeSistemas = new VentasFueraSistemas();

        public Control OControl = new Control();
        Boolean EmpleadoEnUso;
        Boolean TipoVehiculoEnUso;
        Boolean ChipsEnUso;
        Boolean ResolucionEnUso;
        Boolean PromocionEnUso;
        Boolean VentasFueraDeSistemaEnUso;

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


        public MenuAdministracionEds()
        {
            InitializeComponent();

            oEmpleados.oClosed += new System.EventHandler(this.oEmpleados_oClosed);
            oEmpleados.VisualizarIdentificadores += new PosStation.gsEmpleados.gsEmpleado.WorkerEndHandler(oEmpleados_VisualizarIdentificadores);
            oTipoVehiculo.oClosed += new System.EventHandler(oTipoVehiculo_oClosed);
            oChips.oClosed += new System.EventHandler(this.oChips_oClosed);
            oVentasFueraDeSistemas.oClosed += new System.EventHandler(oVentasFueraDeSistemas_oClosed);
            oResolucionCanastilla.oClosed += new System.EventHandler(oResolucionCanastilla_oClosed);
            oPromocion.EventoCerrar += new System.EventHandler(oPromocion_oClosed);
        }

        public void IniciarForma()
        {
            this.panel1.Controls.Remove(OControl);
            IniciarBotones();
            AplicarPermisosPorAcciones();

        }

        public class EventMenuAdministracionEds : EventArgs
        {
            public readonly string iPlaca;
            public readonly Boolean iEstado;
            public EventMenuAdministracionEds(string s, Boolean Estado)
            {

            }

        }
        public delegate void WorkerEndHandler(object o, EventMenuAdministracionEds e);

        public event EventHandler oClosed;


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            oClosed(sender, e);
        }

        private void MenuAdministracionEdsInicio(object sender, EventArgs e)
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

                oEmpleados.Visible = false;
                this.panel1.Controls.Add(oEmpleados);

                oTipoVehiculo.Visible = false;
                this.panel1.Controls.Add(oTipoVehiculo);

                oChips.Visible = false;
                this.panel1.Controls.Add(oChips);

                oResolucionCanastilla.Visible = false;
                this.panel1.Controls.Add(oResolucionCanastilla);


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

        private void oEmpleados_VisualizarIdentificadores(object o, EventIdentificador e)
        {
            try
            {
                frmIdentificador ofrmIdentificador = new frmIdentificador();
                ofrmIdentificador.IdEmpleado = e.IdEmpleado;
                ofrmIdentificador.StartPosition = FormStartPosition.CenterScreen;
                ofrmIdentificador.ShowDialog();
                ofrmIdentificador.Dispose();
                ofrmIdentificador = null;
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void oEmpleados_oClosed(object sender, EventArgs e)
        {

            EmpleadoEnUso = false;
            oArray.Remove(oEmpleados);
            ControlVisibleenPantalla();
        }

        void oPromocion_oClosed(object sender, EventArgs e)
        {
            PromocionEnUso = false;
            oArray.Remove(oPromocion);
            ControlVisibleenPantalla();
        }

        void oVentasFueraDeSistemas_oClosed(object sender, EventArgs e)
        {
            VentasFueraDeSistemaEnUso = false;
            oArray.Remove(oVentasFueraDeSistemas);
            ControlVisibleenPantalla();
        }
        void oTipoVehiculo_oClosed(object sender, EventArgs e)
        {
            TipoVehiculoEnUso = false;
            oArray.Remove(oTipoVehiculo);
            ControlVisibleenPantalla();
        }

        private void oChips_oClosed(object sender, EventArgs e)
        {
            ChipsEnUso = false;
            oArray.Remove(oChips);
            ControlVisibleenPantalla();
        }

        private void oResolucionCanastilla_oClosed(object sender, EventArgs e)
        {
            ResolucionEnUso = false;
            oArray.Remove(oResolucionCanastilla);
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

        private void RecuperarDatosBasicos(Helper oHelper)
        {
            try
            {
                //InformacionEstacion oEstacion = oHelper.RecuperarDatosEstacion();

                // this.datosGenerales1.Codigo = oEstacion.Codigo;
                // this.datosGenerales1.Nombre = oEstacion.Nombre;
                // this.datosGenerales1.Nit = oEstacion.Nit;
                // this.datosGenerales1.Direccion = oEstacion.Direccion;
                // this.datosGenerales1.Telefono = oEstacion.Telefono;
                // this.datosGenerales1.Ciudad = oEstacion.Ciudad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            oEmpleados.Visible = false;


            this.panel1.Controls.Add(oEmpleados);

            try
            {
                OControl = oEmpleados;
                if (EmpleadoEnUso == false)
                {

                    oArray.Add(oEmpleados);
                    oEmpleados.IniciarForma();
                    ControlVisibleenPantalla();
                    EmpleadoEnUso = true;
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

        private void btnTipoVehiculo_Click(object sender, EventArgs e)
        {
            oTipoVehiculo.Visible = false;
            this.panel1.Controls.Add(oTipoVehiculo);

            try
            {
                OControl = oTipoVehiculo;
                if (TipoVehiculoEnUso == false)
                {

                    TipoVehiculoEnUso = true;
                    oTipoVehiculo.IniciarForma();
                    oArray.Add(oTipoVehiculo);
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

        private void btnIdentificador_Click(object sender, EventArgs e)
        {
            oChips.Visible = false;
            this.panel1.Controls.Add(oChips);

            try
            {
                OControl = oChips;
                if (ChipsEnUso == false)
                {
                    OControl = oChips;
                    oArray.Add(oChips);
                    oChips.IniciarControl();
                    ControlVisibleenPantalla();
                    ChipsEnUso = true;

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

        private void btnResoluciones_Click(object sender, EventArgs e)
        {
            oResolucionCanastilla.Visible = false;
            this.panel1.Controls.Add(oResolucionCanastilla);

            try
            {
                OControl = oResolucionCanastilla;
                if (ResolucionEnUso == false)
                {

                    ResolucionEnUso = true;
                    oArray.Add(oResolucionCanastilla);
                    ControlVisibleenPantalla();
                    oResolucionCanastilla.IniciarForma();

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

        private void IniciarBotones()
        {

            btnEmpleado.Visible = true;
            btnIdentificador.Visible = true;
            btnResoluciones.Visible = true;
            btnTipoVehiculo.Visible = true;
            btnPromocionHoraFeliz.Visible = true;
            btnVentasFueraDeSistema.Visible = true;
        }

        private void AplicarPermisosPorAcciones()
        {
            try
            {
                Helper oHelper = new Helper();

                if (MainForm.UserId.HasValue)
                {
                    btnEmpleado.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.ABMEmpleados);
                    btnIdentificador.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.InactivacionChips);
                    btnResoluciones.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.ResolucionesFacturacion);
                    btnTipoVehiculo.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.TiposVehiculo);
                    btnPromocionHoraFeliz.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.PromocionHoraFeliz);
                    btnVentasFueraDeSistema.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.VentasFueraSistema);

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




        private void OcultarBotones()
        {
            btnEmpleado.Visible = false;
            btnIdentificador.Visible = false;
            btnResoluciones.Visible = false;
            btnTipoVehiculo.Visible = false;
            btnPromocionHoraFeliz.Visible = false;
            btnVentasFueraDeSistema.Visible = false;
        }

        private void btnPromocionHoraFeliz_Click(object sender, EventArgs e)
        {
            oPromocion.Visible = false;
            this.panel1.Controls.Add(oPromocion);

            try
            {
                OControl = oPromocion;
                if (PromocionEnUso == false)
                {

                    PromocionEnUso = true;
                    oPromocion.IniciarForma();
                    oArray.Add(oPromocion);
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

        private void btnVentasFueraDeSistema_Click(object sender, EventArgs e)
        {
            oVentasFueraDeSistemas.Visible = false;
            this.panel1.Controls.Add(oVentasFueraDeSistemas);

            try
            {
                OControl = oVentasFueraDeSistemas;
                if (VentasFueraDeSistemaEnUso == false)
                {

                    VentasFueraDeSistemaEnUso = true;
                    //oVentasFueraDeSistemas.IniciarForma();
                    oArray.Add(oVentasFueraDeSistemas);
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
