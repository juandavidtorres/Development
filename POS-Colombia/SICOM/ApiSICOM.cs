//Development by Kelmer Ashley Comas Cardona © 2018

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using POSstation.AccesoDatos;
using Generic;


namespace SICOM
{
    public static class ApiSICOM
    {
        private static  SqlServer _Helper = new SqlServer();
        

        private static Dictionary<int, string> Errors = new Dictionary<int, string>
        {
            {0, "El comando '{0}' no es valido" },
            {1, "El numero de parametros ({0}) para el comando '{1}' no es valido" },
            {2, "Error ({0}): {1} {2}" },
        };

        #region "metodos de utilidad SICOM"


        public static Dictionary<string, string> GetHeaders()
        {
            return new Dictionary<string, string>()
                    {
                        { "APIKey", GetApiKey() },
                        { "Authorization", GetApiAuthorization() },
                        { "Accept", GetAcceptRequest() },
                        { "Cache-control", "no-cache" }
                    };
        }
        public static string GetCommand(string commandName, params object[] parameters)
        {
            try
            {
                string command = @_Helper.RecuperarOperacionSICOMPorNombre(commandName);

                if (String.IsNullOrEmpty(command))
                    throw new Exception(String.Format(Errors[0], commandName));

                try
                {
                    foreach (var param in parameters)
                        command = String.Format(command, param);
                }
                catch
                {
                    string xparams = String.Join(", ", parameters);
                    throw new Exception(String.Format(Errors[1], xparams, commandName));
                } 

                return command;
            }
            catch { throw; }
        }

        internal static string ExecuteApiCommand(string command, string Body, params object[] parameters)
        {
            try
            {
                string url = ApiSICOM.GetUrlBase();
                string cmd = ApiSICOM.GetCommand(command, parameters);  
                string methodHttp = ApiSICOM.GetMethodHttp(command);
                string contentType = ApiSICOM.GetAcceptRequest();
                string userAgent = null;
                string user = null;
                string password = null;
                int? timeOut = null;
                Dictionary<string, string> headers = ApiSICOM.GetHeaders();
                Dictionary<string, string> cookies = null;                

                return ApiRESTService.GetResponse(url, cmd, user, password, timeOut,
                                                  contentType, headers, cookies, userAgent,  methodHttp,Body);
            }
            catch { throw; }
        }

        public static string GetMethodHttp(string operacion)
        {
            return _Helper.RecuperarMetodoHttpPorOperacion(operacion);
        }

        public static string GetUrlBase()
        {
            return @_Helper.RecuperarParametro("UrlSicom");
        }
        
        public static string GetApiKey()
        {
           return  _Helper.RecuperarParametro("ApiKeySicom");
        }

        public static string GetUser()
        {
            return _Helper.RecuperarParametro("UsuarioSicom");
        }

        public static string GetPassword()
        {
            return _Helper.RecuperarParametro("ClaveSicom");
        }

        public static bool AplicaSICOM()
        {
            try {  return Convert.ToBoolean(_Helper.RecuperarParametro("AplicaSicom")); }
            catch { return false; }
        }

        public static string GetApiAuthorization()
        {
            try
            {
                string user = _Helper.RecuperarParametro("UsuarioSicom");
                string password = _Helper.RecuperarParametro("ClaveSicom");
                string key = String.Format("{0}:{1}", user, password);

                return "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(key));
            }
            catch { throw; }
        }

        public static string GetAcceptRequest()
        {
            return @"application/json";
        }

        internal static void ThrowExceptionApi(ApiResponse.Respuesta response)
        {
            if (!String.IsNullOrEmpty(response.Error))
                throw new Exception(String.Format(Errors[2], response.Estado, response.Error, response.Mensaje));
            else if (response.EstadoSICOM.Equals("1"))
            {
                string mensaje = ((ApiResponse.DatosChip)response).MotivoTexto ?? response.MensajeSICOM;
                throw new Exception(String.Format(Errors[2], response.EstadoSICOM, "", mensaje));
            }
            else if (!response.EstadoSICOM.Equals("0"))
                throw new Exception(String.Format(Errors[2], response.EstadoSICOM, "", response.MensajeSICOM));    
        }


        #endregion


    }
}
