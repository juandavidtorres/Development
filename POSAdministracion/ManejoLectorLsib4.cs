using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSstation.Fabrica;
using POSstation.AccesoDatos;
using POSstation;
using POSstation.Protocolos;
using System.IO.Ports;



namespace gasolutions.UInterface
{
    class ManejoLectorLsib4 : POSstation.Protocolos.LSIB4Interfaz
    {
        #region EVENTOS
        public event LSIB4Interfaz.EnviarBytesLecturaChipPorDtiEventHandler EnviarBytesLecturaChipPorDti;
        #endregion

        SerialPort PuertoTerminal;
        Helper oDataAccess = new Helper();
        private PropiedadesExtendidas LogPropiedades = new PropiedadesExtendidas();
        private CategoriasLog LogCategorias = new CategoriasLog();
        private int Longitud;
        string Puerto;//El puerto COM       
        int IdDispositivoDti;
        string[] TramaElementos = new string[1];
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
                POSstation.Fabrica.LogIt.Loguear("Logueando el numero de bytes recibidos de la dti", LogPropiedades, LogCategorias);


                if (ArregloBytes.Length > 150)//Se realizo una mala conexcion del chip en el lector
                {
                    LogCategorias.Clear();
                    LogCategorias.Agregar("SeguimientoCodigoDTI");
                    LogPropiedades.Clear();
                    LogPropiedades.Agregar("FechaHora:", DateTime.Now.ToString());
                    POSstation.Fabrica.LogIt.Loguear("Logueando la lectura del chip no se hizo correctamente debido que se coloco y se retiro inmediatamente", LogPropiedades, LogCategorias);



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
                        //Aqui le informo a sauce que se conecto el chip 
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

                        //Aqui le informo a sauce que se desconecto el chip
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
                POSstation.Fabrica.LogIt.Loguear("Error en ExtraerPuerto", LogPropiedades, LogCategorias);
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


                if (DatosLeidos.Length == 147)
                    ExtraerInformacionRecibidaDelDispositivoDTI(DatosLeidos);
                else if (DatosLeidos.Length == 5)
                    ExtraerInformacionRecibidaDelDispositivoDTI(DatosLeidos);
                else
                    throw new Exception("La lectura del chip no se hizo correctamente");


            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoCodigoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                POSstation.Fabrica.LogIt.Loguear("Error recuperando ROM chip", LogPropiedades, LogCategorias);

            }

        }
        #endregion



        #region EVENTOS_DE_PUERTOS_COM
        private void PuertoTerminal_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string X2 = "";

                byte[] ODatosChip;
                DatosLector OChipTemporal = new DatosLector();
                System.Threading.Thread.Sleep(800);
                Longitud = PuertoTerminal.BytesToRead;
                ODatosChip = new byte[Longitud];
                PuertoTerminal.Read(ODatosChip, 0, Longitud);
                PuertoTerminal.DiscardInBuffer();
                PuertoTerminal.DiscardOutBuffer();
                for (int i = 0; i < ODatosChip.Length; i++)
                {
                    X2 += ODatosChip[i].ToString("X2");
                }

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoPuertoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", "Byte recibidos datos recibidos del puerto " + Puerto + " Numero de Bytes: " + ODatosChip.Length.ToString());
                LogPropiedades.Agregar("Fecha", System.DateTime.Now.ToString());
                LogPropiedades.Agregar("Bytes Recibidos", X2);
                POSstation.Fabrica.LogIt.Loguear("Logueado PuertoTerminal_DataReceived DTI", LogPropiedades, LogCategorias);


                if (ODatosChip.Length == 5)
                {

                    LogCategorias.Clear();
                    LogCategorias.Agregar("SeguimientoPuertoDTI");
                    LogPropiedades.Clear();
                    LogPropiedades.Agregar("Mensaje", "Desconexion" + Puerto + " Numero de Bytes: " + ODatosChip.Length.ToString());
                    LogPropiedades.Agregar("Fecha", System.DateTime.Now.ToString());
                    LogPropiedades.Agregar("Bytes Recibidos", X2);
                    POSstation.Fabrica.LogIt.Loguear("Logueado PuertoTerminal_DataReceived DTI", LogPropiedades, LogCategorias);


                    //OChipTemporal.ArregloBytes = ODatosChip;
                    //System.Threading.ParameterizedThreadStart Parametro = new ParameterizedThreadStart(EnviarDatosChip);
                    //System.Threading.Thread Hilo = new System.Threading.Thread(Parametro);
                    //Hilo.Start(OChipTemporal);
                    //Hilo.Join();

                }
                else if (ODatosChip.Length == 147)
                {

                    LogCategorias.Clear();
                    LogCategorias.Agregar("SeguimientoPuertoDTI");
                    LogPropiedades.Clear();
                    LogPropiedades.Agregar("Mensaje", "Lectura Correcta" + Puerto + " Numero de Bytes: " + ODatosChip.Length.ToString());
                    LogPropiedades.Agregar("Fecha", System.DateTime.Now.ToString());
                    LogPropiedades.Agregar("Bytes Recibidos", X2);
                    POSstation.Fabrica.LogIt.Loguear("Logueado PuertoTerminal_DataReceived DTI", LogPropiedades, LogCategorias);


                    //OChipTemporal.ArregloBytes = ODatosChip;
                    //System.Threading.ParameterizedThreadStart Parametro = new ParameterizedThreadStart(EnviarDatosChip);
                    //System.Threading.Thread Hilo = new System.Threading.Thread(Parametro);
                    //Hilo.Start(OChipTemporal);
                    //Hilo.Join();
                }
                else
                {
                    if (ODatosChip.Length >= 2)
                    {
                        LogCategorias.Clear();
                        LogCategorias.Agregar("SeguimientoPuertoDTI");
                        LogPropiedades.Clear();
                        LogPropiedades.Agregar("Mensaje", "Los bytes de la lectura del chip no esta completos Reintento");
                        LogPropiedades.Agregar("Fecha", System.DateTime.Now.ToString());
                        LogPropiedades.Agregar("Bytes Recibidos", X2);
                        LogPropiedades.Agregar("Bytes Length", ODatosChip.Length.ToString());
                        POSstation.Fabrica.LogIt.Loguear("Logueado PuertoTerminal_DataReceived DTI", LogPropiedades, LogCategorias);
                        Byte[] Lector = new Byte[5] { 0x49, 0x3F, ODatosChip[1], 0x15, 0x7E };
                        System.Threading.Thread.Sleep(1000);
                        PuertoTerminal.Write(Lector, 0, Lector.Length);
                        System.Threading.Thread.Sleep(1000);
                    }

                }
            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoCodigoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                POSstation.Fabrica.LogIt.Loguear("Error recuperando ROM chip PuertoTerminal_DataReceived", LogPropiedades, LogCategorias);

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
                POSstation.Fabrica.LogIt.Loguear("Error recuperando ROM chipCerrarPuerto", LogPropiedades, LogCategorias);

            }

        }

        #endregion


        //Funcion que se encarga de iniciar los datos de los puerto y otras variables
        public void ReaderHostMain(string strPuerto, int IdDispositivo)
        {
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
            PuertoTerminal.ReadBufferSize = 4096;



            try
            {
                PuertoTerminal.Open();
            }
            catch (Exception ex)
            {
                throw ex; //throw new Exception ("Comunicacion con surtidor no disponible");
            }





        }

    }

    class DatosLector
    {
        public byte[] ArregloBytes { get; set; }

    }
}
