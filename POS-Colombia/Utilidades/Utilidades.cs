using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSstation.Utilidades
{
    public class DatosLectura
    {

        public byte[] _lectura;
        public byte[] Lectura
        {
            get { return _lectura; }
            set { _lectura = value; }
        }

        public int _Lenght;
        public int Length
        {
            get { return _Lenght; }
            set { _Lenght = value; }
        }

    }

    public class Utilidades
    {
        public const int BUFFER_SIZE = 148;
       public  List<DatosLectura> DatosLectura(byte[] lectura)
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


               


                return lista;
            }


        }
        public System.Array oPaginasfinal;
        public void ProcesarLectura(byte[] item)
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
            
            }

        }

        public string[] ExtraerInformacionRecibidaDelDispositivoLSIB4(byte[] ArregloBytes)
        {
            byte[] Temporal;
            string TempPuerto = string.Empty;
            string[] Valores = new string[1];
            int j = 0;

            try
            {


                if (ArregloBytes.Length > 150)//Se realizo una mala conexcion del chip en el lector
                {
                    

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
                        oPaginasfinal = oPaginas;


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

                        oPaginasfinal = oPaginas;

                    }


                }



            }
            catch (Exception ex)
            {

            

            }
            return Valores;
        }
    }
}
