using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SATELITELite.Models
{
    public class ProtocoloModelo: BindableBase
    {
        private int _oid;

        public int OID
        {
            get { return _oid; }
            set
            {
                SetProperty(ref _oid, value);
            }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                SetProperty(ref _nombre, value);
            }
        }                

        public override string ToString()
        {
            return Nombre;
        }

    }
}
