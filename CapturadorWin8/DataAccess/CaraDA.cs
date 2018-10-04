using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SATELITELite.Models;
using Sqo;

namespace SATELITELite.DataAccess
{
    public static class CaraDA
    {
        public static async System.Threading.Tasks.Task Guardar(CaraModelo oItem)
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
       
        public async static Task<IList<CaraModelo>> RecuperarCarasPorSurtidor(int IdSurtidor)
        {
            IList<CaraModelo> oRespuesta = null;

            Siaqodb siaqodb = await SiaqodbFactoryExample.GetInstance();

            try
            {
                oRespuesta = (from CaraModelo _registro in siaqodb
                              where _registro.IdSurtidor == IdSurtidor
                              select _registro).ToList<CaraModelo>();

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

        public async static Task<IList<object>> RecuperarCarasPorLazo(int IdLazo)
        {
            IList<object> oRespuesta = null;

            Siaqodb siaqodb = await SiaqodbFactoryExample.GetInstance();

            try
            {
                oRespuesta = (from CaraModelo c in siaqodb
                              join SurtidorModelo s in siaqodb on
                              c.IdSurtidor equals s.OID
                              join LazoModelo l in siaqodb on
                              s.IdLazo equals l.OID
                              where l.OID == IdLazo
                              select new { c.OID, c.Alias, c.IdSurtidor, s.FactorPrecio, s.FactorTotalizador, s.FactorVolumen, s.FactorImporte, s.MultiplicadorPrecioVenta }).ToList<object>();

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

        public async static Task<IList<object>> RecuperarCaras()
        {

            IList<object> oRespuesta = null;

            Siaqodb siaqodb = await SiaqodbFactoryExample.GetInstance();

            try
            {
                oRespuesta = (from CaraModelo c in siaqodb                                    
                                  join SurtidorModelo s in siaqodb
                                     on c.IdSurtidor equals s.OID
                                  select new { c.OID, c.Alias, c.IdSurtidor, s.FactorPrecio, s.FactorTotalizador, s.FactorVolumen, s.FactorImporte, s.MultiplicadorPrecioVenta }).ToList<object>();
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
