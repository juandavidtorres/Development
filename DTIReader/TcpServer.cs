using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using POSstation.Fabrica;


// State object for reading client data asynchronously

namespace POSstation
{
    public class StateObject
    {
        // Client  socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 148;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

    public class TcpServer
    {
        // Thread signal.
        public ManualResetEvent allDone = new ManualResetEvent(false);
        private bool ExisteLectura;
        public const int BUFFER_SIZE = 148;
        public delegate void OEventos_EnviarBytesLecturaChipPorLSIB4(System.Array Lectura, string puerto, int IdDispositivoLSIB4);
        public event OEventos_EnviarBytesLecturaChipPorLSIB4 EventoEnviarBytesLecturaChipPorLSIB4;
        PropiedadesExtendidas LogPropiedades = new PropiedadesExtendidas();
        CategoriasLog LogCategorias = new CategoriasLog();
        int IdDispositivoLSIB4;
        string _Ip, Puerto;

        public TcpServer(string Puerto, int IdDispositivo)
        {
            try
            {
                
                this.Puerto = Puerto;
                IdDispositivoLSIB4 = IdDispositivo;     
                IPAddress[] ipv4Addresses = Array.FindAll( Dns.GetHostEntry(string.Empty).AddressList, a => a.AddressFamily == AddressFamily.InterNetwork);
                _Ip = ipv4Addresses[0].ToString();

            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("Anomalia");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                POSstation.Fabrica.LogIt.Loguear("Excepcion Iniciando Servidor Tcp", LogPropiedades, LogCategorias);
            }
        }


      

        public void IniciarServidor()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(IniciarProtocolo), 0);
        }

        private void IniciarProtocolo(object val)
        {
            try
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("LogueoLSIB4");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje","Inicia ComunicacionIP");
                LogPropiedades.Agregar("IP", _Ip);
                LogPropiedades.Agregar("Puerto", Puerto);
                POSstation.Fabrica.LogIt.Loguear("Mensaje: Iniciando Servidor Tcp", LogPropiedades, LogCategorias);

                byte[] bytes = new Byte[1024];
                // Establish the local endpoint for the socket.      

                IPAddress ipAddress = IPAddress.Parse(_Ip);
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, Convert.ToInt32(Puerto));

                // Create a TCP/IP socket.
                Socket listener = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Bind the socket to the local endpoint and listen for incoming connections.


                listener.Bind(localEndPoint);
                listener.Listen(100);

                LogCategorias.Clear();
                LogCategorias.Agregar("LogueoLSIB4");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", "Despues del metodo Listen ComunicacionIP");
                POSstation.Fabrica.LogIt.Loguear("Mensaje: Iniciando Servidor Tcp", LogPropiedades, LogCategorias);


                while (true)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();


                }

            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("ServidorTcp");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                POSstation.Fabrica.LogIt.Loguear("Excepcion IniciarProtocolo Tcp", LogPropiedades, LogCategorias);
            }



        }

        public void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                // Signal the main thread to continue.
                allDone.Set();

                // Get the socket that handles the client request.
                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);

                // Create the state object.
                StateObject state = new StateObject();
                state.workSocket = handler;
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);

            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("ServidorTcp");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                POSstation.Fabrica.LogIt.Loguear("Excepcion AcceptCallback Tcp", LogPropiedades, LogCategorias);
            }

        }

        public void ReadCallback(IAsyncResult ar)
        {
            Socket handler = null;
            try
            {
                String content = String.Empty;
                string X2;
                // Retrieve the state object and the handler socket
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                handler = state.workSocket;

                // Read data from the client socket. 
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There  might be more data, so store the data received so far.
                    state.sb.Append(Encoding.ASCII.GetString(
                        state.buffer, 0, bytesRead));

                    // Check for end-of-file tag. If it is not there, read 
                    // more data.
                    content = state.sb.ToString();
                    if (content.IndexOf("~") > -1)
                    {
                        // All the data has been read from the 
                        // client. Display it on the console.           
                        ExisteLectura = true;

                        if (ExisteLectura == true)
                        {
                            foreach (DatosLectura item in DatosLectura(state.buffer))
                            {
                                if (item.Length == 6 || item.Length == 148)
                                {
                                    LogCategorias.Clear();
                                    LogCategorias.Agregar("ServidorTcp");
                                    LogPropiedades.Clear();
                                    LogPropiedades.Agregar("Buffer", Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                                    POSstation.Fabrica.LogIt.Loguear("Captura del buffer", LogPropiedades, LogCategorias);

                                    LogCategorias.Clear();
                                    LogCategorias.Agregar("ServidorTcp");
                                    LogPropiedades.Clear();
                                    LogPropiedades.Agregar("Item", Encoding.ASCII.GetString(item.Lectura, 0, bytesRead));
                                    POSstation.Fabrica.LogIt.Loguear("Captura del Item", LogPropiedades, LogCategorias);

                                    ProcesarLectura(item.Lectura, ref handler);


                                }
                                else
                                {
                                    if (item.Length > 2)
                                    {
                                        Byte[] Lector = new Byte[5] { 0x49, 0x3F, item.Lectura[1], 0x15, 0x7E };
                                        X2 = "";
                                        for (int i = 0; i < Lector.Length; i++)
                                        {
                                            X2 += Lector[i].ToString("X2");
                                        }


                                    }
                                }

                            }

                        }

                        handler.Disconnect(false);

                    }
                    else
                    {
                        // Not all data received. Get more.
                        System.Threading.Thread.Sleep(200);
                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReadCallback), state);
                    }
                }

            }
            catch (Exception ex)
            {
                try
                {
                    if (handler != null)
                    {
                        if (handler.Connected)
                        {
                            handler.Disconnect(false);
                        }


                    }
                }
                catch (Exception)
                {
                    LogCategorias.Clear();
                    LogCategorias.Agregar("ServidorTcp");
                    LogPropiedades.Clear();
                    LogPropiedades.Agregar("Mensaje", ex.Message);
                    POSstation.Fabrica.LogIt.Loguear("Excepcion ReadCallback Catch Servidor Tcp", LogPropiedades, LogCategorias);

                }


                LogCategorias.Clear();
                LogCategorias.Agregar("ServidorTcp");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                POSstation.Fabrica.LogIt.Loguear("Excepcion ReadCallback Servidor Tcp", LogPropiedades, LogCategorias);
            }

        }

        private void Send(Socket handler, String data)
        {
            try
            {

                // Convert the string data to byte data using ASCII encoding.
                byte[] byteData = Encoding.ASCII.GetBytes(data);

                // Begin sending the data to the remote device.
                handler.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendCallback), handler);
            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("ServidorTcp");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                POSstation.Fabrica.LogIt.Loguear("Excepcion Send Servidor Tcp", LogPropiedades, LogCategorias);
            }


        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);


                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("ServidorTcp");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                POSstation.Fabrica.LogIt.Loguear("Excepcion Send Servidor Tcp", LogPropiedades, LogCategorias);
            }
        }



        public void ProcesarLectura(byte[] item, ref Socket handler)
        {
            Encoding encode = Encoding.ASCII;
            string X2 = "", strContent = "";
            try
            {


                if (item.Length == 148)
                {

                    strContent = encode.GetString(item, 0, item.Length).ToString();

                    X2 = "";
                    for (int i = 0; i < item.Length; i++)
                    {
                        X2 += item[i].ToString("X2");
                    }



                    byte[] Trama = new byte[147];
                    for (int y = 0; y < item.Length - 1; y++)
                    {

                        Trama[y] = item[y];

                    }

                    ExtraerInformacionRecibidaDelDispositivoLSIB4(Trama);

                }
                else if (item.Length == 6)
                {

                    strContent = encode.GetString(item, 0, item.Length).ToString();

                    X2 = "";
                    for (int i = 0; i < item.Length - 1; i++)
                    {
                        X2 += item[i].ToString("X2");
                    }





                    byte[] Trama = new byte[5];
                    for (int y = 0; y < item.Length - 1; y++)
                    {

                        Trama[y] = item[y];

                    }

                    ExtraerInformacionRecibidaDelDispositivoLSIB4(Trama);


                }

            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("ServidorTcp");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                POSstation.Fabrica.LogIt.Loguear("Excepcion Procesar Lecturas Servidor Tcp", LogPropiedades, LogCategorias);
            }

        }


        private string[] ExtraerInformacionRecibidaDelDispositivoLSIB4(byte[] ArregloBytes)
        {
            byte[] Temporal;
            string TempPuerto = string.Empty;
            string[] Valores = new string[1];
            int j = 0;

            try
            {


                if (ArregloBytes.Length > 150)//Se realizo una mala conexcion del chip en el lector
                {
                    LogCategorias.Clear();
                    LogCategorias.Agregar("ServidorTcp");
                    LogPropiedades.Clear();
                    LogPropiedades.Agregar("Mensaje", "Lectura incorrecta");
                    POSstation.Fabrica.LogIt.Loguear("Validacion de los datos recibidos", LogPropiedades, LogCategorias);

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
                        EventoEnviarBytesLecturaChipPorLSIB4(oPaginas, Puerto, IdDispositivoLSIB4);


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
                        EventoEnviarBytesLecturaChipPorLSIB4(oPaginas, Puerto.ToString(), IdDispositivoLSIB4);


                    }


                }



            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("ServidorTcp");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                POSstation.Fabrica.LogIt.Loguear("Excepcion en ExtraerInformacionRecibidaDelDispositivoLSIB4", LogPropiedades, LogCategorias);

            }
            return Valores;
        }

        private List<DatosLectura> DatosLectura(byte[] lectura)
        {
            List<DatosLectura> lista = new List<DatosLectura>();

            try
            {

                byte[] Temporal = new byte[BUFFER_SIZE];
                byte[] Datos = new byte[BUFFER_SIZE];

                for (int i = 0; i < 147; i++)
                {
                    Temporal[i] = lectura[i];
                }

                int j = 0;
                if (Temporal[0] != 73)
                {
                    Datos[0] = 73;
                    for (int i = 1; i < Temporal.Length; i++)
                    {
                        Datos[i] = Temporal[j];
                        j++;
                    }
                }
                else
                {
                    Datos = Temporal;
                }

                if (Datos[5] == 126 && Datos[11] == 126)
                {
                    byte[] lectura1 = new byte[6];
                    byte[] lectura2 = new byte[6];
                    int x = 0;
                    for (int i = 0; i <= 5; i++)
                    {
                        lectura1[x] = Datos[i];
                        x++;
                    }

                    x = 0;
                    for (int i = 6; i <= 11; i++)
                    {
                        lectura2[x] = Datos[i];
                        x++;
                    }

                    DatosLectura valor_1 = new DatosLectura();
                    valor_1.Lectura = lectura1;
                    valor_1.Length = lectura1.Length;
                    lista.Add(valor_1);

                    DatosLectura valor_2 = new DatosLectura();
                    valor_2.Lectura = lectura2;
                    valor_2.Length = lectura2.Length;
                    lista.Add(valor_2);

                }
                else if (Datos[5] == 126)
                {

                    byte[] lectura3 = new byte[6];
                    int x = 0;
                    for (int i = 0; i <= 5; i++)
                    {
                        lectura3[x] = Datos[i];
                        x++;
                    }

                    DatosLectura valor_3 = new DatosLectura();
                    valor_3.Lectura = lectura3;
                    valor_3.Length = lectura3.Length;
                    lista.Add(valor_3);

                }
                else
                {
                    DatosLectura valor_4 = new DatosLectura();
                    valor_4.Lectura = Datos;
                    valor_4.Length = Datos.Length;
                    lista.Add(valor_4);

                }


                return lista;

            }
            catch (Exception ex)
            {


                LogCategorias.Clear();
                LogCategorias.Agregar("ServidorTcp");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                POSstation.Fabrica.LogIt.Loguear("Excepcion en DatosLectura", LogPropiedades, LogCategorias);


                return lista;
            }


        }


    }


    public class DatosLectura
    {

        private byte[] _lectura;
        public byte[] Lectura
        {
            get { return _lectura; }
            set { _lectura = value; }
        }

        private int _Lenght;
        public int Length
        {
            get { return _Lenght; }
            set { _Lenght = value; }
        }

    }
}