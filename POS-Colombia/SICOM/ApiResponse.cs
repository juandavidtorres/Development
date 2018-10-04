//Development by Kelmer Ashley Comas Cardona © 2018

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SICOM
{

    public static class ApiResponse
    {

        #region "Clases de Respuestas a peticiones Http SICOM"

        [DataContract]
        public class Respuesta
        {
            //Respusta SICOM
            [DataMember(Name = "id")]
            public string IdSICOM { get; set; }

            [DataMember(Name = "fecha")]
            public string FechaSICOM { get; set; }

            [DataMember(Name = "texto")]
            public string MensajeSICOM { get; set; }

            [DataMember(Name = "estado")]
            public string EstadoSICOM { get; set; }


            //Respusta GENERICA
            [DataMember(Name = "timestamp")]
            public string Fecha { get; set; }

            [DataMember(Name = "error")]
            public string Error { get; set; }

            [DataMember(Name = "message")]
            public string Mensaje { get; set; }

            [DataMember(Name = "status")]
            public string Estado { get; set; }
        }

        [DataContract]
        public class VentaSicom
        {
            [DataMember(Name = "fecha")]
            public string fecha { get; set; }

            [DataMember(Name = "volumen")]
            public string volumen { get; set; }
        }


        public class RespuestaVentaSicom
        {
            public string id { get; set; }
            public string fecha { get; set; }
            public int estado { get; set; }
            public string texto { get; set; }
        }

        [DataContract]
        public class DatosChip : Respuesta
        {
            [DataMember(Name = "idrom")]
            public string ROM { get; set; }

            [DataMember(Name = "fecha_inicio")]
            public string FechaConversion { get; set; }

            [DataMember(Name = "fecha_fin")]
            public string FechaProximoMantenimiento { get; set; }

            [DataMember(Name = "placa")]
            public string Placa { get; set; }

            [DataMember(Name = "vin")]
            public string Vin { get; set; }

            [DataMember(Name = "servicio")]
            public string Servicio { get; set; }

            [DataMember(Name = "capacidad")]
            public double Capacidad { get; set; }

            [DataMember(Name = "motivo")]
            public string Motivo { get; set; }

            [DataMember(Name = "motivo_texto")]
            public string MotivoTexto { get; set; }

        }


        #endregion

    }
}
