using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SATELITELite.Models;
using Sqo;

namespace SATELITELite.DataAccess
{
    public static class SurtidorDA
    {      
        public async static Task<IList<SurtidorModelo>> RecuperarSurtidoresPorLazo(int idLazo)
        {
            IList<SurtidorModelo> oRespuesta = null;

            Siaqodb siaqodb = await SiaqodbFactoryExample.GetInstance();      

            try
            {
                 oRespuesta = (from SurtidorModelo _registro in siaqodb
                           where _registro.IdLazo == idLazo
                               select _registro).ToList<SurtidorModelo>();

            }
            catch (InvalidOperationException ex)
            {

            }
            catch
            {
                throw;
            }
          
            return oRespuesta;
                       
        }

        //public static async System.Threading.Tasks.Task Agregar(string nombre, string puerto, string url, ProtocoloModelo protocol)
        //{
        //    try
        //    {
        //        Siaqodb siaqodb = await SiaqodbFactoryExample.GetInstance();

        //        LazoModelo oLazo = new LazoModelo();
        //        oLazo.Nombre = nombre;
        //        oLazo.protocolo = protocol;
        //        oLazo.Puerto = puerto;
        //        oLazo.Url = url;
        //        await siaqodb.StoreObjectAsync(oLazo);

        //        await siaqodb.FlushAsync();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //Si es nuevo lo agrega, si ya existe lo actualiza
        public static async System.Threading.Tasks.Task Guardar(SurtidorModelo oItem)
        {
            try
            {
                Siaqodb siaqodb = await SiaqodbFactoryExample.GetInstance();
             
                await siaqodb.StoreObjectAsync(oItem);

                await siaqodb.FlushAsync();
            }
            catch
            {
                throw;
            }
        }
    }



}
