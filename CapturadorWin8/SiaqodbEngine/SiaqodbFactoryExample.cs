using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Sqo;
using Windows.Storage;
using System.Threading.Tasks;


namespace SATELITELite
{
    static class SiaqodbFactoryExample
    {
        public static StorageFolder siaoqodbPath;
        private static Siaqodb instance;

      
        public static async Task<Siaqodb> GetInstance()
        {
            try
            {
                if (instance == null)
                {
                    // Sqo.SiaqodbConfigurator.SetLicense(@"put your license key here");
                    siaoqodbPath = ApplicationData.Current.LocalFolder;
                    instance = new Siaqodb();
                    await instance.OpenAsync(siaoqodbPath);

                }
            }
            catch(Exception ex)
            {
                throw;
            }
          
            return instance;
        }
        public static void CloseDatabase()
        {
            if (instance != null)
            {
                instance.Close();
                instance = null;
               
            }
        }
    }
}
