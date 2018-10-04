//Development by Kelmer Ashley Comas Cardona © 2018

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

using JSONSerializer;
using Generic;
using POSstation.AccesoDatos;
using System.Data;
using POSstation.Fabrica;

namespace SICOM
{
    public class RestApiInvoke
    {

        #region "Operaciones para consumir del servicio SICOM"

        public static ApiResponse.DatosChip GetDataChip(string ROM)
        {
            PropiedadesExtendidas LogPropiedades = new PropiedadesExtendidas();
            CategoriasLog LogCategorias = new CategoriasLog();
            try
            {
                ApiResponse.DatosChip response = null;              
                LogCategorias.Clear();
                LogCategorias.Agregar("SICOM");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", "Antes de enviar la consulta");
                LogPropiedades.Agregar("ROM ENVIADO", ROM);             
                LogPropiedades.Agregar("Fecha", DateTime.Now.ToString());
                POSstation.Fabrica.LogIt.Loguear("Envio de consulta de chip sicom", LogPropiedades, LogCategorias);

                string json = ApiSICOM.ExecuteApiCommand("ConsultarChip","", ROM);


                LogCategorias.Clear();
                LogCategorias.Agregar("SICOM");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", "Despues de enviar la consulta");
                LogPropiedades.Agregar("JSON RECIBIDO", json);
                LogPropiedades.Agregar("Fecha", DateTime.Now.ToString());
                POSstation.Fabrica.LogIt.Loguear("Respuesta de consulta de chip sicom", LogPropiedades, LogCategorias);

                response = JSON.Deserialize<ApiResponse.DatosChip>(json);

                ApiSICOM.ThrowExceptionApi(response);

                return response;
            }
            catch { throw; }
        }

        public static ApiResponse.RespuestaVentaSicom EnviarVenta(string Recibo)
        {
            try
            {
                ApiResponse.RespuestaVentaSicom response = null;
                SqlServer _Helper = new SqlServer();
                string[] data = new string[2];
                string Fecha = "";
                string Rom = "";
                string Cantidad = "";
                bool EsGnv = false;

                IDataReader oLector = _Helper.RecuperarVenta(Convert.ToInt64(Recibo), true);
                while (oLector.Read()){
                   Fecha = oLector["FechaSicom"].ToString();
                   Cantidad = oLector["Cantidad"].ToString().Replace(",",".");
                   Rom = oLector["Rom"].ToString();
                   EsGnv = _Helper.EsLecturaChipObligatoria(Convert.ToInt32(oLector["IdProducto"].ToString()));
                }
                oLector.Close();

                if ((EsGnv) && (!string.IsNullOrEmpty(Rom)))
                {
                    ApiResponse.VentaSicom venta = new ApiResponse.VentaSicom();
                    venta.fecha = Fecha;
                    venta.volumen = Cantidad;
                    string Json = "";
                    Json = JSON.Serialize<ApiResponse.VentaSicom>(venta);
                    string json = ApiSICOM.ExecuteApiCommand("EnviarVenta", Json, Rom);
                    response = JSON.Deserialize<ApiResponse.RespuestaVentaSicom>(json);

                }else
                {

                    response = new ApiResponse.RespuestaVentaSicom();
                    response.estado = 0;
                    response.texto = "Venta de combustible liquido";
                }

                return response;
            }
            catch { throw; }
        }


        public static string DownloadCertificate(string path)
        {
            try
            {
                string content = String.Empty;
                ApiResponse.Respuesta response = null;

                string json = ApiSICOM.ExecuteApiCommand("DescargarCertificado","","");

                if (JSON.IsDeserializable<ApiResponse.Respuesta>(json))
                {
                    response = JSON.Deserialize<ApiResponse.Respuesta>(json);
                    ApiSICOM.ThrowExceptionApi(response);
                }
                else
                {
                    content = json;
                    string pathfolder = String.Empty;

                    if (!String.IsNullOrEmpty(path))
                    {
                        pathfolder = Util.GetFolderPath(path);
                        string file = Util.GetFileName(path).Replace(pathfolder, "");

                        if (String.IsNullOrEmpty(file))
                            file = String.Format("Certificado{0}.csv", DateTime.Now.ToString("yyyyMMddHHmmss"));

                        if (!Directory.Exists(pathfolder))
                             Directory.CreateDirectory(pathfolder);

                        pathfolder += @"\" + file;

                        if (!String.IsNullOrEmpty(pathfolder))
                            using (StreamWriter writer = new StreamWriter(pathfolder))
                                writer.Write(content);
                    }
                }

                return content;
            }
            catch { throw; }
        }

        #endregion

    }
}
