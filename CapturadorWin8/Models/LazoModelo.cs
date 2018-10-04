using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATELITELite.Models
{
   public class LazoModelo
    {
        public int OID { get; set; }

        public string Nombre { get; set; }

        public string Url { get; set; }

        public string Puerto { get; set; }

        //public ProtocoloModelo protocolo{ get; set; }
        public int IdProtocolo { get; set; }

        //public List<SurtidorModelo> Surtidores { get; set; }
        public override string ToString()
        {
            return Url + " " + Puerto + ":" + Nombre;
        }
    }
}
