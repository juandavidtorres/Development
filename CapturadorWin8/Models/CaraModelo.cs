using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATELITELite.Models
{
   public class CaraModelo
    {
        public int OID { get; set; }
        public string Nombre { get; set; }

        public int Alias { get; set; }

       // public List<MangueraModelo> Mangueras { get; set; }

        public int IdSurtidor { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }

   
}
