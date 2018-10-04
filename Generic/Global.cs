//Development by Kelmer Ashley Comas Cardona © 2015

using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Globalization;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Security;
using System.Drawing;
using System.Drawing.Imaging;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace Generic
{
    public static class Global
    {

        //Carateres de formato de texto
        public static char KeyTab = '\t';
        public static char KeyReturn = '\r';
        public static char KeyNewLine = '\n';

        public enum eTypes { ENTERO, DECIMAL, FECHAHORA, TEXTO }
        public enum eEncoding { ASCII, UTF7, UTF8, UTF32, ANSI, Unicode }

        //Recorta el texto a la longitud expecifica y coloca puntos ... suspensivos
        public static bool ClipText(ref string text, int length)
        {
            bool isClipText = false;

            if (text != null)
                if (text.Length > length)
                {
                    text = text.Substring(0, length - 3) + "...";
                    isClipText = true;
                }

            return isClipText;
        }

        //devuelve el tiempo transcurrido entre la fecha inicial pasada como parametro y la fecha actual
        public static string TimeElapsed(DateTime startTime)
        {
            DateTime endTime = DateTime.Now;
            TimeSpan ts = endTime.Subtract(startTime).Duration();

            return String.Format("{0} h : {1} m : {2} s",
                                  ts.Hours, ts.Minutes, ts.Seconds);
        }

        //Inicia un servicio windows
        public static void StartService(string serviceName, TimeSpan timeout)
        {
            try
            {
                var srvController = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == serviceName);

                if (srvController.Status == ServiceControllerStatus.Paused ||
                    srvController.Status == ServiceControllerStatus.Stopped)
                {
                    srvController.Start();
                    srvController.WaitForStatus(ServiceControllerStatus.Running, timeout);
                }
            }
            catch { throw; }
        }


        //Detiene un servicio windows
        public static void StopService(string serviceName, TimeSpan timeout)
        {
            try
            {
                var srvController = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == serviceName);

                if (srvController.Status == ServiceControllerStatus.Running)
                {
                    srvController.Stop();
                    srvController.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                }
            }
            catch { throw; }
        }


        //Reinicia un servicio windows
        public static void RestartService(string serviceName, TimeSpan timeout)
        {
            try
            {
                var srvController = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == serviceName);

                if (srvController.Status == ServiceControllerStatus.Running)
                {
                    srvController.Stop();
                    srvController.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                }

                srvController.Start();
                srvController.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch { throw; }
        }


        //devuelve el estado de un servicio
        public static ServiceControllerStatus ServiceStatus(string serviceName)
        {
            try
            {
                var srvController = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == serviceName);

                if (srvController != null)
                    return srvController.Status;
                else throw new Exception(String.Format("Servicio no encontrado {0}.", serviceName));
            }
            catch { throw; }
        }

        //Devuelve la direccion IP como objeto si el parametro es null entonces retorna la IP del equipo local
        public static IPAddress GetIPAddress(string ipAddress = null)
        {
            try
            {
                if (String.IsNullOrEmpty(ipAddress))
                    return Array.FindAll(Dns.GetHostEntry("").AddressList,
                                            a => a.AddressFamily == AddressFamily.InterNetwork)[0];
                else return IPAddress.Parse(ipAddress);

            }
            catch { return null; }
        }

        //DEVUELVE EL FORMULARIO PADRE QUE CONTIENE EL CONTROL
        public static Form ParentForm(Control control)
        {
            try
            {
                Control obj = default(Control);
                obj = control.Parent;

                while (!(obj is Form))
                {
                    if (obj != null)
                        obj = obj.Parent;
                    else break;
                }

                return (Form)obj;
            }
            catch { return null; }
        }

        //DEVUELVE EL NUMERO DE OCURRENCIAS DEL PATRON ESPECIFICADO DENTRO DE UNA CADENA DETERMINADA
        public static int countOccurs(string text, string pattern)
        {
            int length = 0;

            try
            {
                length = text.Length;
                int lengthDiff = text.Replace(pattern, "").Length;
                length = (length - lengthDiff) / pattern.Length;
            }
            catch { length = 0; }

            return length;
        }

        //CUENTA EL NUMERO DE LINEAS DE UN ARCHIVO DE TEXTO
        public static int CountLinesInFile(string path)
        {
            int count = 0;

            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader file = new StreamReader(path))
                    {
                        string text = file.ReadToEnd();
                        count = Global.countOccurs(text, "\n");
                    }
                }
            }
            catch { count = 0; }

            return count;
        }

        //CUENTA EL NUMERO DE LINEAS EN UNA CADENA DE TEXTO
        public static int CountLinesInText(string text)
        {
            return Global.countOccurs(text, "\n");
        }

        //DEVUELVE UNA CADENA CON EL CARACTER REPETIDO LA CANTIDAD DE VECES QUE SE ESPECIFIQUE
        public static string RepeatChar(char c, int length) { return new string(c, length); }


        //DEVUELVE LA RUTA DE LA APLICACION ACTUAL
        public static string AppPath()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return Path.GetDirectoryName(assembly.GetModules()[0].FullyQualifiedName);
        }


        //DEVUELVE EL NOMBE DEL ENSABLADO (DLL) ACTUAL
        public static string ModuleName()
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            string moduleName = assembly.GetName().Name;
            return moduleName;
        }

        //DEVUELVE LA RUTA COMPLETA INCLUYENDO EL NOMBRE DE ARCHIVO Y EXTENSION, DONDE SE ENCUENTRA EL ENSABLADO (DLL) ACTUAL
        public static string LibraryFullPath()
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            string LibraryName = assembly.GetModules()[0].Name;
            string path = Path.GetDirectoryName(assembly.GetModules()[0].FullyQualifiedName);
            return path + "\\" + LibraryName;
        }

        //DEVUELVE LA RUTA DE LA CARPETA DONDE SE ENCUENTRA EL ENSABLADO (DLL) ACTUAL
        public static string PathLibrary()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return Path.GetDirectoryName(assembly.GetModules()[0].FullyQualifiedName);
        }

        //DEVUELVE EL NOMBRE DEL ENSABLADO (DLL) ACTUAL
        public static string LibraryName()
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            string LibraryName = assembly.GetModules()[0].Name;
            return LibraryName;
        }

        //DEVUELVE LA FECHA DE MODIFICACION DE UN ENSABLADO (DLL)
        public static DateTime UpdateDateLibrary()
        {
            FileInfo info = new FileInfo(Global.LibraryFullPath());
            return info.LastAccessTime;
        }


        //Devuelve el nombre del archivo especificado con su ruta completa
        public static string GetFileName(string fullPath)
        {
            string[] path = fullPath.Split('\\');
            return path[path.Length - 1];
        }


        //Devuelve la ruta de la carpeta que contiene un archivo especificado con su ruta completa
        public static string GetFolderPath(string fullPath)
        {
            string fileName = Global.GetFileName(fullPath);
            return fullPath.Replace("\\" + fileName, "");
        }

        //Obtiene la lista de nombres de archivos, cuya extension se encuentra en la lista separada por |
        //especificada en el parametro "extensions", que se encuentran en la ruta especificada en el parametro "path"
        public static string[] GetFilesFromPath(string path, string extensions)
        {
            try
            {
                List<string> files = new List<string>();

                foreach (string ext in extensions.Split('|'))
                {
                    string fileExt = "*." + ext;
                    files.AddRange(Directory.GetFiles(path, fileExt, SearchOption.TopDirectoryOnly));
                }

                return files.ToArray();
            }
            catch { throw; }
        }

        //Obtiene un filtro con de las extenciones especificadas en una lista separada por el caracter |
        public static string GetTextFilterExtensions(string strExtensions)
        {
            string[] extensions = strExtensions.Split('|');
            string value = "";

            foreach (string ext in extensions)
            {
                value += "(*.{0})|*.{0}";
                value = String.Format(value, ext);
            }

            return value;
        }

        //ABRE EL ARCHIVO ESPECIFICADO EN LA APLICACION ESPECIFICADA
        public static void OpenApplication(string application, string args = "",
                                           ProcessWindowStyle windowsStyle = ProcessWindowStyle.Normal,
                                           string domain = "", string user = "", string password = "")
        {
            try
            {
                Process process = new Process();

                process.StartInfo.FileName = application;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.WindowStyle = windowsStyle;
                if (!String.IsNullOrEmpty(args)) process.StartInfo.Arguments = args;
                if (!String.IsNullOrEmpty(domain)) process.StartInfo.Domain = domain;
                if (!String.IsNullOrEmpty(user)) process.StartInfo.UserName = user;

                if (!String.IsNullOrEmpty(password))
                {
                    SecureString spassword = new SecureString();

                    foreach (char c in password)
                        spassword.AppendChar(c);

                    process.StartInfo.Password = spassword;
                }

                process.Start();
            }
            catch { throw; }
        }


        //EJECUTAR COMANDO DE CONSOLA WINDOWS
        public static string ExecuteWinCommand(string comando, string user = null, string password = null)
        {
            Process process = new Process();

            process.StartInfo.FileName = "cmd";
            process.StartInfo.Arguments = "/c " + comando;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            if (user != null && password != null)
            {
                SecureString pwd = new SecureString();

                foreach (char c in password.ToCharArray())
                    pwd.AppendChar(c);

                pwd.MakeReadOnly();

                process.StartInfo.UserName = user;
                process.StartInfo.Password = pwd;
            }

            process.Start();

            return process.StandardOutput.ReadToEnd();
        }


        //DEVUELVE UNA CADENA CON EL TEXTO ALINEADO SEGUN LOS PARAMETROS ESPECIFICOS 
        public static string TextAlign(string text, int length, char align, char? fill = null)
        {
            try
            {
                string t = text.Trim();
                int n = text.Length, d, i = 0;
                char charFill = (fill == null) ? ' ' : (char)fill;

                if (n > length)
                    t = t.Substring(0, length - 2) + "..";
                else
                    switch (align)
                    {
                        case 'L':
                        case 'l':
                            t = t.PadRight(length, charFill);
                            break;
                        case 'C':
                        case 'c':
                            d = (length - n) / 2;
                            i = ((length - n) % 2 != 0) ? 1 : 0;
                            t = new String(charFill, d) + t + new String(charFill, d + i);
                            break;
                        case 'R':
                        case 'r':
                            t = t.PadLeft(length, charFill);
                            break;
                    }

                return t;
            }
            catch { throw; }
        }

        public static string MultilineText(string text, int length, char align, char? fill = null)
        {
            StringBuilder buffer = new StringBuilder();
            string aux = text.Trim(), line;
            int n = length;

            while (!String.IsNullOrEmpty(aux))
            {
                if (aux.Length < n) n = aux.Length;
                line = Global.TextAlign(aux.Substring(0, n), length, align, fill);
                buffer.AppendLine(line);
                aux = aux.Substring(n);
            }

            return buffer.ToString();
        }

        //Limpia todos los controles de un contenedor (Formulario, Panel, ScrollableControl, etc...)
        public static void ClearControls(Control container)
        {
            try
            {
                if (container != null)
                {
                    foreach (Control control in container.Controls)
                    {
                        if (control is ListBox)
                            (control as ListBox).Items.Clear();
                        if (control is ListView)
                            (control as ListView).Items.Clear();
                        if (control is TreeView)
                            (control as TreeView).Nodes.Clear();
                        else if (control is DataGridView)
                            (control as DataGridView).DataSource = null;
                        else if (control is ComboBox)
                            (control as ComboBox).SelectedIndex = -1;
                        else if (control is CheckBox)
                            (control as CheckBox).Checked = false;
                        else if (control is RadioButton)
                            (control as RadioButton).Checked = false;
                        else if (control is DateTimePicker)
                            (control as DateTimePicker).Value = DateTime.Now;
                        else if (control is UserControl || control is ScrollableControl || control is Panel)
                            Global.ClearControls(control);
                        else { if (!(control is Label) && !(control is Button)) control.Text = ""; }
                    }
                }
            }
            catch { throw; }
        }

        //Habilita o desabilita todos los controles contenidos en un contenedor
        public static void EnabledControls(Control container, bool enabled)
        {
            foreach (Control control in container.Controls)
                if (control is UserControl || control is ScrollableControl || control is Panel)
                    Global.EnabledControls(control, enabled);
                else control.Enabled = enabled;
        }

        //Remueve los espacios del inicio y del final de la cadena, ademas convierte los espacios multiples en un unico espacio
        public static string RemoveSpace(string text)
        {
            int i = 0;
            string formattedText = "";
            bool isSpace = false;

            foreach (char c in text.ToCharArray())
            {
                if (c == ' ') isSpace = true;
                else
                {
                    if (isSpace)
                    {
                        formattedText += ((i > 0) ? " " : "");
                        isSpace = false;
                    }
                    else i++;

                    formattedText += c;
                }
            }

            return formattedText;
        }

        //Coloca un texto en letra capital, todas las letras del inicio de una palabra en mayusculas
        public static string AllFistUpper(string text)
        {
            string formattedText = "";
            bool isSpace = false;
            text = " " + text;
            int i = 0;

            foreach (char c in text.ToCharArray())
            {
                if (c == ' ') isSpace = true;
                else
                {
                    if (isSpace)
                    {
                        formattedText += ((i > 0) ? " " : "");
                        formattedText += c.ToString().ToUpper();
                        isSpace = false;
                    }
                    else
                    {
                        formattedText += c.ToString().ToLower();
                        i++;
                    }
                }
            }

            return formattedText;
        }


        //Devuelve verdadero si es un caracter TAB, RETORNO o NUEVA LINEA, en caso contrario devuelve false
        public static bool IsCharTextFormat(char character)
        {
            if (character == Global.KeyTab ||
                character == Global.KeyReturn ||
                character == Global.KeyNewLine)
                return true;
            else return false;
        }

        //convierte un numero expresado como cadena a valor decimal 
        //teniendo encuenta el separador establecido en la configuracion regional
        public static double GetDouble(string number)
        {
            try
            {
                double value = 0;
                number = number.Trim();
                if (String.IsNullOrEmpty(number)) number = "0";

                string currencySymbol = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
                string currencySeparator = CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator;
                string currencyDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                number = number.Replace(currencySymbol, "");
                number = number.Replace(currencySeparator, "");
                number = number.Replace(number.Contains(",") ? "," : ".", currencyDecimalSeparator);

                try
                {
                    value = Double.Parse(number, NumberStyles.Currency, CultureInfo.CurrentCulture);
                    if (Double.IsInfinity(value)) throw new Exception("Formato numerico invalido");
                }
                catch { throw new Exception("Formato numerico invalido"); }

                return value;
            }
            catch { throw; }
        }

        //convierte un numero expresado como cadena a valor decimal teniendo encuenta el separador establecido en la configuracion regional
        public static decimal GetDecimal(string number)
        {
            try
            {
                decimal value = 0;
                number = number.Trim();
                if (String.IsNullOrEmpty(number)) number = "0";

                string currencySymbol = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
                string currencySeparator = CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator;
                string currencyDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                number = number.Replace(currencySymbol, "");
                number = number.Replace(currencySeparator, "");
                number = number.Replace(number.Contains(",") ? "," : ".", currencyDecimalSeparator);

                try { value = Convert.ToDecimal(number); }
                catch { throw new Exception("Formato numerico invalido"); }

                return value;
            }
            catch { throw; }
        }


        //Indica si hay internet o no en el equipo actual
        public static bool HasInternet()
        {
            try
            {
                HttpWebRequest request;
                HttpWebResponse response;

                request = (HttpWebRequest)WebRequest.Create("http://www.google.com");
                request.Timeout = (int)TimeSpan.FromSeconds(10).TotalMilliseconds;
                response = (HttpWebResponse)request.GetResponse();
                request.Abort();
                return (response.StatusCode == System.Net.HttpStatusCode.OK) ? true : false;
            }
            catch { return false; }
        }


        //Indica si la cadena pasada como parametro es un valor Hexadecimal de tamaño de 1 byte
        public static bool IsByteHex(string value)
        {
            try
            {
                Convert.ToByte(value, 16);
                return true;
            }
            catch { return false; }
        }

        //Indica si la cadena pasada como parametro es un valor Hexadecimal de tamaño de 1 un entero
        public static bool IsIntHex(string value)
        {
            try
            {
                Convert.ToInt32(value, 16);
                return true;
            }
            catch { return false; }
        }

        //Indica si la cadena pasada como parametro es un valor Hexadecimal de tamaño de 1 un entero largo
        public static bool IsLongHex(string value)
        {
            try
            {
                Convert.ToInt64(value, 16);
                return true;
            }
            catch { return false; }
        }

        //Obtiene los bytes de la imagen contenida en el parametro "imagen", 
        //de acuerdo al formato especificado en el parametro "format"
        public static byte[] GetBytesFromImage(Bitmap image, ImageFormat format)
        {
            if (image != null)
            {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, format);
                return ms.GetBuffer();
            }

            return null;
        }

        //Obtiene la imagen conformada por los bytes pasados en el parametro "imageBytes"
        public static Image GetImageFromString(string image)
        {
            if (String.IsNullOrEmpty(image))
            {
                MemoryStream ms = new MemoryStream(Global.ToBytes(image));
                return Image.FromStream(ms);
            }

            return null;
        }

        //Obtiene la imagen conformada por los bytes pasados en el parametro "imageBytes"
        public static Image GetImageFromBytes(byte[] imageBytes)
        {
            if (imageBytes != null)
            {
                MemoryStream ms = new MemoryStream(imageBytes);
                return Image.FromStream(ms);
            }

            return null;
        }

        //Obtiene la imagen en base 64 conformada por los bytes contenidos 
        //en la cadena de texto pasada en el parametro "image"
        public static Bitmap GetImageFromString64(string image)
        {
            if (!String.IsNullOrEmpty(image))
            {
                MemoryStream imageBytes;
                imageBytes = new MemoryStream(Convert.FromBase64String(image));

                return (Bitmap)Image.FromStream(imageBytes);
            }

            return null;
        }

        //Devuelve el dato o null si el dato es vacio
        public static string GetDataNulls(string data)
        {
            if (data != null)
            {
                data = data.Trim();
                return (String.IsNullOrEmpty(data)) ? null : data;
            }

            return null;
        }

        //Desencripta una cadena de conexion con el algoritmo MD5 con 3DES
        public static string DecryptConnectionString(string connectionString, string key)
        {
            string connection = Global.RemoveSpace(connectionString);
            int startIndex = connection.ToLower().IndexOf("password");

            if (startIndex > 0)
            {
                int endIndex = connection.IndexOf(";", startIndex);
                string aux = connection.Substring(startIndex, endIndex - startIndex);
                startIndex = aux.IndexOf("=");
                string password = Cryptography.Decrypt(aux.Substring(startIndex + 1), key);
                connection = connection.Replace(aux, "password = " + password);
            }

            return connection;
        }

        //Devuelve los bytes de una cadena de texto
        public static byte[] ToBytes(string value, eEncoding encoding = eEncoding.ASCII)
        {
            try
            {
                byte[] bytes = null;

                switch (encoding)
                {
                    case eEncoding.ASCII:
                        bytes = Encoding.ASCII.GetBytes(value);
                        break;
                    case eEncoding.UTF7:
                        bytes = Encoding.UTF7.GetBytes(value);
                        break;
                    case eEncoding.UTF8:
                        bytes = Encoding.UTF8.GetBytes(value);
                        break;
                    case eEncoding.UTF32:
                        bytes = Encoding.UTF32.GetBytes(value);
                        break;
                    case eEncoding.Unicode:
                        bytes = Encoding.Unicode.GetBytes(value);
                        break;
                    default:
                        bytes = Encoding.Default.GetBytes(value);
                        break;
                }

                return bytes;
            }
            catch { return null; }
        }

        public static Encoding GetFileEncoding(string pathFile)
        {
            byte[] buffer = new byte[5];
            Encoding encoding = Encoding.Default; //ANSI           

            using (FileStream file = new FileStream(pathFile, FileMode.Open))
                file.Read(buffer, 0, 5);

            if (buffer[0] == 0xef && buffer[1] == 0xbb && buffer[2] == 0xbf)
                encoding = Encoding.UTF8;
            else if (buffer[0] == 0xfe && buffer[1] == 0xff)
                encoding = Encoding.Unicode;
            else if (buffer[0] == 0 && buffer[1] == 0 && buffer[2] == 0xfe && buffer[3] == 0xff)
                encoding = Encoding.UTF32;
            else if (buffer[0] == 0x2b && buffer[1] == 0x2f && buffer[2] == 0x76)
                encoding = Encoding.UTF7;

            return encoding;
        }

        public static byte[] GetBytesFromStream(Stream stream)
        {
            List<byte> buffer = new List<byte>();

            if (stream != null)
            {
                int b = stream.ReadByte();
                while (b >= 0)
                {
                    buffer.Add(Cast.ToByte(b));
                    b = stream.ReadByte();
                }
            }

            return buffer.ToArray();
        }
    }
}
