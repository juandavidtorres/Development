using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATELITELite.Models
{
    public class TanqueModelo
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public string Altura { get; set; }

        public TanqueModelo(string cod, string nom, string alt) {
            Codigo = cod;
            Nombre = nom;
            Altura = alt;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }

   
}
