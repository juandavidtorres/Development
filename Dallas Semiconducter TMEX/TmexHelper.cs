using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using POSstation.Fabrica;
using POSstation.Encripcion;
namespace POSstation.Tmex
{
    public enum MainSwicthState { On = 0xA5, Off = 0xCC }
    public enum TypeAdapter : short { DS9097E = 1, Parallel = 2, DS9097U = 5, Usb = 6 }


    public class TmexHelper
    {
        private int _session;
        byte[] _buffer = new byte[15360];
        private ArrayList _idLectores = new ArrayList();
        public PropiedadesExtendidas LogPropiedades = new PropiedadesExtendidas();
        public CategoriasLog LogCategorias = new CategoriasLog();

        #region funciones de la TMEX
        //---------------------------------------------------------------------------
        [DllImport("IBFS32.dll")]
        public static extern int TMExtendedStartSession(
            int portNum, int portType, int[] sessionOptions);

        [DllImport("IBFS32.dll")]
        public static extern short TMEndSession(int sessionHandle);

        [DllImport("IBFS32.dll")]
        public static extern short TMFirst(
            int sessionHandle, byte[] stateBuffer);

        [DllImport("IBFS32.dll")]
        public static extern short TMNext(
            int sessionHandle, byte[] stateBuffer);

        [DllImport("IBFS32.dll")]
        public static extern short TMAccess(
            int sessionHandle, byte[] stateBuffer);

        [DllImport("IBFS32.dll")]
        public static extern short TMStrongAccess(
            int sessionHandle, byte[] stateBuffer);

        [DllImport("IBFS32.dll")]
        public static extern short TMRom(
            int sessionHandle, byte[] stateBuffer, short[] rom);

        [DllImport("IBFS32.dll")]
        public static extern short TMReadPacket(
            int sessionHandle, byte[] stateBuffer,
            short startPage, byte[] readBuffer, short maxRead);

        [DllImport("IBFS32.dll")]
        public static extern short TMSetup(
            int sessionHandle);

        [DllImport("IBFS32.dll")]
        public static extern short TMTouchByte(
            int sessionHandle, short bytValue);

        [DllImport("IBFS32.dll")]
        public static extern short TMOneWireCom(
            int sessionHandle, short command, short argument);

        [DllImport("IBFS32.dll")]
        public static extern short TMClose(
            int sessionHandle);

        //---------------------------------------------------------------------------
        #endregion

        #region Publicos
        public ArrayList BuscarLectores(string puerto)
        {
            try
            {
                ArrayList ColLectores = RecuperarListaDS(puerto, TypeAdapter.DS9097U);

                return ColLectores;
            }
            catch
            {
                throw;
            }
        }



        public DS1992 LeerBoton(ArrayList listaDS, string puerto, string idRom2409, TypeAdapter tipo, Int16 cantidadBytes)
        {
            try
            {
                _idLectores = listaDS;

                DS1992 datos = new DS1992();

                //Aqui quedan la informacion del boton en la variable datos
                LeerDS1992(idRom2409, datos, puerto, tipo, cantidadBytes);

                //reviso que el chip haya sido leido
                Boolean EsLeido = false;


                for (Int32 I = 0; I < datos.contenido.Length; I++)
                {
                    if (datos.contenido[I] != 0)
                    {
                        EsLeido = true;
                        break;
                    }
                }

                /********************************************************************************************************/
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoCodigo");
                LogPropiedades.Clear();
                 POSstation.Fabrica.LogIt.Loguear("Despues de LeerDS1992", LogPropiedades, LogCategorias);
                /***************************************************************************************************/

                if (EsLeido)
                {
                    return datos;
                }
                else
                {
                    //TODO: cambia por excepcion de tipo
                    throw new POSstation.Tmex.TmexVersionException();
                }
            }
            catch
            {
                throw;
            }
        }

        public InformacionChip LeerBotonGasolina(ArrayList listaDS, string puerto, string idRom2409, TypeAdapter tipo)
        {

            try
            {
                _idLectores = listaDS;

                try
                {
                    return LeerDS1992VersionGasolinaIDROM(idRom2409, puerto, tipo);
                }
                catch (POSstation.Tmex.TmexVersionException)
                {
                    throw;
                }
            }
            catch
            {
                throw;
            }
        }

        public InformacionChip LeerBotonSuic(ArrayList listaDS, string puerto, string idRom2409, TypeAdapter tipo)
        {

            try
            {
                _idLectores = listaDS;


                return LeerDS1992VersionSuic(idRom2409, puerto, tipo);
            }
            catch (POSstation.Tmex.TmexVersionException)
            {
                throw;
            }

        }

        public Boolean UbicarDispositivo(string idRom, string puerto, TypeAdapter tipo)
        {
            try
            {
                return ExisteDispositivo(idRom, puerto, tipo);
            }
            catch
            {
                throw;
            }
        }

        public ArrayList RecuperarListaDS(string puerto, TypeAdapter tipo)
        {
            try
            {
                ArrayList codes = new ArrayList();

                //CAMBIADO SE ANULO LA INICIALIZACION DE SESSION
                //IniciarSesion(puerto, tipo);

                short ret = TMFirst(_session, _buffer);
                /********************************************************************************************************/
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoCodigo");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("ret", ret.ToString());
                POSstation.Fabrica.LogIt.Loguear("Luego del tmfirst", LogPropiedades, LogCategorias);
                /***************************************************************************************************/
                if (ret == 1)
                {


                    codes = new ArrayList();
                    while ((ret == 1) && (codes.Count < 32))
                    {
                        // if MSB of ROM[0] != 0, then write, else read
                        short[] ROM = new short[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                        TMRom(_session, _buffer, ROM);

                        /********************************************************************************************************/
                        LogCategorias.Clear();
                        LogCategorias.Agregar("SeguimientoCodigo");
                        LogPropiedades.Clear();
                        LogPropiedades.Agregar("ret", ret.ToString());
                          POSstation.Fabrica.LogIt.Loguear("Luego del tmrom", LogPropiedades, LogCategorias);
                        /***************************************************************************************************/


                        // convert the ROM code into a string
                        StringBuilder romCode = new StringBuilder();
                        for (int i = 7; i >= 0; i--)
                            romCode.Append(ROM[i].ToString("X2"));

                        /********************************************************************************************************/
                        LogCategorias.Clear();
                        LogCategorias.Agregar("SeguimientoCodigo");
                        LogPropiedades.Clear();
                        LogPropiedades.Agregar("ds2409", romCode.ToString());
                          POSstation.Fabrica.LogIt.Loguear("Anexa 2409 a la lista", LogPropiedades, LogCategorias);
                        /********************************************************************************************************/

                        codes.Add(romCode.ToString());
                        ret = TMNext(_session, _buffer);
                        /********************************************************************************************************/
                        LogCategorias.Clear();
                        LogCategorias.Agregar("SeguimientoCodigo");
                        LogPropiedades.Clear();
                        LogPropiedades.Agregar("ret", ret.ToString());
                          POSstation.Fabrica.LogIt.Loguear("Luego del tmnext", LogPropiedades, LogCategorias);
                        /***************************************************************************************************/

                    }

                    if (codes.Count > 0)
                    {
                        _idLectores = new ArrayList();
                        foreach (string id in codes)
                            if (id.Substring(14, 2) == "1F")
                                _idLectores.Add(id);
                    }
                }

                //CAMBIADO SE ANULO LA FINALIZACION DE SESSION
                //FinalizarSesion();
                return codes;
            }
            catch
            {
                //CAMBIADO SE ANULO LA FINALIZACION DE SESSION
                //  FinalizarSesion();
                throw;
            }
        }

        public String RetornarFamilia(String idRom)
        {
            try
            {
                String family = null;
                if (idRom.Length > 2)
                    family = idRom.Substring(idRom.Length - 2, 2);
                return family;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Privados
        public void IniciarSesion(string puerto, TypeAdapter tipo)
        {
            short port = System.Convert.ToInt16(puerto.Substring(3));
            short portType = (short)tipo;

            short result;
            try
            {
                /********************************************************************************************************/
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoCodigo");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Puerto", puerto);
                LogPropiedades.Agregar("Sesion", _session.ToString());
                  POSstation.Fabrica.LogIt.Loguear("Ingresa a iniciarsesion", LogPropiedades, LogCategorias);
                /***************************************************************************************************/

                if (_session == 0)
                {
                    _session = TMExtendedStartSession(port, portType, null);
                    if (_session > 0)
                    {
                        /********************************************************************************************************/
                        LogCategorias.Clear();
                        LogCategorias.Agregar("SeguimientoCodigo");
                        LogPropiedades.Clear();
                        LogPropiedades.Agregar("Puerto", puerto);
                        LogPropiedades.Agregar("Sesion", _session.ToString());
                          POSstation.Fabrica.LogIt.Loguear("Abre Sesion", LogPropiedades, LogCategorias);
                        /***************************************************************************************************/
                        result = TMSetup(_session);

                        /********************************************************************************************************/
                        LogCategorias.Clear();
                        LogCategorias.Agregar("SeguimientoCodigo");
                        LogPropiedades.Clear();
                        LogPropiedades.Agregar("result", result.ToString());
                        LogPropiedades.Agregar("Sesion", _session.ToString());
                          POSstation.Fabrica.LogIt.Loguear("TMSETUP", LogPropiedades, LogCategorias);
                        /***************************************************************************************************/
                        switch (result)
                        {
                            case 1:
                                if (TMOneWireCom(_session, 0, 2) >= 0)
                                    break;
                                else
                                    throw new TmexStartSessionException("Puerto: " + port.ToString() + " Error Setteando OverDrive");
                            case 0:
                                throw new TmexStartSessionException("Puerto: " + port.ToString() + " Setup Falló");
                            case 2:
                                throw new TmexStartSessionException("Puerto: " + port.ToString() + " Corto en Microlan");
                            case 3:
                                throw new TmexStartSessionException("Puerto: " + port.ToString() + " Microlan no Existe");
                            case 4:
                                throw new TmexStartSessionException("Puerto: " + port.ToString() + " Setup No soportado");
                            case -1:
                                throw new TmexStartSessionException("Puerto: " + port.ToString() + " Puerto no inicializado con función TMSetup");
                            case -2:
                                throw new TmexStartSessionException("Puerto: " + port.ToString() + " Puerto no existe");
                            case -3:
                                throw new TmexStartSessionException("Puerto: " + port.ToString() + " Función no soportada");
                            case -12:
                                throw new TmexStartSessionException("Puerto: " + port.ToString() + " Falla al comunicar con el adaptador (Hardware)");
                            case -13:
                                throw new TmexStartSessionException("Puerto: " + port.ToString() + " Evento no esperado");
                            case -200:
                                throw new TmexStartSessionException("Puerto: " + port.ToString() + " Session Inválida");
                            case -201:
                                throw new TmexStartSessionException("Puerto: " + port.ToString() + " Driver no encontrado");
                        }
                    }

                    else if (_session == 0)
                    {
                        throw new TmexStartSessionException("Puerto: " + port.ToString() + " No Disponible");
                    }
                    else if (_session < 0)
                    {
                        throw new TmexStartSessionException("Puerto: " + port.ToString() + " No Abre Session");
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void FinalizarSesion()
        {
            try
            {
                if (_session > 0)
                {
                    TMEndSession(_session);
                    _session = 0;
                }
            }
            catch
            {
                throw;
            }
        }

        private Boolean ReadPage(Int32 page, Byte[] data, Int32 longitud, int hSess, byte[] stateBuffer)
        {
            Int32 I;

            if (longitud <= 32)
            {
                TMAccess(hSess, stateBuffer);
                TMTouchByte(hSess, 240);
                TMTouchByte(hSess, (Int16)((page * 32) & 0xFF));
                TMTouchByte(hSess, (Int16)((page * 32) >> 8));
                for (I = 1; I <= longitud; I++)
                {
                    data[I] = (Byte)TMTouchByte(hSess, 255);
                }
                return true;
            }
            else
                return false;
        }

        private InformacionChip LeerDS1992VersionGasolina(string idRom, string puerto, TypeAdapter tipo)
        {
            String strSalida = "";
            Byte[] alldata = new Byte[256];
            Byte[] data1 = new Byte[33];
            Int32 b;
            Int32 a;
            InformacionChip oInformacion = new InformacionChip(); ;

            try
            {
                IniciarSesion(puerto, tipo);

                short[] ROM = new short[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                for (int i = 7; i >= 0; i--)
                {
                    short hex = (short)HexToDec(idRom.Substring(i * 2, 2));
                    ROM[7 - i] = hex;
                }

                bool state = CerrarCircuito(idRom);

                if (state)
                {
                    short ret = TMRom(_session, _buffer, ROM);
                    if (ret == 1)
                    {
                        ret = TMFirst(_session, _buffer);
                        if (ret == 1)
                        {
                            ROM = new short[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                            ret = TMRom(_session, _buffer, ROM);
                            char[] buf;
                            buf = new char[32];
                            Int16 X;

                            StringBuilder idRomButton = new StringBuilder();

                            while (ROM[0] != 2 && ROM[0] != 4 && ROM[0] != 6 && ROM[0] != 8 && ROM[0] != 20)
                            {

                                ret = TMNext(_session, _buffer);
                                if (ret == 1)
                                {
                                    ROM = new short[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                                    ret = TMRom(_session, _buffer, ROM);
                                }
                                else
                                {
                                    if (ret != 1)
                                    {
                                        //throw new GasolutionsException("No hay un Chip Conectado");
                                        throw new ChipNoConectadoException();
                                    }
                                }
                            }

                            for (int i = 7; i >= 0; i--)
                                idRomButton.Append(ROM[i].ToString("X2"));

                            oInformacion.Compañia = "GS";
                            oInformacion.Contrato = "";
                            oInformacion.FechaConversion = System.DateTime.Now;
                            oInformacion.FechaProximoMantenimiento = System.DateTime.Now;
                            oInformacion.Numero = 123456;
                            oInformacion.Placa = null;
                            oInformacion.Rom = idRomButton.ToString();
                            oInformacion.Serie = "GS";

                            LogCategorias.Clear();
                            LogCategorias.Agregar("SeguimientoCodigo");
                            LogPropiedades.Clear();
                            LogPropiedades.Agregar("Rom", oInformacion.Rom);
                              POSstation.Fabrica.LogIt.Loguear("Recupera Datos Chip", LogPropiedades, LogCategorias);

                            //ABRE el switch abierto
                            ConfigurarInterruptor(idRom, MainSwicthState.Off);
                            state = true;
                        }
                        else
                            state = false;
                    }
                    else
                        state = false;

                    CerrarCircuito("");
                }
                else
                    state = false;
                FinalizarSesion();

                if (state == false)
                {
                    throw new GasolutionsException("Revise la red de lectores, problemas al iniciar la sesion");
                }
                else
                {
                    return oInformacion;
                }
            }
            catch
            {
                FinalizarSesion();
                throw;
            }
        }




        private InformacionChip LeerDS1992VersionGasolinaIDROM(string idRom, string puerto, TypeAdapter tipo)
        {
            String strSalida = "";
            Byte[] alldata = new Byte[256];
            Byte[] data1 = new Byte[33];
            Int32 b;
            Int32 a;
            InformacionChip oInformacion = new InformacionChip(); ;


            try
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoPR");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Rom", idRom);
                 POSstation.Fabrica.LogIt.Loguear("LeerDS1992VersionGasolinaIDROM", LogPropiedades, LogCategorias);



                IniciarSesion(puerto, tipo);

                short[] ROM = new short[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                for (int i = 7; i >= 0; i--)
                {
                    short hex = (short)HexToDec(idRom.Substring(i * 2, 2));
                    ROM[7 - i] = hex;
                }

                bool state = CerrarCircuito(idRom);

                if (state)
                {
                    short ret = TMRom(_session, _buffer, ROM);
                    if (ret == 1)
                    {
                        ret = TMFirst(_session, _buffer);
                        if (ret == 1)
                        {
                            ROM = new short[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                            ret = TMRom(_session, _buffer, ROM);
                            char[] buf;
                            buf = new char[32];
                            Int16 X;

                            StringBuilder idRomButton = new StringBuilder();

                            while (ROM[0] != 2 && ROM[0] != 1 && ROM[0] != 4 && ROM[0] != 6 && ROM[0] != 8 && ROM[0] != 20)
                            {
                                LogCategorias.Clear();
                                LogCategorias.Agregar("SeguimientoPR");
                                LogPropiedades.Clear();
                                LogPropiedades.Agregar("Rom", idRom);
                                LogPropiedades.Agregar("Rom[0]", ROM[0].ToString());
                                 POSstation.Fabrica.LogIt.Loguear("Entra a While", LogPropiedades, LogCategorias);


                                ret = TMNext(_session, _buffer);
                                if (ret == 1)
                                {
                                    ROM = new short[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                                    ret = TMRom(_session, _buffer, ROM);
                                }
                                else
                                {
                                    if (ret != 1)
                                    {
                                        //throw new GasolutionsException("No hay un Chip Conectado");
                                        throw new ChipNoConectadoException();
                                    }
                                }
                            }

                            LogCategorias.Clear();
                            LogCategorias.Agregar("SeguimientoPR");
                            LogPropiedades.Clear();
                            LogPropiedades.Agregar("Rom", idRom);
                            LogPropiedades.Agregar("Rom[0]", ROM[0].ToString());
                             POSstation.Fabrica.LogIt.Loguear("Entra a PAra de Lectura", LogPropiedades, LogCategorias);


                            for (int i = 7; i >= 0; i--)
                                idRomButton.Append(ROM[i].ToString("X2"));

                            LogCategorias.Clear();
                            LogCategorias.Agregar("SeguimientoPR");
                            LogPropiedades.Clear();
                            LogPropiedades.Agregar("Rom", idRomButton.ToString());
                             POSstation.Fabrica.LogIt.Loguear("Sale de PAra de Lectura", LogPropiedades, LogCategorias);


                            oInformacion.Compañia = "GS";
                            oInformacion.Contrato = "";
                            oInformacion.FechaConversion = System.DateTime.Now;
                            oInformacion.FechaProximoMantenimiento = System.DateTime.Now;
                            oInformacion.Numero = 123456;
                            oInformacion.Placa = null;
                            oInformacion.Rom = idRomButton.ToString();
                            oInformacion.Serie = "GS";

                            LogCategorias.Clear();
                            LogCategorias.Agregar("SeguimientoCodigo");
                            LogPropiedades.Clear();
                            LogPropiedades.Agregar("Rom", oInformacion.Rom);
                             POSstation.Fabrica.LogIt.Loguear("Recupera Datos Chip", LogPropiedades, LogCategorias);

                            //ABRE el switch abierto
                            ConfigurarInterruptor(idRom, MainSwicthState.Off);
                            state = true;
                        }
                        else
                            state = false;
                    }
                    else
                        state = false;

                    CerrarCircuito("");
                }
                else
                    state = false;
                FinalizarSesion();

                if (state == false)
                {
                    throw new GasolutionsException("Revise la red de lectores, problemas al iniciar la sesion");
                }
                else
                {
                    return oInformacion;
                }
            }
            catch
            {
                FinalizarSesion();
                throw;
            }
        }


        private InformacionChip LeerDS1992VersionSuic(string idRom, string puerto, TypeAdapter tipo)
        {
            String strSalida = "";
            Byte[] alldata = new Byte[256];
            Byte[] data1 = new Byte[33];
            Int32 b;
            Int32 a;
            InformacionChip oInformacion = new InformacionChip(); ;
            bool state = false;
            try
            {
                //REFORMADO PARA MANEJO DE SESION UNICA
                //IniciarSesion(puerto, tipo);



                short[] ROM = new short[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                for (int i = 7; i >= 0; i--)
                {
                    short hex = (short)HexToDec(idRom.Substring(i * 2, 2));
                    ROM[7 - i] = hex;
                }

                state = CerrarCircuito(idRom);

                /********************************************************************************************************/
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoCodigo");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Puerto", puerto);
                LogPropiedades.Agregar("Sesion", _session.ToString());
                 POSstation.Fabrica.LogIt.Loguear("Inicia Cerrar Circuito en metodo LeerDS1992VersionSuic", LogPropiedades, LogCategorias);
                /***************************************************************************************************/


                if (state)
                {
                    short ret = TMRom(_session, _buffer, ROM);

                    /********************************************************************************************************/
                    LogCategorias.Clear();
                    LogCategorias.Agregar("SeguimientoCodigo");
                    LogPropiedades.Clear();
                    LogPropiedades.Agregar("Puerto", puerto);
                    LogPropiedades.Agregar("Sesion", _session.ToString());
                    LogPropiedades.Agregar("State", Convert.ToString(state));
                    LogPropiedades.Agregar("Ret", Convert.ToString(ret));
                     POSstation.Fabrica.LogIt.Loguear("Despues de TMRom en LeerDS1992VersionSuic", LogPropiedades, LogCategorias);
                    /***************************************************************************************************/

                    if (ret == 1)
                    {
                        ret = TMFirst(_session, _buffer);
                        /********************************************************************************************************/
                        LogCategorias.Clear();
                        LogCategorias.Agregar("SeguimientoCodigo");
                        LogPropiedades.Clear();
                        LogPropiedades.Agregar("Puerto", puerto);
                        LogPropiedades.Agregar("Sesion", _session.ToString());
                        LogPropiedades.Agregar("State", Convert.ToString(state));
                        LogPropiedades.Agregar("Ret", Convert.ToString(ret));
                         POSstation.Fabrica.LogIt.Loguear("Despues de TMFirst en LeerDS1992VersionSuic", LogPropiedades, LogCategorias);
                        /***************************************************************************************************/

                        if (ret == 1)
                        {
                            ROM = new short[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                            ret = TMRom(_session, _buffer, ROM);
                            char[] buf;
                            buf = new char[32];
                            Int16 X;

                            StringBuilder idRomButton = new StringBuilder();

                            /********************************************************************************************************/
                            LogCategorias.Clear();
                            LogCategorias.Agregar("SeguimientoCodigo");
                            LogPropiedades.Clear();
                            LogPropiedades.Agregar("Puerto", puerto);
                            LogPropiedades.Agregar("Sesion", _session.ToString());
                            LogPropiedades.Agregar("State", Convert.ToString(state));
                            LogPropiedades.Agregar("Ret", Convert.ToString(ret));
                             POSstation.Fabrica.LogIt.Loguear("Despues de TMRom Interno en LeerDS1992VersionSuic", LogPropiedades, LogCategorias);
                            /***************************************************************************************************/




                            if (ROM[0] == 2 || ROM[0] == 4 || ROM[0] == 6 || ROM[0] == 8 || ROM[0] == 1 || ROM[0] == 20)
                            {
                                if (ret == 1)
                                {

                                    for (int i = 0; i < 32; i++)
                                        buf[i] = '0';

                                    strSalida = "";
                                    X = 0;
                                    for (b = 0; b <= 3; b++)
                                    {
                                        ReadPage(b, data1, 32, _session, _buffer);

                                        /********************************************************************************************************/
                                        LogCategorias.Clear();
                                        LogCategorias.Agregar("SeguimientoCodigo");
                                        LogPropiedades.Clear();
                                        LogPropiedades.Agregar("Puerto", puerto);
                                        LogPropiedades.Agregar("Sesion", _session.ToString());
                                        LogPropiedades.Agregar("State", Convert.ToString(state));
                                         POSstation.Fabrica.LogIt.Loguear("Despues de ReadPage en LeerDS1992VersionSuic", LogPropiedades, LogCategorias);
                                        /***************************************************************************************************/

                                        for (a = 1; a <= 32; a++)
                                        {
                                            alldata[X] = data1[a];
                                            X += 1;
                                        }
                                    }

                                    for (b = 128; b >= 0; b--)
                                    {
                                        if (b == 0)
                                            alldata[b] = 0;
                                        else
                                            alldata[b] = alldata[b - 1];
                                    }
                                }
                            }
                            else
                            {
                                while (ROM[0] != 2 && ROM[0] != 1 && ROM[0] != 4 && ROM[0] != 6 && ROM[0] != 8 && ROM[0] != 20)
                                {

                                    ret = TMNext(_session, _buffer);

                                    /********************************************************************************************************/
                                    LogCategorias.Clear();
                                    LogCategorias.Agregar("SeguimientoCodigo");
                                    LogPropiedades.Clear();
                                    LogPropiedades.Agregar("Puerto", puerto);
                                    LogPropiedades.Agregar("Sesion", _session.ToString());
                                    LogPropiedades.Agregar("State", Convert.ToString(state));
                                    LogPropiedades.Agregar("Ret", Convert.ToString(ret));
                                     POSstation.Fabrica.LogIt.Loguear("Despues de TMNext en While en LeerDS1992VersionSuic", LogPropiedades, LogCategorias);
                                    /***************************************************************************************************/

                                    if (ret == 1)
                                    {
                                        ROM = new short[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                                        ret = TMRom(_session, _buffer, ROM);

                                        /********************************************************************************************************/
                                        LogCategorias.Clear();
                                        LogCategorias.Agregar("SeguimientoCodigo");
                                        LogPropiedades.Clear();
                                        LogPropiedades.Agregar("Puerto", puerto);
                                        LogPropiedades.Agregar("Sesion", _session.ToString());
                                        LogPropiedades.Agregar("State", Convert.ToString(state));
                                        LogPropiedades.Agregar("Ret", Convert.ToString(ret));
                                         POSstation.Fabrica.LogIt.Loguear("Despues de TMRom en While en LeerDS1992VersionSuic", LogPropiedades, LogCategorias);
                                        /***************************************************************************************************/


                                        if (ret == 1)
                                        {
                                            //REFORMADO PARA SOLO LECTURA DE BOTONES
                                            // if (!(ROM[0] != 2 && ROM[0] != 4 && ROM[0] != 6 && ROM[0] != 8 && ROM[0] != 20))
                                            if (ROM[0] == 2 || ROM[0] == 4 || ROM[0] == 6 || ROM[0] == 8 || ROM[0] == 1 || ROM[0] == 20)
                                            {
                                                for (int i = 0; i < 32; i++)
                                                    buf[i] = '0';

                                                strSalida = "";
                                                X = 0;
                                                for (b = 0; b <= 3; b++)
                                                {
                                                    ReadPage(b, data1, 32, _session, _buffer);

                                                    /********************************************************************************************************/
                                                    LogCategorias.Clear();
                                                    LogCategorias.Agregar("SeguimientoCodigo");
                                                    LogPropiedades.Clear();
                                                    LogPropiedades.Agregar("Puerto", puerto);
                                                    LogPropiedades.Agregar("Sesion", _session.ToString());
                                                    LogPropiedades.Agregar("State", Convert.ToString(state));
                                                    LogPropiedades.Agregar("Ret", Convert.ToString(ret));
                                                     POSstation.Fabrica.LogIt.Loguear("Despues de ReadPage en While en LeerDS1992VersionSuic", LogPropiedades, LogCategorias);
                                                    /***************************************************************************************************/

                                                    for (a = 1; a <= 32; a++)
                                                    {
                                                        alldata[X] = data1[a];
                                                        X += 1;
                                                    }
                                                }

                                                for (b = 128; b >= 0; b--)
                                                {
                                                    if (b == 0)
                                                        alldata[b] = 0;
                                                    else
                                                        alldata[b] = alldata[b - 1];
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (ret != 1)
                                        {
                                            // throw new GasolutionsException("No hay un Chip Conectado");
                                            throw new ChipNoConectadoException();
                                        }
                                    }
                                }
                            }

                            for (int i = 7; i >= 0; i--)
                                idRomButton.Append(ROM[i].ToString("X2"));

                            /********************************************************************************************************/
                            LogCategorias.Clear();
                            LogCategorias.Agregar("SeguimientoCodigo");
                            LogPropiedades.Clear();
                            LogPropiedades.Agregar("Puerto", puerto);
                            LogPropiedades.Agregar("Sesion", _session.ToString());
                            LogPropiedades.Agregar("idRomButton", idRomButton.ToString());
                             POSstation.Fabrica.LogIt.Loguear("Inicia Desencriptar2Fish en metodo LeerDS1992VersionSuic", LogPropiedades, LogCategorias);
                            /***************************************************************************************************/


                            POSstation.Encripcion.Metodos oEncripcion = new POSstation.Encripcion.Metodos();

                            strSalida = oEncripcion.Desencriptar2Fish(ref alldata);
                            strSalida = LimpiarCadena(strSalida);
                            string[] oCampos = strSalida.Split(Convert.ToChar(";"));

                            if (oCampos.GetUpperBound(0) != 6)
                            {
                                throw new POSstation.Tmex.TmexVersionException();
                            }
                            else
                            {
                                if (oCampos[0].Trim() == "")
                                {
                                    throw new GasolutionsException("Placa en blanco");
                                }
                                oInformacion.Compañia = "GS";
                                oInformacion.Contrato = oCampos[1];
                                oInformacion.FechaConversion = Convert.ToDateTime(oCampos[4].Substring(6, 2) + "/" + oCampos[4].Substring(4, 2) + "/" + oCampos[4].Substring(0, 4));
                                oInformacion.FechaProximoMantenimiento = Convert.ToDateTime(oCampos[6].Substring(6, 2) + "/" + oCampos[6].Substring(4, 2) + "/" + oCampos[6].Substring(0, 4));
                                oInformacion.Numero = 123456;
                                oInformacion.Placa = oCampos[0];
                                oInformacion.Rom = idRomButton.ToString();
                                oInformacion.Serie = "GS";

                                LogCategorias.Clear();
                                LogCategorias.Agregar("SeguimientoCodigo");
                                LogPropiedades.Clear();
                                LogPropiedades.Agregar("Contrato", oCampos[1]);
                                 POSstation.Fabrica.LogIt.Loguear("Recupera Datos Chip", LogPropiedades, LogCategorias);

                            }

                            //ABRE el switch abierto
                            ConfigurarInterruptor(idRom, MainSwicthState.Off);
                            state = true;

                            /********************************************************************************************************/
                            LogCategorias.Clear();
                            LogCategorias.Agregar("SeguimientoCodigo");
                            LogPropiedades.Clear();
                            LogPropiedades.Agregar("Puerto", puerto);
                            LogPropiedades.Agregar("Sesion", _session.ToString());
                             POSstation.Fabrica.LogIt.Loguear("Inicia Configurar Interruptor en metodo LeerDS1992VersionSuic", LogPropiedades, LogCategorias);
                            /***************************************************************************************************/

                        }
                        else
                            state = false;
                    }
                    else
                        state = false;

                    CerrarCircuito("");

                    /********************************************************************************************************/
                    LogCategorias.Clear();
                    LogCategorias.Agregar("SeguimientoCodigo");
                    LogPropiedades.Clear();
                    LogPropiedades.Agregar("Puerto", puerto);
                    LogPropiedades.Agregar("Sesion", _session.ToString());
                     POSstation.Fabrica.LogIt.Loguear("Inicia Cerrar Circuito en Vacio en metodo LeerDS1992VersionSuic", LogPropiedades, LogCategorias);
                    /***************************************************************************************************/

                }
                else
                    state = false;

                //REFORMADO PARA EL USO DE SESSION UNICA
                //	FinalizarSesion();

                if (state == false)
                {
                    throw new GasolutionsException("Revise la red de lectores, problemas al iniciar la sesion");
                }
                else
                {
                    return oInformacion;
                }
            }
            catch
            {
                if (state)
                {
                    CerrarCircuito("");
                }
                //REFORMADO PARA EL USO DE SESSION UNICA
                //FinalizarSesion();
                throw;
            }
        }

        private string LimpiarCadena(string cadena)
        {
            try
            {
                System.Text.StringBuilder resultado = new StringBuilder();
                for (int I = 0; I < cadena.Length; I++)
                {
                    if ("ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz;0123456789".IndexOf(cadena.Substring(I, 1)) >= 0)
                    {
                        resultado.Append(cadena.Substring(I, 1));
                    }
                    else
                    {
                        break;
                    }
                }
                return resultado.ToString();
            }
            catch
            {
                throw;
            }
        }

        // Cambios Realizados en Metodo
        private DS1992 LeerDS1992(string idRom, DS1992 datos, string puerto, TypeAdapter tipo, Int16 cantidadBytes)
        {
            // Reforma Realizado
            bool state = false;
            try
            {
                //CAMBIADO PARA MANEJO DE SESSION UNICA
                //IniciarSesion(puerto, tipo);

                short[] ROM = new short[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                for (int i = 7; i >= 0; i--)
                {
                    short hex = (short)HexToDec(idRom.Substring(i * 2, 2));
                    ROM[7 - i] = hex;
                }

                state = CerrarCircuito(idRom);

                /********************************************************************************************************/
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoCodigo");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Puerto", puerto);
                LogPropiedades.Agregar("Sesion", _session.ToString());
                LogPropiedades.Agregar("State", Convert.ToString(state));
                 POSstation.Fabrica.LogIt.Loguear("Despues de Cerrar Circuito", LogPropiedades, LogCategorias);
                /***************************************************************************************************/


                if (state)
                {
                    short ret = TMRom(_session, _buffer, ROM);

                    /********************************************************************************************************/
                    LogCategorias.Clear();
                    LogCategorias.Agregar("SeguimientoCodigo");
                    LogPropiedades.Clear();
                    LogPropiedades.Agregar("Puerto", puerto);
                    LogPropiedades.Agregar("Sesion", _session.ToString());
                    LogPropiedades.Agregar("State", Convert.ToString(state));
                    LogPropiedades.Agregar("Ret", Convert.ToString(ret));
                     POSstation.Fabrica.LogIt.Loguear("Despues de TMROM en LeerDS1992", LogPropiedades, LogCategorias);
                    /***************************************************************************************************/

                    if (ret == 1)
                    {
                        ret = TMFirst(_session, _buffer);
                        /********************************************************************************************************/
                        LogCategorias.Clear();
                        LogCategorias.Agregar("SeguimientoCodigo");
                        LogPropiedades.Clear();
                        LogPropiedades.Agregar("Puerto", puerto);
                        LogPropiedades.Agregar("Sesion", _session.ToString());
                        LogPropiedades.Agregar("State", Convert.ToString(state));
                        LogPropiedades.Agregar("Ret", Convert.ToString(ret));
                         POSstation.Fabrica.LogIt.Loguear("Despues de TMFirst en LeerDS1992", LogPropiedades, LogCategorias);
                        /***************************************************************************************************/

                        if (ret == 1)
                        {
                            ROM = new short[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                            ret = TMRom(_session, _buffer, ROM);
                            /********************************************************************************************************/
                            LogCategorias.Clear();
                            LogCategorias.Agregar("SeguimientoCodigo");
                            LogPropiedades.Clear();
                            LogPropiedades.Agregar("Puerto", puerto);
                            LogPropiedades.Agregar("Sesion", _session.ToString());
                            LogPropiedades.Agregar("State", Convert.ToString(state));
                            LogPropiedades.Agregar("Ret", Convert.ToString(ret));
                             POSstation.Fabrica.LogIt.Loguear("Despues de TMRom Interno en LeerDS1992", LogPropiedades, LogCategorias);
                            /***************************************************************************************************/

                            if (ret == 1)
                            {
                                byte[] info = new byte[118];

                                char[] buf = new char[32];
                                for (int i = 0; i < 32; i++)
                                    buf[i] = '0';
                                ret = TMReadPacket(_session, _buffer, 0, info, cantidadBytes);
                                info[117] = 0;

                                datos.contenido = info;


                                /********************************************************************************************************/
                                LogCategorias.Clear();
                                LogCategorias.Agregar("SeguimientoCodigo");
                                LogPropiedades.Clear();
                                LogPropiedades.Agregar("Puerto", puerto);
                                LogPropiedades.Agregar("Sesion", _session.ToString());
                                LogPropiedades.Agregar("State", Convert.ToString(state));
                                LogPropiedades.Agregar("Ret", Convert.ToString(ret));
                                 POSstation.Fabrica.LogIt.Loguear("Despues de TMReadPacket en LeerDS1992", LogPropiedades, LogCategorias);
                                /***************************************************************************************************/

                                StringBuilder idRomButton = new StringBuilder();
                                while (ROM[0] != 2 && ROM[0] != 1 && ROM[0] != 4 && ROM[0] != 6 && ROM[0] != 8 && ROM[0] != 20)
                                {
                                    idRomButton.Remove(0, idRomButton.Length);
                                    ret = TMNext(_session, _buffer);

                                    /********************************************************************************************************/
                                    LogCategorias.Clear();
                                    LogCategorias.Agregar("SeguimientoCodigo");
                                    LogPropiedades.Clear();
                                    LogPropiedades.Agregar("Puerto", puerto);
                                    LogPropiedades.Agregar("Sesion", _session.ToString());
                                    LogPropiedades.Agregar("State", Convert.ToString(state));
                                    LogPropiedades.Agregar("Ret", Convert.ToString(ret));
                                     POSstation.Fabrica.LogIt.Loguear("Despues de TMNext en While en LeerDS1992", LogPropiedades, LogCategorias);
                                    /***************************************************************************************************/


                                    if (ret == 1)
                                    {
                                        ROM = new short[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                                        ret = TMRom(_session, _buffer, ROM);
                                        /********************************************************************************************************/
                                        LogCategorias.Clear();
                                        LogCategorias.Agregar("SeguimientoCodigo");
                                        LogPropiedades.Clear();
                                        LogPropiedades.Agregar("Puerto", puerto);
                                        LogPropiedades.Agregar("Sesion", _session.ToString());
                                        LogPropiedades.Agregar("State", Convert.ToString(state));
                                        LogPropiedades.Agregar("Ret", Convert.ToString(ret));
                                         POSstation.Fabrica.LogIt.Loguear("Despues de TMRom en While en LeerDS1992", LogPropiedades, LogCategorias);
                                        /***************************************************************************************************/

                                        if (ret == 1)
                                        {
                                            for (int i = 0; i < 32; i++)
                                                buf[i] = '0';
                                            ret = TMReadPacket(_session, _buffer, 0, info, cantidadBytes);

                                            /********************************************************************************************************/
                                            LogCategorias.Clear();
                                            LogCategorias.Agregar("SeguimientoCodigo");
                                            LogPropiedades.Clear();
                                            LogPropiedades.Agregar("Puerto", puerto);
                                            LogPropiedades.Agregar("Sesion", _session.ToString());
                                            LogPropiedades.Agregar("State", Convert.ToString(state));
                                            LogPropiedades.Agregar("Ret", Convert.ToString(ret));
                                             POSstation.Fabrica.LogIt.Loguear("Despues de TMReadPacket en While en LeerDS1992", LogPropiedades, LogCategorias);
                                            /***************************************************************************************************/

                                            info[117] = 0;

                                            datos.contenido = info;
                                        }
                                    }
                                    else
                                    {
                                        if (ret != 1)
                                        {
                                            //throw new GasolutionsException("No hay un Chip Conectado");
                                            throw new ChipNoConectadoException();
                                        }
                                    }
                                }
                                for (int i = 7; i >= 0; i--)
                                    idRomButton.Append(ROM[i].ToString("X2"));
                                datos.IDRom = idRomButton.ToString();


                                //ABRE el switch abierto
                                ConfigurarInterruptor(idRom, MainSwicthState.Off);
                                state = true;
                                /********************************************************************************************************/
                                LogCategorias.Clear();
                                LogCategorias.Agregar("SeguimientoCodigo");
                                LogPropiedades.Clear();
                                LogPropiedades.Agregar("Puerto", puerto);
                                LogPropiedades.Agregar("Sesion", _session.ToString());
                                LogPropiedades.Agregar("IdRom", idRom);
                                 POSstation.Fabrica.LogIt.Loguear("Despues de Configurar Interruptor en LeerDS1992", LogPropiedades, LogCategorias);
                                /***************************************************************************************************/
                            }
                        }
                        else
                            state = false;
                    }
                    else
                        state = false;

                    state = CerrarCircuito("");
                    /********************************************************************************************************/
                    LogCategorias.Clear();
                    LogCategorias.Agregar("SeguimientoCodigo");
                    LogPropiedades.Clear();
                    LogPropiedades.Agregar("Puerto", puerto);
                    LogPropiedades.Agregar("Sesion", _session.ToString());
                    LogPropiedades.Agregar("State", Convert.ToString(state));
                     POSstation.Fabrica.LogIt.Loguear("Despues de Cerrar Circuito en Vacio en LeerDS1992", LogPropiedades, LogCategorias);
                    /***************************************************************************************************/
                }
                else
                    state = false;

                //CAMBIADO PARA MANEJO DE SESSION UNICA
                //	FinalizarSesion();
                /********************************************************************************************************/
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoCodigo");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Puerto", puerto);
                LogPropiedades.Agregar("Sesion", _session.ToString());
                LogPropiedades.Agregar("State", Convert.ToString(state));
                 POSstation.Fabrica.LogIt.Loguear("Retorno de Datos del Metodo LeerDS1992 en LeerDS1992", LogPropiedades, LogCategorias);
                /***************************************************************************************************/


                return datos;
            }
            catch
            {
                if (state)
                {
                    state = CerrarCircuito("");
                }

                //CAMBIADO PARA MANEJO DE SESSION UNICA
                // FinalizarSesion();
                throw;
            }
        }

        private bool ConfigurarInterruptor(String romCode, MainSwicthState state)
        {
            try
            {
                short[] ROM = new short[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                short n = 0;
                for (int i = 7; i >= 0; i--)
                {
                    short hex = (short)HexToDec(romCode.Substring(i * 2, 2));
                    ROM[7 - i] = hex;
                }
                short ret = TMRom(_session, _buffer, ROM);
                if (ret == 1)
                {
                    ret = TMAccess(_session, _buffer);
                    if (ret == 1)
                    {
                        n = TMTouchByte(_session, (short)state);
                    }
                }
                return (n >= 1);
            }
            catch
            {
                throw;
            }
        }

        private Boolean CerrarCircuito(string idRom)
        {
            try
            {
                Boolean result = false;
                foreach (string idLector in _idLectores)
                {
                    if (idLector != idRom)
                    {
                        ConfigurarInterruptor(idLector, MainSwicthState.Off);
                    }
                    else
                    {
                        ConfigurarInterruptor(idLector, MainSwicthState.On);
                        result = true;
                    }
                }
                return result;
            }
            catch
            {
                throw;
            }
        }

        private int HexToDec(string ch)
        {
            try
            {
                int c = ch[0];
                int b;
                if ((c - 65) < 0)
                    c -= 48;
                else
                    c -= 55;
                b = c;
                b <<= 4;
                c = ch[1];
                if ((c - 65) < 0)  //HACE EL CALCULO BASE 10
                    c -= 48;
                else			   //HACE EL CALCULO BASE 16   (CHR 65 = A)
                    c -= 55;
                b += c;

                return b;
            }
            catch
            {
                throw;
            }
        }

        private bool ExisteDispositivo(String id, String puerto, TypeAdapter tipo)
        {
            try
            {
                IniciarSesion(puerto, tipo);

                short ret = TMFirst(_session, _buffer);
                while ((ret == 1))
                {
                    // if MSB of ROM[0] != 0, then write, else read
                    short[] ROM = new short[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    TMRom(_session, _buffer, ROM);

                    byte s;
                    StringBuilder romCode = new StringBuilder();
                    for (int i = 7; i >= 0; i--)
                    {
                        s = (byte)ROM[i];
                        romCode.Append(s.ToString("X2"));
                    }
                    if (id == romCode.ToString())
                    {
                        FinalizarSesion();
                        return true;
                    }
                    ret = TMNext(_session, _buffer);
                }

                FinalizarSesion();

                return false;
            }
            catch
            {
                throw;
            }
        }

        public Byte Asc(string s)
        {
            try
            {
                return Encoding.UTF32.GetBytes(s)[0];
            }
            catch
            {
                throw;
            }
        }

        public char Chr(int c)
        {
            try
            {
                return Convert.ToChar(c);
            }
            catch
            {
                throw;
            }
        }
        #endregion

    }
}




