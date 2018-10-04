using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using POSstation.Fabrica;
using POSstation;
using System.Threading;
using POSstation.AccesoDatos;
using System.IO;
using System.Windows.Forms;

namespace POSstation
{
    public class LSIB4Reader 
    {
        #region Eventos"
        public event EnviarBytesLecturaChipPorDtiEventHandler EnviarBytesLecturaChipPorDti;
        public delegate void EnviarBytesLecturaChipPorDtiEventHandler(System.Array Lecturas, string Puerto, Int32 IdDispositivoLSIB4);

        public event ExcepcionOcurridaEventHandler ExcepcionOcurrida;
        public delegate void ExcepcionOcurridaEventHandler(string Mensaje, bool Imprime, bool Terminal, string PuertoAImprimir);

        #endregion

        SerialPort PuertoTerminal;
        Helper oDataAccess = new Helper();
        private PropiedadesExtendidas LogPropiedades = new PropiedadesExtendidas();
        private CategoriasLog LogCategorias = new CategoriasLog();
        private int Longitud;
        string Puerto;//El puerto COM       
        int IdDispositivoDti;
        string[] TramaElementos = new string[1];
        string ArchivoRegistro;
        StreamWriter SWRegistro;
        int Delay = 0;
        #region Funciones





        private string[] ExtraerInformacionRecibidaDelDispositivoDTI(byte[] ArregloBytes)
        {
            byte[] Temporal;
            string TempPuerto = string.Empty;
            string[] Valores = new string[1];
            int j = 0;
            try
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoCodigoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Numero Bytes Recibidos de Lectura", ArregloBytes.Length.ToString());
                LogPropiedades.Agregar("FechaHora:", DateTime.Now.ToString());
                Fabrica.LogIt.Loguear("Logueando el numero de bytes recibidos de la dti", LogPropiedades, LogCategorias);


                if (ArregloBytes.Length > 150)//Se realizo una mala conexcion del chip en el lector
                {
                    LogCategorias.Clear();
                    LogCategorias.Agregar("SeguimientoCodigoDTI");
                    LogPropiedades.Clear();
                    LogPropiedades.Agregar("FechaHora:", DateTime.Now.ToString());
                    Fabrica.LogIt.Loguear("Logueando la lectura del chip no se hizo correctamente debido que se coloco y se retiro inmediatamente", LogPropiedades, LogCategorias);



                }
                else
                {
                    if (ArregloBytes.Length > 128) //Me indica que lo que llega es una lectura con pagina y no la trama I#.NC que es la trama cuando se desconecta
                    {                               //El chip del lector

                        ////Saco la informacion correspondiente a la cabecera de la trama dado que me llegara de la siguiente forma
                        //// I#.ROM PAGINAS 
                        Temporal = new byte[19]; //Aqui saco la informacion del Puerto y el ROM que vienen en los primeros 19 Bytes
                        for (int i = 0; i <= 18; i++)
                        {
                            Temporal[i] = ArregloBytes[i];
                        }


                        System.Array oPaginas;
                        oPaginas = System.Array.CreateInstance(typeof(byte), ArregloBytes.Length);

                        for (int i = 0; i < ArregloBytes.Length; i++)
                        {
                            oPaginas.SetValue(ArregloBytes[i], i);

                        }

                        ///OJOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO////

                        //Aqui le informo al autorizador que se se tienen los bytes de las paginas y se le envian para que los desecripte 
                        if (EnviarBytesLecturaChipPorDti != null)
                        {
                            EnviarBytesLecturaChipPorDti(oPaginas, Puerto, IdDispositivoDti);
                        }



                    }
                    else//Cuando entra aqui es porque se desconecto el chip y recibi la trama I#.NC ()
                    {

                        Temporal = new byte[5]; //Aqui saco la informacion del Puerto y el donde se deconecto el chip
                        for (int i = 0; i <= 4; i++)
                        {
                            Temporal[i] = ArregloBytes[i];
                        }


                        System.Array oPaginas;
                        oPaginas = System.Array.CreateInstance(typeof(byte), Temporal.Length);

                        for (int i = 0; i < Temporal.Length; i++)
                        {
                            oPaginas.SetValue(Temporal[i], i);

                        }

                        //Aqui le informo al autorizador que se desconecto el chip de la DTI
                        if (EnviarBytesLecturaChipPorDti != null)
                        {
                            EnviarBytesLecturaChipPorDti(oPaginas, Puerto, IdDispositivoDti);
                        }


                    }


                }



            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoCodigoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                Fabrica.LogIt.Loguear("Error en ExtraerPuerto", LogPropiedades, LogCategorias);
                throw ex;
            }
            return Valores;
        }

        //Funcion que envia la informacion con la lectura del chip al Autorizador
        void EnviarDatosChip(object Parametro)
        {
            DatosLector obj = (DatosLector)Parametro;
            byte[] DatosLeidos = obj.ArregloBytes;
            try
            {


                if (DatosLeidos.Length == 148)
                {
                    byte[] Trama = new byte[147];
                    for (int y = 0; y < DatosLeidos.Length - 1; y++)
                    {

                        Trama[y] = DatosLeidos[y];

                    }
                    ExtraerInformacionRecibidaDelDispositivoDTI(Trama);
                }

                else if (DatosLeidos.Length == 6)
                {
                    byte[] Trama = new byte[5];
                    for (int y = 0; y < DatosLeidos.Length - 1; y++)
                    {

                        Trama[y] = DatosLeidos[y];

                    }
                    ExtraerInformacionRecibidaDelDispositivoDTI(Trama);

                }
                else
                    throw new Exception("La lectura del chip no se hizo correctamente");


            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoCodigoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                Fabrica.LogIt.Loguear("Error recuperando ROM chip", LogPropiedades, LogCategorias);

            }

        }
        #endregion


        void NumeroReintentosLectura()
        {


        }


        public void VerifySizeFile() //Analiza el tamaño del archivo 
        {
            try
            {

                if (!Directory.Exists(Application.StartupPath + "\\LogueoLSIB4"))
                    Directory.CreateDirectory(Application.StartupPath + "\\LogueoLSIB4\\");

                FileInfo FileInf = new FileInfo(ArchivoRegistro);
                if (FileInf.Length > 30000000)
                {
                    SWRegistro.Close();
                    //Crea archivo para almacenar inconsistencias en el proceso logico
                    ArchivoRegistro = Application.StartupPath + "\\LogueoLSIB4\\" + DateTime.Now.ToString("yyyyMMdd") + "RegistroTrama" + Puerto + ".txt";
                    ArchivoRegistro = ArchivoRegistro.Replace(".EXE", "");
                    SWRegistro = File.AppendText(ArchivoRegistro);
                }
            }
            catch (Exception ex)
            {

            }

        }

        #region EVENTOS_DE_PUERTOS_COM
        private void PuertoTerminal_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {

                string X2 = "";
                byte[] ODatosChip, Trama;
                DatosLector OChipTemporal = new DatosLector();


                System.Threading.Thread.Sleep(Delay);
                Longitud = PuertoTerminal.BytesToRead;
                ODatosChip = new byte[Longitud];
                PuertoTerminal.Read(ODatosChip, 0, Longitud);
                PuertoTerminal.DiscardInBuffer();
                PuertoTerminal.DiscardOutBuffer();

                Trama = new byte[Longitud];


                if (Longitud <= 0)
                {
                    PuertoTerminal.RtsEnable = true;
                    System.Threading.Thread.Sleep(10);
                    PuertoTerminal.RtsEnable = false;
                    return;
                }

                for (int y = 0; y < ODatosChip.Length; y++)
                {
                    Trama[y] = ODatosChip[y];

                }

                for (int i = 0; i < ODatosChip.Length; i++)
                {
                    X2 += ODatosChip[i].ToString("X2");
                }


                VerifySizeFile();//Verifico el tamaño del archivo de texto con las tramas
                if ((ODatosChip.Length == 6) && (Trama[5] == 0x7E))
                {
                    SWRegistro.WriteLine(DateTime.Now + " |N° Bytes Recibidos " + ODatosChip.Length.ToString() + "|" + X2);
                    SWRegistro.Flush();
                    OChipTemporal.ArregloBytes = ODatosChip;
                    System.Threading.ParameterizedThreadStart Parametro = new ParameterizedThreadStart(EnviarDatosChip);
                    System.Threading.Thread Hilo = new System.Threading.Thread(Parametro);
                    Hilo.Start(OChipTemporal);
                    Hilo.Join();

                }
                else if ((ODatosChip.Length == 148) && (Trama[147] == 0x7E))
                {

                    SWRegistro.WriteLine(DateTime.Now + " |N° Bytes Recibidos " + ODatosChip.Length.ToString() + "|" + X2);
                    SWRegistro.Flush();

                    OChipTemporal.ArregloBytes = ODatosChip;
                    System.Threading.ParameterizedThreadStart Parametro = new ParameterizedThreadStart(EnviarDatosChip);
                    System.Threading.Thread Hilo = new System.Threading.Thread(Parametro);
                    Hilo.Start(OChipTemporal);
                    Hilo.Join();
                }
                else
                {
                    if (ODatosChip.Length >= 2)
                    {

                        PuertoTerminal.RtsEnable = true;
                        System.Threading.Thread.Sleep(10);
                        PuertoTerminal.RtsEnable = false;

                        Byte[] Lector = new Byte[5] { 0x49, 0x3F, ODatosChip[1], 0x15, 0x7E };
                        X2 = "";
                        for (int i = 0; i < Lector.Length; i++)
                        {
                            X2 += Lector[i].ToString("X2");
                        }


                        SWRegistro.WriteLine(DateTime.Now + " |Lectura incompleta del LSIB4 (" + ODatosChip.Length + ") Bytes: Reintento de Lectura  LSIB4 " + "|" + X2);
                        SWRegistro.Flush();
                        PuertoTerminal.Write(Lector, 0, Lector.Length);
                        System.Threading.Thread.Sleep(Delay);
                    }

                }
            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoCodigoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                Fabrica.LogIt.Loguear("Error recuperando ROM chip PuertoTerminal_DataReceived", LogPropiedades, LogCategorias);

            }



        }


        #endregion


        //Funcion que se encarga de iniciar los datos de los puerto y otras variables
        public void ReaderHostMain(string strPuerto, int IdDispositivo)
        {
            LogCategorias.Clear();
            LogCategorias.Agregar("LSIB4");
            LogPropiedades.Clear();
            LogPropiedades.Agregar("FechaHora:", DateTime.Now.ToString());
            LogPropiedades.Agregar("Mensaje", "Antes de abrir Puerto Com");
            Fabrica.LogIt.Loguear("ReaderHostMain", LogPropiedades, LogCategorias);

            Puerto = strPuerto;
            IdDispositivoDti = IdDispositivo;
            PuertoTerminal = new SerialPort();
            PuertoTerminal.DataReceived += new SerialDataReceivedEventHandler(PuertoTerminal_DataReceived);

            //CONFIGURACION DEL PUERTO DE LA TERMINAL REMOTA
            PuertoTerminal.PortName = Puerto;
            PuertoTerminal.BaudRate = 9600;
            PuertoTerminal.DataBits = 8;
            PuertoTerminal.StopBits = StopBits.One;
            PuertoTerminal.Parity = Parity.None;
            PuertoTerminal.ReadBufferSize = 4000;

            Helper oHelper = new Helper();

            Delay = Convert.ToInt32(oHelper.RecuperarParametro("DelayLSIB4"));



            try
            {
                PuertoTerminal.Open();
            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("LSIB4");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                Fabrica.LogIt.Loguear("Error Abriendo puerto", LogPropiedades, LogCategorias);
            }
            LogCategorias.Clear();
            LogCategorias.Agregar("LSIB4");
            LogPropiedades.Clear();
            LogPropiedades.Agregar("FechaHora:", DateTime.Now.ToString());
            LogPropiedades.Agregar("Mensaje", "Despues de abrir Puerto Com");
            Fabrica.LogIt.Loguear("ReaderHostMain", LogPropiedades, LogCategorias);



            try
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("LSIB4");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("FechaHora:", DateTime.Now.ToString());
                LogPropiedades.Agregar("Mensaje", "Antes de crear Archivo de tramas");
                Fabrica.LogIt.Loguear("ReaderHostMain", LogPropiedades, LogCategorias);

                if (!Directory.Exists(Application.StartupPath + "\\LogueoLSIB4"))
                    Directory.CreateDirectory(Application.StartupPath + "\\LogueoLSIB4\\");


                ArchivoRegistro = Application.StartupPath + "\\LogueoLSIB4\\" + DateTime.Now.ToString("yyyyMMdd") + "RegistroTrama" + Puerto + ".txt";
                ArchivoRegistro = ArchivoRegistro.Replace(".EXE", "");
                SWRegistro = File.AppendText(ArchivoRegistro);
                //Escribe encabezado en archivo de Estados
                SWRegistro.WriteLine("===================|====|==|======|==================================");
                SWRegistro.WriteLine(DateTime.Now + "|2013-11-28-1018 Puerto: " + Puerto); //  Thread.Sleep(1000);// Totalizador final = inicial en ProcesoFindeVentaStatus
                SWRegistro.Flush();
                SWRegistro.WriteLine("===================|====|==|====INICIO==|==============================");
                SWRegistro.Flush();

                LogCategorias.Clear();
                LogCategorias.Agregar("LSIB4");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("FechaHora:", DateTime.Now.ToString());
                LogPropiedades.Agregar("Mensaje", "Despues de crear Archivo de tramas");
                Fabrica.LogIt.Loguear("ReaderHostMain", LogPropiedades, LogCategorias);
            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoCodigoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                Fabrica.LogIt.Loguear("Iniciando Archivo de Tramas LSIB4", LogPropiedades, LogCategorias);
                throw;

            }

        }

        public void CerrarPuerto()
        {
            try
            {
                PuertoTerminal.Close();

            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoCodigoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                Fabrica.LogIt.Loguear("Error recuperando ROM chipCerrarPuerto", LogPropiedades, LogCategorias);

            }

        }



    }


   

    class DatosLector
    {
        public byte[] ArregloBytes { get; set; }

    }

}





//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.IO.Ports;
//using POSstation.AccesoDatos;
//using POSstation.Fabrica;
//using POSstation;
//using System.Threading;
//using POSstation.ControlSurtidor;


//namespace POSstation
//{
//    public class LSIB4Reader :Disposable , POSstation.ControlSurtidor.LSIB4Interfaz
//    {
//        #region EVENTOS
//        public event LSIB4Interfaz.EnviarBytesLecturaChipPorDtiEventHandler EnviarBytesLecturaChipPorDti;
//        #endregion

//         SerialPort PuertoTerminal;        
//        Helper oDataAccess = new Helper();
//        private PropiedadesExtendidas LogPropiedades = new PropiedadesExtendidas();
//        private CategoriasLog LogCategorias = new CategoriasLog();
//        private int Longitud;
//        string Puerto;//El puerto COM       
//        int IdDispositivoDti;
//        string[] TramaElementos = new string[1];
//        #region Funciones





//        private string[] ExtraerInformacionRecibidaDelDispositivoDTI(byte[] ArregloBytes)
//        {
//            byte[] Temporal;
//            string TempPuerto = string.Empty;
//            string[] Valores = new string[1];
//            int j = 0;
//            try
//            {
//                LogCategorias.Clear();
//                LogCategorias.Agregar("SeguimientoCodigoDTI");
//                LogPropiedades.Clear();
//                LogPropiedades.Agregar("Numero Bytes Recibidos de Lectura", ArregloBytes.Length.ToString());
//                LogPropiedades.Agregar("FechaHora:", DateTime.Now.ToString());
//                Fabrica.LogIt.Loguear("Logueando el numero de bytes recibidos de la dti", LogPropiedades, LogCategorias);


//                if (ArregloBytes.Length > 150)//Se realizo una mala conexcion del chip en el lector
//                {
//                    LogCategorias.Clear();
//                    LogCategorias.Agregar("SeguimientoCodigoDTI");
//                    LogPropiedades.Clear();
//                    LogPropiedades.Agregar("FechaHora:", DateTime.Now.ToString());
//                    Fabrica.LogIt.Loguear("Logueando la lectura del chip no se hizo correctamente debido que se coloco y se retiro inmediatamente", LogPropiedades, LogCategorias);



//                }
//                else
//                {
//                    if (ArregloBytes.Length > 128) //Me indica que lo que llega es una lectura con pagina y no la trama I#.NC que es la trama cuando se desconecta
//                    {                               //El chip del lector

//                        ////Saco la informacion correspondiente a la cabecera de la trama dado que me llegara de la siguiente forma
//                        //// I#.ROM PAGINAS 
//                        Temporal = new byte[19]; //Aqui saco la informacion del Puerto y el ROM que vienen en los primeros 19 Bytes
//                        for (int i = 0; i <= 18; i++)
//                        {
//                            Temporal[i] = ArregloBytes[i];
//                        }


//                        System.Array oPaginas;
//                        oPaginas = System.Array.CreateInstance(typeof(byte), ArregloBytes.Length);

//                        for (int i = 0; i < ArregloBytes.Length; i++)
//                        {
//                            oPaginas.SetValue(ArregloBytes[i], i);

//                        }

//                        ///OJOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO////
//                        //Aqui le informo a sauce que se conecto el chip 
//                        if (EnviarBytesLecturaChipPorDti != null)
//                        {
//                            EnviarBytesLecturaChipPorDti(oPaginas, Puerto, IdDispositivoDti);

//                        }
//                    }
//                    else//Cuando entra aqui es porque se desconecto el chip y recibi la trama I#.NC ()
//                    {

//                        Temporal = new byte[5]; //Aqui saco la informacion del Puerto y el donde se deconecto el chip
//                        for (int i = 0; i <= 4; i++)
//                        {
//                            Temporal[i] = ArregloBytes[i];
//                        }


//                        System.Array oPaginas;
//                        oPaginas = System.Array.CreateInstance(typeof(byte), Temporal.Length);

//                        for (int i = 0; i < Temporal.Length; i++)
//                        {
//                            oPaginas.SetValue(Temporal[i], i);

//                        }

//                        //Aqui le informo a sauce que se desconecto el chip
//                        if (EnviarBytesLecturaChipPorDti != null)
//                        {
//                            EnviarBytesLecturaChipPorDti(oPaginas, Puerto, IdDispositivoDti);

//                        }

//                    }


//                }



//            }
//            catch (Exception ex)
//            {

//                LogCategorias.Clear();
//                LogCategorias.Agregar("SeguimientoCodigoDTI");
//                LogPropiedades.Clear();
//                LogPropiedades.Agregar("Mensaje", ex.Message);
//                Fabrica.LogIt.Loguear("Error en ExtraerPuerto", LogPropiedades, LogCategorias);
//                throw ex;
//            }
//            return Valores;
//        }

//        //Funcion que envia la informacion con la lectura del chip al Autorizador
//        void EnviarDatosChip(object Parametro)
//        {
//            DatosLector obj = (DatosLector)Parametro;
//            byte[] DatosLeidos = obj.ArregloBytes;
//            try
//            {


//                if (DatosLeidos.Length == 147)
//                    ExtraerInformacionRecibidaDelDispositivoDTI(DatosLeidos);
//                else if (DatosLeidos.Length == 5)
//                    ExtraerInformacionRecibidaDelDispositivoDTI(DatosLeidos);
//                else
//                    throw new Exception("La lectura del chip no se hizo correctamente");


//            }
//            catch (Exception ex)
//            {

//                LogCategorias.Clear();
//                LogCategorias.Agregar("SeguimientoCodigoDTI");
//                LogPropiedades.Clear();
//                LogPropiedades.Agregar("Mensaje", ex.Message);
//                Fabrica.LogIt.Loguear("Error recuperando ROM chip", LogPropiedades, LogCategorias);

//            }

//        }
//        #endregion



//        #region EVENTOS_DE_PUERTOS_COM
//        private void PuertoTerminal_DataReceived(object sender, SerialDataReceivedEventArgs e)
//        {
//            try
//            {
//                string X2 = "";
                
//                byte[] ODatosChip;
//                DatosLector OChipTemporal = new DatosLector();
//                System.Threading.Thread.Sleep(800);
//                Longitud = PuertoTerminal.BytesToRead;
//                ODatosChip = new byte[Longitud];
//                PuertoTerminal.Read(ODatosChip, 0, Longitud);
//                PuertoTerminal.DiscardInBuffer();
//                PuertoTerminal.DiscardOutBuffer();
//                for (int i = 0; i < ODatosChip.Length; i++)
//                {
//                    X2 += ODatosChip[i].ToString("X2");
//                }

//                LogCategorias.Clear();
//                LogCategorias.Agregar("SeguimientoPuertoDTI");
//                LogPropiedades.Clear();
//                LogPropiedades.Agregar("Mensaje", "Byte recibidos datos recibidos del puerto " + Puerto + " Numero de Bytes: " + ODatosChip.Length.ToString());
//                LogPropiedades.Agregar("Fecha", System.DateTime.Now.ToString());
//                LogPropiedades.Agregar("Bytes Recibidos", X2);
//                Fabrica.LogIt.Loguear("Logueado PuertoTerminal_DataReceived DTI", LogPropiedades, LogCategorias);


//                if (ODatosChip.Length == 5)
//                {

//                    LogCategorias.Clear();
//                    LogCategorias.Agregar("SeguimientoPuertoDTI");
//                    LogPropiedades.Clear();
//                    LogPropiedades.Agregar("Mensaje", "Desconexion" + Puerto + " Numero de Bytes: " + ODatosChip.Length.ToString());
//                    LogPropiedades.Agregar("Fecha", System.DateTime.Now.ToString());
//                    LogPropiedades.Agregar("Bytes Recibidos", X2);
//                    Fabrica.LogIt.Loguear("Logueado PuertoTerminal_DataReceived DTI", LogPropiedades, LogCategorias);


//                    OChipTemporal.ArregloBytes = ODatosChip;
//                    System.Threading.ParameterizedThreadStart Parametro = new ParameterizedThreadStart(EnviarDatosChip);
//                    System.Threading.Thread Hilo = new System.Threading.Thread(Parametro);
//                    Hilo.Start(OChipTemporal);
//                    Hilo.Join();

//                }
//                else if (ODatosChip.Length == 147)
//                {

//                    LogCategorias.Clear();
//                    LogCategorias.Agregar("SeguimientoPuertoDTI");
//                    LogPropiedades.Clear();
//                    LogPropiedades.Agregar("Mensaje", "Lectura Correcta" + Puerto + " Numero de Bytes: " + ODatosChip.Length.ToString());
//                    LogPropiedades.Agregar("Fecha", System.DateTime.Now.ToString());
//                    LogPropiedades.Agregar("Bytes Recibidos", X2);
//                    Fabrica.LogIt.Loguear("Logueado PuertoTerminal_DataReceived DTI", LogPropiedades, LogCategorias);


//                    OChipTemporal.ArregloBytes = ODatosChip;
//                    System.Threading.ParameterizedThreadStart Parametro = new ParameterizedThreadStart(EnviarDatosChip);
//                    System.Threading.Thread Hilo = new System.Threading.Thread(Parametro);
//                    Hilo.Start(OChipTemporal);
//                    Hilo.Join();
//                }
//                else
//                {
//                    if (ODatosChip.Length>=2)
//                    {
//                        LogCategorias.Clear();
//                        LogCategorias.Agregar("SeguimientoPuertoDTI");
//                        LogPropiedades.Clear();
//                        LogPropiedades.Agregar("Mensaje", "Los bytes de la lectura del chip no esta completos Reintento");
//                        LogPropiedades.Agregar("Fecha", System.DateTime.Now.ToString());
//                        LogPropiedades.Agregar("Bytes Recibidos", X2);
//                        LogPropiedades.Agregar("Bytes Length", ODatosChip.Length.ToString());
//                        Fabrica.LogIt.Loguear("Logueado PuertoTerminal_DataReceived DTI", LogPropiedades, LogCategorias);
//                        Byte[] Lector = new Byte[5] { 0x49, 0x3F, ODatosChip[1], 0x15, 0x7E };
//                        System.Threading.Thread.Sleep(1000);
//                        PuertoTerminal.Write(Lector, 0, Lector.Length);
//                        System.Threading.Thread.Sleep(1000);
//                    }
                   
//                }
//            }
//            catch (Exception ex)
//            {

//                LogCategorias.Clear();
//                LogCategorias.Agregar("SeguimientoCodigoDTI");
//                LogPropiedades.Clear();
//                LogPropiedades.Agregar("Mensaje", ex.Message);
//                Fabrica.LogIt.Loguear("Error recuperando ROM chip PuertoTerminal_DataReceived", LogPropiedades, LogCategorias);

//            }
            

//        }




//        public void CerrarPuerto() 
//        {
//            try
//            {
//                PuertoTerminal.Close();      
       
//            }
//            catch (Exception ex)
//            {                              
//                LogCategorias.Clear();
//                LogCategorias.Agregar("SeguimientoCodigoDTI");
//                LogPropiedades.Clear();
//                LogPropiedades.Agregar("Mensaje", ex.Message);
//                Fabrica.LogIt.Loguear("Error recuperando ROM chipCerrarPuerto", LogPropiedades, LogCategorias);

//            }
        
//        }

//        public Boolean ConsultarPuerto()
//        {
//            try
//            {   
//                Boolean PuertoAbierto = false;
//                if (PuertoTerminal.IsOpen)
//                {
//                    PuertoAbierto = true;
//                }


//                return PuertoAbierto;
//            }
//            catch (Exception ex)
//            {
//                 LogCategorias.Clear();
//                LogCategorias.Agregar("SeguimientoCodigoDTI");
//                LogPropiedades.Clear();
//                LogPropiedades.Agregar("Mensaje", ex.Message);
//                Fabrica.LogIt.Loguear("Error recuperando ROM chip Consuktar Puerto", LogPropiedades, LogCategorias);
//                throw;
//            }
                        
//        }

//        #endregion


//        //Funcion que se encarga de iniciar los datos de los puerto y otras variables
//        public void ReaderHostMain(string strPuerto, int IdDispositivo)
//        {
//            Puerto = strPuerto;
//            IdDispositivoDti = IdDispositivo;
//            PuertoTerminal = new SerialPort();
//            PuertoTerminal.DataReceived += new SerialDataReceivedEventHandler(PuertoTerminal_DataReceived);

//            //CONFIGURACION DEL PUERTO DE LA TERMINAL REMOTA
//            PuertoTerminal.PortName = Puerto;
//            PuertoTerminal.BaudRate = 9600;
//            PuertoTerminal.DataBits = 8;
//            PuertoTerminal.StopBits = StopBits.One;
//            PuertoTerminal.Parity = Parity.None;
//            PuertoTerminal.ReadBufferSize = 4096;



//            try
//            {
//                if (PuertoTerminal.IsOpen)
//                {
//                    PuertoTerminal.Close();
//                }
//                PuertoTerminal.Open();
//            }
//            catch (Exception ex)
//            {
//                throw ex; //throw new Exception ("Comunicacion con surtidor no disponible");
//            }

//        }

//    }

//    class DatosLector
//    {
//        public byte[] ArregloBytes { get; set; }

//    }
//}
