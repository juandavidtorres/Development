using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using POSstation.Fabrica;
using System.Threading;

namespace PosConfiguracion
{
    public partial class frmMain : Form
    {
        Visualizacion ctlVisualizacion = new Visualizacion();

        OtrosConfig ctlOtros = null;
        public static Nullable<Guid> _UserId = null;

        public static Nullable<Guid> UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        gsProducto oProducto;

        private void frmMain_Load(object sender, EventArgs e)
        {
           // Helper oHelper = new Helper();
           // InformacionEstacion oEstacion = oHelper.RecuperarDatosEstacion();

            //ctlDatosGenerales.Codigo = oEstacion.Codigo;
            //ctlDatosGenerales.Nombre = oEstacion.Nombre;
            //ctlDatosGenerales.Nit = oEstacion.Nit;
            //ctlDatosGenerales.Direccion  = oEstacion.Direccion ;
            //ctlDatosGenerales.Telefono = oEstacion.Telefono;
            //ctlDatosGenerales.Ciudad = oEstacion.Ciudad;

            AplicarPermisosPorAcciones();
        }

        private void AplicarPermisosPorAcciones()
        {
            try
            {
                Helper oHelper = new Helper();

                if (_UserId.HasValue)
                {
                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionLectores))
                    {
                        this.fsConfigColombia1.Lectores = false;
                    }

                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionEstacion))
                    {
                        this.fsConfigColombia1.Config = false;
                    }

                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionUnidadesMedida))
                    {
                        this.fsConfigColombia1.Unidad = false;
                    }

                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionSobreTasa))
                    {
                        this.fsConfigColombia1.Sobretasa = false;
                    }

                    if (!oHelper.ValidarPermisosPorAccion(_UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionTarjetasPrepago))
                    {
                        this.fsConfigColombia1.Tarjeta = false;
                    }
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

     

        void ctlOtros_MostrarProductos(object sender, EventArgs e)
        {
            try
            {
                this.pnlContenedor.Controls.Clear();
                oProducto = new gsProducto();
                oProducto.oClosed += new EventHandler(oProducto_oClosed);
                this.pnlContenedor.Controls.Add(oProducto);
                oProducto.iniciarForma();
                oProducto = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }

        void oProducto_oClosed(object sender, EventArgs e)
        {
            this.pnlContenedor.Controls.Clear();
        }

        private void ctlVisualizacion_Mostrar_Configuracion(object sender, EventArgs e)
        {
            fsConfigColombia1_ConfigEvent(sender, e);
        }

        private void fsConfigColombia1_SalirEvent(object sender, EventArgs e)
        {
            this.pnlContenedor.Controls.Clear();
            this.Close();
            this.Dispose();
            Application.Exit();
        }

        private void fsConfigColombia1_OtrosEvent(object sender, EventArgs e)
        {
            if (ctlOtros != null)
            {
                if (this.ctlOtros.grdHistoricoPrecio.IsCurrentCellInEditMode)
                {
                    this.ctlOtros.grdHistoricoPrecio.CancelEdit();
                    return;
                }

                if (this.ctlOtros.grdHorarios.IsCurrentCellInEditMode)
                {
                    this.ctlOtros.grdHorarios.CancelEdit();
                    return;
                }

            }

            this.pnlContenedor.Controls.Clear();
            ctlOtros = new OtrosConfig();
            ctlOtros.MostrarProductos += new EventHandler(ctlOtros_MostrarProductos);
            this.pnlContenedor.Controls.Add(ctlOtros);
            ctlOtros.CargarDatos();
          
        }

        private void fsConfigColombia1_LectoresEvent(object sender, EventArgs e)
        {
            this.pnlContenedor.Controls.Clear();
            Lectores ctlLectores = new Lectores();
            this.pnlContenedor.Controls.Add(ctlLectores);
            ctlLectores.CargaDatosLectores();
            ctlLectores = null;
            
        }

        private void fsConfigColombia1_ConfigEvent(object sender, EventArgs e)
        {
            this.pnlContenedor.Controls.Clear();
            Configuracion ctlConfiguracion = new Configuracion();
            this.pnlContenedor.Controls.Add(ctlConfiguracion);
            ctlConfiguracion.CargaDatosControl();
            ctlConfiguracion = null;
            
        }

        private void fsConfigColombia1_EstacionEvent(object sender, EventArgs e)
        {
            this.pnlContenedor.Controls.Clear();
            if (ctlVisualizacion==null)
            {

                ctlVisualizacion = new Visualizacion();
            }
            this.pnlContenedor.Controls.Add(ctlVisualizacion);
            ctlVisualizacion.IniciarControl();
            ctlVisualizacion.Mostrar_Configuracion += new EventHandler(ctlVisualizacion_Mostrar_Configuracion);
            ctlVisualizacion.MensajeBoton = "Abrir Ventana de Configuración";
            ctlVisualizacion = null;
            
        }

        private void fsConfigColombia1_LiquidoEvent(object sender, EventArgs e)
        {
            this.pnlContenedor.Controls.Clear();
            gsConfiguraLiquido ctlLiquido = new gsConfiguraLiquido();
            this.pnlContenedor.Controls.Add(ctlLiquido);
            ctlLiquido.IniciarForma();
            //ctlVisualizacion.Mostrar_Configuracion += new EventHandler(ctlVisualizacion_Mostrar_Configuracion);
            //ctlVisualizacion.MensajeBoton = "Abrir Ventana de Configuración";
            ctlVisualizacion = null;
            
        }

        private void fsConfigColombia1_UnidadEvent(object sender, EventArgs e)
        {
            this.pnlContenedor.Controls.Clear();
            gsUnidadMedida ctlUnidadMedida = new gsUnidadMedida();
            this.pnlContenedor.Controls.Add(ctlUnidadMedida);
            ctlUnidadMedida.IniciarForma();
            ctlUnidadMedida = null;
        }

        private void fsConfigColombia1_SobretasaEvent(object sender, EventArgs e)
        {
            this.pnlContenedor.Controls.Clear();
            SobreTasa ctlSobretasa = new SobreTasa();
            this.pnlContenedor.Controls.Add(ctlSobretasa);
            ctlSobretasa.IniciarForma();
        }

        private void fsConfigColombia1_TarjetaEvent(object sender, EventArgs e)
        {
            this.pnlContenedor.Controls.Clear();
            gsTarjeta ctlTarjeta = new gsTarjeta();
            this.pnlContenedor.Controls.Add(ctlTarjeta);
            ctlTarjeta = null;
        }

        private void fsConfigColombia1_FormaPagoEvent(object sender, EventArgs e)
        {
            this.pnlContenedor.Controls.Clear();
            gsFormaPago ctlFormaPago = new gsFormaPago();
            this.pnlContenedor.Controls.Add(ctlFormaPago);
            ctlFormaPago.CargarDatos();
            ctlFormaPago = null;
        }

        private void fsConfigColombia1_BonosEvent(object sender, EventArgs e)
        {
            this.pnlContenedor.Controls.Clear();
            Bonos ctlBonos = new Bonos();
            this.pnlContenedor.Controls.Add(ctlBonos);            
            ctlBonos = null;
        }

      

    

       
    }
}