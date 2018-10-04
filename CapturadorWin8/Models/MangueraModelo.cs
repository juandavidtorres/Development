using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATELITELite.Models
{
    public class MangueraModelo
    {
        public int OID { get; set; }
        public string Nombre { get; set; }

        public int Grado { get; set; }

        public int IdCara { get; set; }

        public override string ToString()
        {
            return Nombre + ":" + Grado;
        }
    }
}
