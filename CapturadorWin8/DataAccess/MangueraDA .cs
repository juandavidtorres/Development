using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SATELITELite.Models;
using Sqo;

namespace SATELITELite.DataAccess
{
    public static class MangueraDA
    {
        public static async System.Threading.Tasks.Task Guardar(MangueraModelo oItem)
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



        public async static Task<IList<MangueraModelo>> RecuperarManguerasPorCara(int IdCara)
        {
            IList<MangueraModelo> oRespuesta = null;

            Siaqodb siaqodb = await SiaqodbFactoryExample.GetInstance();

            try
            {
                oRespuesta = (from MangueraModelo _registro in siaqodb
                              where _registro.IdCara == IdCara
                              select _registro).ToList<MangueraModelo>();

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

      
    }
}
