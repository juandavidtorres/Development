using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSstation.Notificacion
{
    public class NotificacionMensaje
    {
        public NotificacionMensaje() { }

        public static void MostrarNotificacion(string mensaje, bool EsError, int TiempoVisualizacion)
        {
            try
            {
                POSstation.Notificacion.Notification FrmMensaje = new Notificacion.Notification();
                FrmMensaje.Mensaje = mensaje;
                FrmMensaje.EsError = EsError;
                FrmMensaje.TimerTiempo = TiempoVisualizacion;
                FrmMensaje.Show();

            }
            catch (Exception ex)
            {

                MostrarNotificacion(ex.Message, true, 3000);
            }

        }

    }
}
