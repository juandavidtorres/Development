using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SATELITELite.DataAccess;

namespace SATELITELite.Models
{
    class ProtocoloLista
    {
        private ObservableCollection<ProtocoloModelo> _listaItems= new ObservableCollection<ProtocoloModelo>();

        public ObservableCollection<ProtocoloModelo> ListaItems
        {
            get { return _listaItems; }
            set { _listaItems = value; }
        }
                
        public ProtocoloLista()
        {
            Initialize();
        }

        public async void Initialize()
        {
            try
            {
                if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                {
                    //En tiempo de diseño muestro informacion de ejemplo
                    for (int J = 0; J < 5; J++)
                    {
                        ProtocoloModelo oItem = new ProtocoloModelo();
                        oItem.Nombre = "Protocolo " + (J+1).ToString();

                        _listaItems.Add(oItem);
                    }                    
                }
                else
                {
                    var lista = await ProtocoloDA.RecuperarProtocolos();

                    for (int I = 0; I < lista.Count(); I++)
                    {
                        _listaItems.Add(lista[I]);
                    }
                }
            }
            catch
            {
                throw;
            }                       
        }
    }

    public class Mensaje
    {
        public string Texto { get; set; }
    }

    class SurtidorMensajes
    {
        private ObservableCollection<Mensaje> _listaItems = new ObservableCollection<Mensaje>();

        public ObservableCollection<Mensaje> ListaItems
        {
            get { return _listaItems; }
            set { _listaItems = value; }
        }

        public SurtidorMensajes()
        {
            Initialize();
        }

        public void Initialize()
        {
            try
            {
                if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                {
                    //En tiempo de diseño muestro informacion de ejemplo
                    for (int J = 0; J < 5; J++)
                    {
                        Agregar("Ejemplo " + (J + 1).ToString());
                        
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void Agregar(string mensaje)
        {
            Mensaje oItem = new Mensaje();
            oItem.Texto = mensaje;
            _listaItems.Add(oItem);
            _listaItems.Insert(0, oItem);
            //if (_listaItems.Count() >20)
            //{
            //    _listaItems.RemoveAt(0);
            //}
        }
    }
}
