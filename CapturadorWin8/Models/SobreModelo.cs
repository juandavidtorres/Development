using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATELITELite.Models
{
    public class SobreModelo
    {
        public int tipo { get; set; }
        public string Nombre { get; set; }

        public string Valor { get; set; }

        public SobreModelo(int tipo, string nombre, string valor)
        {
            this.tipo= tipo;
            this.Nombre = nombre;
            this.Valor = valor;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }

   
}
