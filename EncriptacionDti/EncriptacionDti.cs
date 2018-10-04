using System;
using System.Collections.Generic;
using System.Text;
using POSstation.Fabrica;
using POSstation.AccesoDatos;
using POSstation.EncriptacionDti;
using POSstation.NormaColombiana;


namespace POSstation.EncriptacionDti
{
    public class EncriptacionDti
    {

        private PropiedadesExtendidas LogPropiedades = new PropiedadesExtendidas();
        private CategoriasLog LogCategorias = new CategoriasLog();

        //Se verifica el formato del chip
        private string LimpiarCadena(string cadena)
        {
            System.Text.StringBuilder resultado = new StringBuilder();
            try
            {
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

            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoCodigoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                POSstation.Fabrica.LogIt.Loguear("Error en LimpiarCadena DTI", LogPropiedades, LogCategorias);


            }
            return resultado.ToString();
        }


        public InformacionVehiculo ExtraerInformacionPaginas(byte[] Paginas, string ROM ,bool SolicitarLectura)
        {
            LogCategorias.Clear();
            LogCategorias.Agregar("SeguimientoCodigoDTI");
            LogPropiedades.Clear();
            LogPropiedades.Agregar("Mensaje", "Se procede a iniciar la desencriptacion de  las paginas enviadas por la dti");
            LogPropiedades.Agregar("Fecha", System.DateTime.Now.ToString());
            LogPropiedades.Agregar("Numero Bytes Recibidos", Paginas.Length.ToString());
            POSstation.Fabrica.LogIt.Loguear("Logueando  el inicio de desencriptacion de  las paginas enviadas por la DTI", LogPropiedades, LogCategorias);

             string[] oCampos;

            InformacionVehiculo oInformacion = new InformacionVehiculo();            
            String strSalida = "";
            try
            {
                byte[] tmp = new byte[Paginas.Length];
                Array.Copy(Paginas,tmp,Paginas.Length);

                //int i = 0;

                //tmp[i] = 0;
                //for (byte b in Paginas) tmp[++i] = b;


                for (int b = 127; b >= 0; b--)
                {
                    if (b == 0)
                        tmp[b] = 0;
                    else
                        tmp[b] = tmp[b - 1];
                }

                if (SolicitarLectura)
                {
                    
                   
                    POSstation.NormaColombiana.Metodos oEncripcion = new NormaColombiana.Metodos();
                    strSalida = oEncripcion.Desencriptar2Fish(ref tmp);                   
                    strSalida = LimpiarCadena(strSalida);
                    oCampos = strSalida.Split(Convert.ToChar(";"));
                }
                else
                {
                    strSalida = string.Empty;
                    oCampos = strSalida.Split(Convert.ToChar(";"));
                }
                    
                
                


                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoCodigoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", "Depues de realizar  la desencriptacion de  las paginas enviadas por la dti");
                LogPropiedades.Agregar("Fecha", System.DateTime.Now.ToString());
                LogPropiedades.Agregar("Descriptacion", strSalida);
                POSstation.Fabrica.LogIt.Loguear("Logueando  del final de la desencriptacion de  las paginas enviadas por la DTI", LogPropiedades, LogCategorias);



                //if ((string.IsNullOrEmpty(strSalida) && SolicitarLectura == true))
                if ((string.IsNullOrEmpty(strSalida) && SolicitarLectura == true && string.IsNullOrEmpty(ROM)))
                {


                    LogCategorias.Clear();
                    LogCategorias.Agregar("SeguimientoCodigoDTI");
                    LogPropiedades.Clear();
                    LogPropiedades.Agregar("Mensaje", "Cadena vacia despues de la desecriptacion del TwoFish, Mala Lectura del chip se solicita una nueva lectura");
                    LogPropiedades.Agregar("Fecha", System.DateTime.Now.ToString());
                    LogPropiedades.Agregar("Descriptacion", strSalida);
                    POSstation.Fabrica.LogIt.Loguear("Logueando  del final de la desencriptacion de  las paginas enviadas por la DTI", LogPropiedades, LogCategorias);
                    throw new Exception("Lectura de chip incorrecta desconecte y conecte el chip nuevamente");
                }

                //ESTO ES CUANDO SE TIENE INFORMACION DEL ROOM Y DEMAS DATOS DEL CHIP LO CUAL ME INDICA QUE ES UN CHIP DE GAS SUIC
                //if (!string.IsNullOrEmpty(strSalida) && SolicitarLectura == true)
                if (!string.IsNullOrEmpty(strSalida) && SolicitarLectura == true && strSalida.Length > 5)
                {
                    oInformacion.FechaConversion = Convert.ToDateTime(oCampos[4].Substring(6, 2) + "/" + oCampos[4].Substring(4, 2) + "/" + oCampos[4].Substring(0, 4));
                    oInformacion.FechaProximoMantenimiento = Convert.ToDateTime(oCampos[6].Substring(6, 2) + "/" + oCampos[6].Substring(4, 2) + "/" + oCampos[6].Substring(0, 4));
                    oInformacion.Fecha = Convert.ToDateTime(oCampos[6].Substring(6, 2) + "/" + oCampos[6].Substring(4, 2) + "/" + oCampos[6].Substring(0, 4)).ToString();
                    oInformacion.Placa = oCampos[0];
                    oInformacion.Contrato = oCampos[1];
                    oInformacion.Numero = 123456;
                    oInformacion.Rom = ROM;                    
                    oInformacion.Serie = "GS";
                    
                    LogCategorias.Clear();
                    LogCategorias.Agregar("SeguimientoCodigoDTI");
                    LogPropiedades.Clear();
                    LogPropiedades.Agregar("Contrato", oCampos[1]);
                    LogPropiedades.Agregar("RomLeido", ROM);
                    LogPropiedades.Agregar("Fecha", System.DateTime.Now.ToString());
                    LogPropiedades.Agregar("Serie", oInformacion.Serie);
                    LogPropiedades.Agregar("Placa", oInformacion.Placa);
                    LogPropiedades.Agregar("FechaConversion", oInformacion.FechaConversion.ToString());
                    LogPropiedades.Agregar("FechaProximoMantenimiento", oInformacion.FechaProximoMantenimiento.ToString());
                    POSstation.Fabrica.LogIt.Loguear("Datos Recuperados de la lectura del Chip de Gas", LogPropiedades, LogCategorias);
                }
                else
                {
                    //ESTO ES CUANDO SOLO SE TIENE INFORMACION DEL ROOM LO CUAL ME INDICA QUE ES UN CHIP DE GASOLINA
                    oInformacion.FechaConversion = System.DateTime.Now;
                    oInformacion.FechaProximoMantenimiento = System.DateTime.Now;
                    oInformacion.Fecha = System.DateTime.Now.ToString();
                    oInformacion.Placa = string.Empty;// Vacia cuando solo es chip de gasolina
                    oInformacion.Rom = ROM;
                    oInformacion.Serie = "GS";                 
                    LogCategorias.Clear();
                    LogCategorias.Agregar("SeguimientoCodigoDTI");
                    LogPropiedades.Clear();
                    LogPropiedades.Agregar("Contrato", oInformacion.Contrato);
                    LogPropiedades.Agregar("RomLeido", ROM);
                    LogPropiedades.Agregar("Fecha", System.DateTime.Now.ToString());
                    LogPropiedades.Agregar("Serie", oInformacion.Serie);
                    LogPropiedades.Agregar("Placa", oInformacion.Placa);
                    LogPropiedades.Agregar("FechaConversion", oInformacion.FechaConversion.ToString());
                    LogPropiedades.Agregar("FechaProximoMantenimiento", oInformacion.FechaProximoMantenimiento.ToString());
                    POSstation.Fabrica.LogIt.Loguear("Datos Recuperados de la lectura del Chip Gasolina", LogPropiedades, LogCategorias);

                }




            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoCodigoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                POSstation.Fabrica.LogIt.Loguear("Error recuperando ROM chip ExtraerInformacionPaginas", LogPropiedades, LogCategorias);                
                throw ex;
            }
            return oInformacion;
        }


        public InformacionVehiculo ExtraerInformacionPaginasImpresiones(byte[] Paginas)
        {
            LogCategorias.Clear();
            LogCategorias.Agregar("SeguimientoCodigoDTI");
            LogPropiedades.Clear();
            LogPropiedades.Agregar("Mensaje", "Se procede a iniciar la desencriptacion de  las paginas enviadas por la dti");
            LogPropiedades.Agregar("Fecha", System.DateTime.Now.ToString());
            LogPropiedades.Agregar("Numero Bytes Recibidos", Paginas.Length.ToString());
            POSstation.Fabrica.LogIt.Loguear("Logueando  el inicio de desencriptacion de  las paginas enviadas por la DTI", LogPropiedades, LogCategorias);

            string[] oCampos;
            string ROM=string.Empty;
            byte[] BytesGasolina = new byte[128];

            InformacionVehiculo oInformacion = new InformacionVehiculo();
            String strSalida = "";
            int j = 0;
            
            try
            {
                 j = 0;
                for (int i = 19; i < Paginas.Length; i++)
                {
                    BytesGasolina[j] = Paginas[i];//El arreglo Paginas me almacena la informacion de las paginas
                    j++;
                    if (i>=140)
                    {
                        strSalida = "";
                    }
                }


                for (int b = 127; b >= 0; b--)
                {
                    if (b == 0)
                        BytesGasolina[b] = 0;
                    else
                        BytesGasolina[b] = BytesGasolina[b - 1];
                }
                POSstation.NormaColombiana.Metodos oEncripcion = new NormaColombiana.Metodos();
                strSalida = oEncripcion.Desencriptar2Fish(ref BytesGasolina);
                strSalida = LimpiarCadena(strSalida);
                oCampos = strSalida.Split(Convert.ToChar(";"));





                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoCodigoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", "Depues de realizar  la desencriptacion de  las paginas enviadas por la dti");
                LogPropiedades.Agregar("Fecha", System.DateTime.Now.ToString());
                LogPropiedades.Agregar("Descriptacion", strSalida);
                POSstation.Fabrica.LogIt.Loguear("Logueando  del final de la desencriptacion de  las paginas enviadas por la DTI", LogPropiedades, LogCategorias);

                //ESTO ES CUANDO SE TIENE INFORMACION DEL ROOM Y DEMAS DATOS DEL CHIP LO CUAL ME INDICA QUE ES UN CHIP DE GAS SUIC
                //if (!string.IsNullOrEmpty(strSalida) )
                if (!string.IsNullOrEmpty(strSalida) && strSalida.Length > 5)
                {
                    oInformacion.FechaConversion = Convert.ToDateTime(oCampos[4].Substring(6, 2) + "/" + oCampos[4].Substring(4, 2) + "/" + oCampos[4].Substring(0, 4));
                    oInformacion.FechaProximoMantenimiento = Convert.ToDateTime(oCampos[6].Substring(6, 2) + "/" + oCampos[6].Substring(4, 2) + "/" + oCampos[6].Substring(0, 4));
                    oInformacion.Placa = oCampos[0];
                    oInformacion.Contrato = ROM;
                    oInformacion.Numero = 123456;
                    oInformacion.Rom = oCampos[3];
                    oInformacion.Serie = "GS";

                    LogCategorias.Clear();
                    LogCategorias.Agregar("SeguimientoCodigoDTI");
                    LogPropiedades.Clear();
                    LogPropiedades.Agregar("Contrato", oCampos[1]);
                    LogPropiedades.Agregar("Romleido", ROM);
                    LogPropiedades.Agregar("Fecha", System.DateTime.Now.ToString());
                    LogPropiedades.Agregar("Serie", oInformacion.Serie);
                    LogPropiedades.Agregar("Placa", oInformacion.Placa);
                    LogPropiedades.Agregar("FechaConversion", oInformacion.FechaConversion.ToString());
                    LogPropiedades.Agregar("FechaProximoMantenimiento", oInformacion.FechaProximoMantenimiento.ToString());
                    POSstation.Fabrica.LogIt.Loguear("Datos Recuperados de la lectura del Chip de Gas", LogPropiedades, LogCategorias);
                }
                else
                {
                    byte []Temporal = new byte[19]; //Aqui saco la informacion del Puerto y el ROM que vienen en los primeros 19 Bytes

                    j = 0;
                    for (int i = 0; i < 19; i++)
                    {
                        Temporal[j] = Paginas[i];
                        j++;
                    }

                    System.Text.UTF8Encoding datos = new System.Text.UTF8Encoding();//convierto a string los primeros 19 byets para sacar el rom y el puerto
                   string TempPuerto = datos.GetString(Temporal);
                    
                   if (!string.IsNullOrEmpty( TempPuerto))
                   {
                       string[] Tmp = TempPuerto.Split('.');                       
                       ROM= Tmp[1];
                   }

                    //ESTO ES CUANDO SOLO SE TIENE INFORMACION DEL ROOM LO CUAL ME INDICA QUE ES UN CHIP DE GASOLINA
                    oInformacion.FechaConversion = System.DateTime.Now;
                    oInformacion.FechaProximoMantenimiento = System.DateTime.Now;
                    oInformacion.Placa = string.Empty;// Vacia cuando solo es chip de gasolina
                    oInformacion.Rom = ROM;
                    oInformacion.Serie = "GS";
                    LogCategorias.Clear();
                    LogCategorias.Agregar("SeguimientoCodigoDTI");
                    LogPropiedades.Clear();
                    LogPropiedades.Agregar("Contrato", oInformacion.Contrato);
                    LogPropiedades.Agregar("Romleido", ROM);
                    LogPropiedades.Agregar("Fecha", System.DateTime.Now.ToString());
                    LogPropiedades.Agregar("Serie", oInformacion.Serie);
                    LogPropiedades.Agregar("Placa", oInformacion.Placa);
                    LogPropiedades.Agregar("FechaConversion", oInformacion.FechaConversion.ToString());
                    LogPropiedades.Agregar("FechaProximoMantenimiento", oInformacion.FechaProximoMantenimiento.ToString());
                    POSstation.Fabrica.LogIt.Loguear("Datos Recuperados de la lectura del Chip Gasolina", LogPropiedades, LogCategorias);

                }




            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoCodigoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                POSstation.Fabrica.LogIt.Loguear("Error recuperando ROM chip ExtraerInformacionPaginas", LogPropiedades, LogCategorias);
                throw ex;
            }
            return oInformacion;
        }
    }



}
