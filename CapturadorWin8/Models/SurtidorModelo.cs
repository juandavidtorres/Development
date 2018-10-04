using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATELITELite.Models
{
    public class SurtidorModelo
    {
        public int OID { get; set; }
        public string Nombre { get; set; }

        public decimal FactorPrecio { get; set; }

        public decimal FactorTotalizador { get; set; }

        public decimal FactorVolumen { get; set; }

        public decimal FactorImporte { get; set; }

        public decimal MultiplicadorPrecioVenta { get; set; }

       // public List<CaraModelo> Caras { get; set; }

        public int IdLazo { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }

   
}
