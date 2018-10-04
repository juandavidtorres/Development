using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using POSstation.Fabrica;
using POSstation.ServerServices;


namespace PosConfiguracion
{
    public partial class Bonos : UserControl
    {
        public Bonos()
        {
            InitializeComponent();
        }

        private void Bonos_Load(object sender, EventArgs e)
        {
            RecuperarBonos();
        }

        public void RecuperarBonos()
        {
            try
            {
                Helper oHelper = new Helper();
                grdCOnsultaBonos.DataSource = oHelper.RecuperarBonosLocales().Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Helper OHelper = new Helper();

            POSstation.Fabrica.RespuestaBonoFidelizacion ORespuestaFidelizacion = new RespuestaBonoFidelizacion();
            try
            {
                try
                {
                    ORespuestaFidelizacion = POSstation.ServerServices.ServicioFidelizacion.ConsultarBonosDisponibles();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (!string.IsNullOrEmpty(ORespuestaFidelizacion.MensajeError.Trim()))
                {
                    throw new Exception(ORespuestaFidelizacion.MensajeError.Trim());
                }
                else
                {
                    OHelper.InactivarBono();
                    if (ORespuestaFidelizacion.BonoFidelizacion != null)
                    {
                        if (ORespuestaFidelizacion.BonoFidelizacion.Count > 0)
                        {
                            foreach (POSstation.Fabrica.BonosFidelizacion oBono in ORespuestaFidelizacion.BonoFidelizacion) {
                                OHelper.InsertarBono(oBono.IdPremio, oBono.Nombre, oBono.Tipo, oBono.Puntos, oBono.Valor);
                            }
                        }
                        else
                            throw new Exception("No hay bonos configurados o no poseen inventario");
                    }
                    else
                        throw new Exception("No hay bonos configurados o no poseen inventario");

                }

                RecuperarBonos();
                MessageBox.Show("BONOS RECUPERADOS SATISFACTORIAMENTE","Notificacion- Bonos Fidelizacion",MessageBoxButtons.OK);
            

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
