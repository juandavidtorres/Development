using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SATELITELite.Models;
using Sqo;

namespace SATELITELite.DataAccess
{
    public static class LazoDA
    {
        public async static Task<IList<LazoModelo>> RecuperarLazos()
        {
            try
            {
                Siaqodb siaqodb = await SiaqodbFactoryExample.GetInstance();
                IList<LazoModelo> objects = await siaqodb.LoadAllAsync<LazoModelo>();

                return objects;
            }
            catch 
            {                
                throw;
            }            
        }
        public static async System.Threading.Tasks.Task Agregar(string nombre, string puerto, string url, int protocol)
        {
            try
            {
                Siaqodb siaqodb = await SiaqodbFactoryExample.GetInstance();

                LazoModelo oLazo = new LazoModelo();
                oLazo.Nombre = nombre;
                oLazo.IdProtocolo = protocol;
                oLazo.Puerto = puerto;
                oLazo.Url = url;
                await siaqodb.StoreObjectAsync(oLazo);

                await siaqodb.FlushAsync();
            }
            catch
            {
                throw;
            }
        }

        public static async System.Threading.Tasks.Task Agregar(LazoModelo oLazo)
        {
            try
            {
                Siaqodb siaqodb = await SiaqodbFactoryExample.GetInstance();
             
                await siaqodb.StoreObjectAsync(oLazo);

                await siaqodb.FlushAsync();
            }
            catch
            {
                throw;
            }
        }

       
    }



}
