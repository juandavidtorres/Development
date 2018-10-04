//Development by Kelmer Ashley Comas Cardona © 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;

namespace Generic
{
    public static class ApiRESTService
    {

        private static Dictionary<int, string> Errors = new Dictionary<int, string>
        {
            {0,  "Error: en el formato de envio. ({0})" },
            {1, "No se pudo establecer conexion con el servidor, o no se obtuvo respuesta." },
            {2, "La URL no es correcta '{0}'." },
            {3,  "Error: {0} URL: '{1}'" }
        };

        public static byte[] GetBytesFromResponse(string URL, string commands = null, string user = null, string password = null,
                                         int? timeOut = null, string contentType = null, 
                                         Dictionary<string, string> headers = null, Dictionary<string, string> cookies = null, 
                                         string userAgent = null, string method = "GET",string Body="")
        {
            Stream stream = default(Stream);
            HttpWebResponse response = default(HttpWebResponse);
            HttpWebRequest request = default(HttpWebRequest);
            Uri uri = default(Uri);
            string strResponse = String.Empty;
            string fullURL = String.Empty;

            try
            {
                if (!String.IsNullOrEmpty(commands))
                {
                    if (!commands.StartsWith(@"/")) @commands = @"/" + @commands;
                    if (!commands.EndsWith(@"/")) @commands += @"/";
                }

                fullURL = @URL + @commands ?? "";
                uri = new Uri(@fullURL);
                stream = default(Stream);
                response = default(HttpWebResponse);
                request =(WebRequest.Create(uri) as HttpWebRequest);

                if (!String.IsNullOrEmpty(URL))
                {
                    request.Timeout = (int)TimeSpan.FromSeconds(timeOut ?? 60).TotalMilliseconds;
                    request.ReadWriteTimeout = (int)TimeSpan.FromSeconds(timeOut ?? 60).TotalMilliseconds;
                    request.ContentType = contentType;
                    request.Method = method;
                    request.UserAgent = userAgent;
                    request.AllowAutoRedirect = true;
                    request.AllowWriteStreamBuffering = false;
                    request.MaximumAutomaticRedirections = byte.MaxValue;
                    request.MaximumResponseHeadersLength = byte.MaxValue;
                    request.PreAuthenticate = false;
                    request.UseDefaultCredentials = true;
                    request.AutomaticDecompression = DecompressionMethods.GZip;
                    request.KeepAlive = false;

                    if (!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(password))
                    {
                        request.PreAuthenticate = true;
                        request.UseDefaultCredentials = false;
                        request.Credentials = new NetworkCredential(user, password);
                    }
                    else request.Credentials = CredentialCache.DefaultCredentials;
     
                    if (cookies != null)
                    {
                        request.CookieContainer = new CookieContainer();
                        foreach (var item in cookies)
                            request.CookieContainer.SetCookies(uri, item.Value);
                    }

                    if (headers.Count > 0)
                    {
                        foreach (var item in headers)
                        {
                            if (item.Key.Equals("accept", StringComparison.OrdinalIgnoreCase))
                                 request.Accept = item.Value;
                            else request.Headers.Add(item.Key, item.Value);                            
                        }                       
                    }

                    if (!string.IsNullOrEmpty(Body))
                    {
                        request.ContentLength = 1;
                    }

                    if (request.ContentLength <= 0)
                    {
                        try
                        {
                            response = (request.GetResponse() as HttpWebResponse);

                            if (response.StatusCode == HttpStatusCode.OK)
                                stream = response.GetResponseStream();    
                        }
                        catch(WebException ex)
                        {
                            response = (ex.Response as HttpWebResponse);
                            stream = (response != null) ? response.GetResponseStream() : null;


                            string error = "";
                            try
                            {

                                if (ex is WebException && ((WebException)ex).Status == WebExceptionStatus.ProtocolError)
                                {
                                    WebResponse errResp = ((WebException)ex).Response;
                                    using (Stream respStream = errResp.GetResponseStream())
                                    {
                                        // read the error response
                                        error = new System.IO.StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                                    }

                                    if (error.Contains("No hay registros asociados"))
                                    {
                                        byte[] bytes = UTF8Encoding.UTF8.GetBytes(error);
                                        return bytes;
                                    }
                                    else
                                        throw new Exception(String.Format(error, URL));
                                }
                            }
                            catch (Exception)
                            {
                              
                            }
                        }


                        if (stream != null)
                        {
                            byte[] buffer = Util.GetBytesFromStream(stream);
                            if (buffer.Length > 0)
                            {
                                headers.Clear();
                                if (response.Headers.Count > 0)
                                {
                                    if (headers == null) headers = new Dictionary<string, string>();
                                    for (int i = 0; i < response.Headers.Count; i++)
                                        headers.Add(response.Headers.GetKey(i), response.Headers.Get(i));
                                }

                                return buffer;
                            }
                            else throw new Exception(String.Format(Errors[0], strResponse));
                        }
                        else throw new Exception(Errors[1]);
                    }
                    else
                    {

                        byte[] Trama = UTF8Encoding.UTF8.GetBytes(Body);
                        request.ContentLength = Trama.Length;
                        stream = request.GetRequestStream();                        
                        stream.Write(Trama, 0, Trama.Length);

                        response = request.GetResponse() as HttpWebResponse;
                        StreamReader reader = new StreamReader(response.GetResponseStream());                        
                        string Respuesta = reader.ReadToEnd();

                        if ((!string.IsNullOrEmpty(Respuesta)))
                        {
                            byte[] bytes = UTF8Encoding.UTF8.GetBytes(Respuesta);
                            return bytes;
                        }
                        else throw new Exception(Errors[1]);
                    }
                }
                else throw new Exception(String.Format(Errors[2], URL));
            }


            catch (System.Net.WebException ex)
            {
                string error = "";
                try
                {

                    if (ex is WebException && ((WebException)ex).Status == WebExceptionStatus.ProtocolError)
                    {
                        WebResponse errResp = ((WebException)ex).Response;
                        using (Stream respStream = errResp.GetResponseStream())
                        {
                            // read the error response
                            error = new System.IO.StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                        }

                        if (error.Contains("No hay registros asociados"))
                        {
                            byte[] bytes = UTF8Encoding.UTF8.GetBytes(error);
                            return bytes;
                        }else
                            throw new Exception(String.Format(error, URL));
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            
            }
            catch (System.Exception ex) { throw new Exception(String.Format(Errors[3], ex.Message, fullURL)); }
            finally
            {
                if (request != null) request.Abort();
                if (response != null) response.Close();
                if (stream != null) stream.Close();
            
            }
            byte[] res=null;
            return res;
        }


        public static string GetResponse(string URL, string commands = null, string user = null, string password = null,
                                        int? timeOut = null, string contentType = null,
                                        Dictionary<string, string> headers = null, Dictionary<string, string> cookies = null,
                                        string userAgent = null, string method = "GET",string Body="")
        {
            byte[] bytes = ApiRESTService.GetBytesFromResponse(URL, commands, user, password, timeOut, 
                                                               contentType, headers, cookies, userAgent, method,Body);
            return Encoding.UTF8.GetString(bytes);
        }

    }
}
