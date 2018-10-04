using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SATELITELite.Models;
using Sqo;

namespace SATELITELite.DataAccess
{
    public static class ProtocoloDA
    {
        public async static Task<IList<ProtocoloModelo>> RecuperarProtocolos()
        {

            Siaqodb siaqodb = await SiaqodbFactoryExample.GetInstance();
            IList<ProtocoloModelo> objects = await siaqodb.LoadAllAsync<ProtocoloModelo>();
            
            return objects;
        }

        public async static Task<ProtocoloModelo> RecuperarProtocolo(int Id)
        {
            Siaqodb siaqodb = await SiaqodbFactoryExample.GetInstance();
            ProtocoloModelo single = null;
            try
            {               
                single = (from ProtocoloModelo emp in siaqodb
                                    where emp.OID == Id
                                    select emp).Single();                                
            }
            catch (InvalidOperationException ex)
            {
                
            } 
            catch
            {
                throw;
            }
            return single;
        }

        public static async System.Threading.Tasks.Task Agregar(string nombre)
        {
            try
            {
                Siaqodb siaqodb = await SiaqodbFactoryExample.GetInstance();

                ProtocoloModelo oItem = new ProtocoloModelo();
                oItem.Nombre = nombre;
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
