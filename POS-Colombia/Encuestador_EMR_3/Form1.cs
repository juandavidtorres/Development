using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Timers;
using System.Threading;         //Para manejo del Timer
using System.Globalization;


namespace Encuestador_EMR_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Encuentra los puertos disponibles en el Computador
            comboBox1.Items.Clear();

            foreach (string s in SerialPort.GetPortNames())
              comboBox1.Items.Add(s);
        }


        byte[] TramaTx = new byte[1];
        byte[] TramaRx = new byte[1];
        //byte[] END = new byte[1];
        byte[] STX = new byte[1];
        byte[] END = new byte[1];
        byte[] CS = new byte[2];
        byte[] NS = new byte[2];
        byte[] TAM = new byte[4];
        byte[] PRECIO = new byte[1];
        byte[] VOLUMEN = new byte[1];

        byte[] DATOS = new byte[1];
        byte[] CRCTX = new byte[1];
        byte[] LCRTX = new byte[1];
        byte[] ETX = { 0x03 };
        byte[] SF = { 0xFA };
        byte[] LCR = new byte[1];

        string Puerto;

        byte[] Comando = new byte[1];

        SerialPort PuertoCom = new SerialPort();
        System.IO.StreamWriter SWRegistro = System.IO.File.AppendText("Registros.txt");
        System.IO.StreamWriter SWTramas = System.IO.File.AppendText("Tramas.txt");

        bool boton_estado;

        int CRC = 0;

        string input = "";
        string doublestr = "";

        int See_tabla_5, See_tabla_4 = 0;
        int TanKe = 1;
        int TanKeSET = 1;
        int Code_B = 1;
        int Byte_ = 0;

        decimal Dat = 0;

        string Excep = "";

        byte[] Precio_ = new byte[4];

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {          

            if (!boton_estado)
            {  
                if (!PuertoCom.IsOpen)
                {
                    PuertoCom.PortName = Puerto;
                    PuertoCom.BaudRate = 9600;
                    PuertoCom.StopBits = StopBits.One;
                    PuertoCom.Parity = Parity.None;
                    PuertoCom.DataBits = 8;
                    PuertoCom.Open();
                }

                boton_estado = true;
                button1.Text = "Desactivar";
                button1.BackColor = Color.FromArgb(128, 255, 128);
            }
            else
            {            
                button1.Text = "Activar";
                button1.BackColor = Color.Red;
                PuertoCom.Close();

                boton_estado = false;
            }

        }           
            catch (Exception Excepcion)
            {
                string MensajeExcepcion = "Excepcion en PuertoCom " + Excepcion;
                MessageBox.Show(MensajeExcepcion);
            }           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Puerto = comboBox1.Text;
        }
          
        
        //private void Get_a_Click(object sender, EventArgs e)
        //{  //7E 01 FF 47 61 00 7E // 0x47-G / 0x61-a
        //    TramaTx = new byte[7] {0x7E, 0X01, 0XFF, 0X47, 0X61, 0X00, 0X7E};

        //   CalcularCRC();

        //   TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, 0X47, 0X61, Convert.ToByte(CRC), 0X7E };


        //   EnviarComando();

        //   RecivirComando();


        //    int ElementoInicial = 5;
        //    int Longitud = (TramaRx.Length - (ElementoInicial +2));

           

        //    ObtenerValor(ElementoInicial, Longitud);

           

        //}
       
        
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    //7E 01 FF 47 61 00 7E // 0x47-G / 0x62-b
        //    TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, 0X47, 0X62, 0X00, 0X7E };

        //    CalcularCRC();

        //    TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, 0X47, 0X62, Convert.ToByte(CRC), 0X7E };


        //    EnviarComando();

        //    RecivirComando();


        //    int ElementoInicial = 5;
        //    int Longitud = (TramaRx.Length - (ElementoInicial + 2));



        //    ObtenerValor(ElementoInicial, Longitud);
        //}


        //private void G_c_Click(object sender, EventArgs e)
        //{
        //    //7E 01 FF 47 61 00 7E // 0x47-G / 0x4B-K
        //    TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, 0X47, 0X4B, 0X00, 0X7E };

        //    CalcularCRC();

        //    TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, 0X47, 0X4B, Convert.ToByte(CRC), 0X7E };


        //    EnviarComando();

        //    RecivirComando();


        //    int ElementoInicial = 5;
        //    int Longitud = (TramaRx.Length - (ElementoInicial + 2));



        //    ObtenerValor(ElementoInicial, Longitud);
        //}


        private void Obtener_Click(object sender, EventArgs e)
        {
            try 
            {
            //Obtener Precio de venta 

            See_tabla_5 = 0x0;
            See_tabla_4 = 0x00;

                    TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)'E', 0x00, (byte)(TanKe), (byte)(CRC), 0X7E };

                    CalcularCRC();

                    TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)'E', 0x00, (byte)(TanKe), (byte)(CRC), 0X7E };


                    EnviarComando();

                    RecivirComando();

                    Precio_TK.Text = doublestr;
        }

                catch (Exception Excepcion)
            {
                string MensajeExcepcion = "Excepcion en Obtener " + Excepcion;
                MessageBox.Show(MensajeExcepcion);
            }
                 

        }

    
   

        private void Start_Click(object sender, EventArgs e)
        {
            try
            {

                TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)'O', 0X01, 0X01, (byte)(CRC), 0X7E };
                CalcularCRC();

                TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)'O', 0X01, 0X01, (byte)(CRC), 0X7E };

                EnviarComando();

                RecivirComando();
            }
            catch (Exception Excepcion)
            {
                string MensajeExcepcion = "Excepcion en Start " + Excepcion;
                MessageBox.Show(MensajeExcepcion);
            }
        }
        
        private void Pausa_Venta_Click(object sender, EventArgs e)
        {
            try 
            {

            TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'O', 0X02, (byte)(CRC), 0X7E };
            CalcularCRC();

            TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'O', 0X02, (byte)(CRC), 0X7E };

            EnviarComando();

            RecivirComando();

            }
         catch (Exception Excepcion)
            {
                string MensajeExcepcion = "Excepcion en Pausa_Venta_ " + Excepcion;
                MessageBox.Show(MensajeExcepcion);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Autorizar_Click(sender, e);

            TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)'O', 0X06, 0x01, (byte)(CRC), 0X7E };
            CalcularCRC();

            TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)'O', 0X06, 0x01, (byte)(CRC), 0X7E };

            PuertoCom.Write(TramaTx, 0, TramaTx.Length);
                        //Finalizar_venta_Click(sender, e);

            Thread.Sleep(100);

            //TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'O', 0X03, (byte)(CRC), 0X7E };
            //CalcularCRC();

            TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'O', 0X03, 0xAE, 0X7E };
            
            PuertoCom.Write(TramaTx, 0, TramaTx.Length);
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }


        private void Finalizar_venta_Click(object sender, EventArgs e)
        {
            try 
            {
                TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'O', 0X03,(byte)(CRC), 0X7E };
                CalcularCRC();

                TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'O', 0X03,(byte)(CRC), 0X7E };

                EnviarComando();

                RecivirComando();
            }
              catch (Exception Excepcion)
            {
                string MensajeExcepcion = "Excepcion en Finalizar_venta " + Excepcion;
                MessageBox.Show(MensajeExcepcion);
            }
        }

        private void Autorizar_Click(object sender, EventArgs e)
        {
            try
            {
                TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)'O', 0X06, 0x01, (byte)(CRC), 0X7E };
                CalcularCRC();

                TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)'O', 0X06, 0x01, (byte)(CRC), 0X7E };

                EnviarComando();

                RecivirComando();

            }
            catch (Exception Excep)
            {
                string MensajeExcepcion = "Excepcion Autorizar: " + Excep;
                MessageBox.Show(MensajeExcepcion);

            }
        }

        private void Desautorizar_Click(object sender, EventArgs e)
        {
            try
            {
                TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)'O', 0X06, 0x00, (byte)(CRC), 0X7E };
                CalcularCRC();

                TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)'O', 0X06, 0x00, (byte)(CRC), 0X7E };

                EnviarComando();

                RecivirComando();
            }

            catch (Exception Excep)
            {
                string MensajeExcepcion = "Excepcion Desautorizar: " + Excep;
                MessageBox.Show(MensajeExcepcion);

            }
        }
        
        private void Estados_Click(object sender, EventArgs e)
        {
            try
            {
                string Mensaje = " XX ";

                TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'T', 0x01, (byte)(CRC), 0X7E };

                CalcularCRC();

                TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'T', 0x01, (byte)(CRC), 0X7E };


                EnviarComando();

                RecivirComando();

                if (TramaTx[4] == 1) // *** 1° Byte ***
                {
                    /*
                     * 1 bit BYTE codificado: 
                        Bit 0 - Modo de entrega = No, producto que fluye = No 
                        Bit 1 - modo de entrega = Sí, el producto fluye = Sí 
                        Bit 2 - Modo de entrega = Sí, el producto fluye = No 
                        Bit 3 - Modo de entrega = No, producto que fluye = Sí 
                        Bit 4 - la impresora está ocupada 
                        Bit 5 - Posición UI metros correctos. Se establece cuando medidor no puede realizar comando solicitado 
                        debido al estado de cambio de usuario / botón por ejemplo, no se puede restablecer si C & C interruptor activado) 
                        Bit 6 - Error de metro 
                        Bit 7 - Establecer si el modo de C & C activada
                     */

                    int Bit = Convert.ToInt16(TramaRx[5]);

                    if ((Bit & 0x01) == 0x01)
                        Mensaje = "Bit 0 - Modo de entrega = No, producto que fluye = No ";


                    if ((Bit & 0x02) == 0x02)
                        Mensaje = "Bit 1 - modo de entrega = Sí, el producto fluye = Sí ";

                    if ((Bit & 0x04) == 0x04)
                        Mensaje = " Bit 2 - Modo de entrega = Sí, el producto fluye = No  ";

                    if ((Bit & 0x08) == 0x08)
                        Mensaje = " Bit 3 - Modo de entrega = No, producto que fluye = Sí  ";

                    if ((Bit & 0x016) == 0x016)
                        Mensaje = "Bit 4 - la impresora está ocupada";

                    if ((Bit & 0x32) == 0x32)
                        Mensaje = "Bit 5 - Posición UI metros correctos. Se establece cuando medidor no puede realizar comando solicitado debido al estado de cambio de usuario / botón por ejemplo, no se puede restablecer si C & C interruptor activado) ";

                    if ((Bit & 0x64) == 0x64)
                        Mensaje = "Bit 6 - Error de metro ";

                    if ((Bit & 0x128) == 0x128)
                        Mensaje = "Bit 7 - Establecer si el modo de C & C activada";

                }

                MessageBox.Show(Mensaje);

                if (TramaRx[5] == 0x02 || TramaRx[5] == 0x04 || TramaRx[5] == 0x08)
                {
                    //Delivery Status = 0x03

                    TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'T', 0x03, (byte)(CRC), 0X7E };

                    CalcularCRC();

                    TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'T', 0x03, (byte)(CRC), 0X7E };


                    EnviarComando();

                    RecivirComando();


                    /*
                   *** 1° Byte ***
                   1-  Bit 0 - Error ATC 
                   2-  Bit 1 - error pulsador / codificador 
                   4-  Bit 2 - preset error 
                   8-  Bit 3 - Parada preestablecida. Se establece cuando la entrega se detuvo después de alcanzar el volumen preestablecido. 
                   16- Bit 4 - sin parar flujo (tiempo de espera) 
                   32- Bit 5 - solicitud de entrega de pausa 
                   64- Bit 6 - Solicitud de final de salida 
                   128 Bit 7 - la espera de autorización 
               
                   *** 2° Byte ***
                   1-  Bit 8 - Ticket de entrega está pendiente 
                       Bit 9 - flujo está activo 
                       Bit 10 - entrega está activa 
                       Bit 11 - preset activo neto es 
                       Bit 12 - gross preset está activo 
                       Bit 13 - ATC está activo 
                       Bit 14 - Entrega completa 
                   128 Bit 15 - error de entrega 
                  */


                    Mensaje = "";

                    int Bit = Convert.ToInt16(TramaRx[5]);

                    if ((Bit & 0x1) == 0x1)
                    {
                        Mensaje = " Bit 0 - Error ATC  ";
                        MessageBox.Show(Mensaje);
                    }

                    if ((Bit & 0x2) == 0x2)
                    {
                        Mensaje = "Bit 1 - error pulsador / codificador ";
                        MessageBox.Show(Mensaje);
                    }

                    if ((Bit & 0x4) == 0x4)
                    {
                        Mensaje = "Bit 2 - preset error";
                        MessageBox.Show(Mensaje);
                    }

                    if ((Bit & 0x8) == 0x8)
                    {
                        Mensaje = "Bit 3 - Parada preestablecida. Se establece cuando la entrega se detuvo después de alcanzar el volumen preestablecido";
                        MessageBox.Show(Mensaje);
                    }

                    if ((Bit & 0x10) == 0x10)
                    {
                        Mensaje = "Bit 4 - sin parar flujo (tiempo de espera)";
                        MessageBox.Show(Mensaje);
                    }

                    if ((Bit & 0x20) == 0x20)
                    {
                        Mensaje = "Bit 5 - solicitud de entrega de pausa";
                        MessageBox.Show(Mensaje);
                    }

                    if ((Bit & 0x40) == 0x40)
                    {
                        Mensaje = "Bit 6 - Solicitud de final de salida";
                        MessageBox.Show(Mensaje);
                    }

                    if ((Bit & 0x80) == 0x80)
                    {
                        Mensaje = "Bit 7 - la espera de autorización";
                        MessageBox.Show(Mensaje);
                    }


                    Bit = Convert.ToInt16(TramaRx[6]);

                    /*     Bit 8 - Ticket de entrega está pendiente 
                           Bit 9 - flujo está activo 
                           Bit 10 - entrega está activa 
                           Bit 11 - preset activo neto es 
                           Bit 12 - gross preset está activo 
                           Bit 13 - ATC está activo 
                           Bit 14 - Entrega completa 
                       128 Bit 15 - error de entrega 
                     */

                    if ((Bit & 0x1) == 0x1)
                    {
                        Mensaje = "Bit 8 - Ticket de entrega está pendiente";
                        MessageBox.Show(Mensaje);
                    }

                    if ((Bit & 0x02) == 0x02)
                    {
                        Mensaje = "Bit 9 - flujo está activo  ";
                        MessageBox.Show(Mensaje);
                    }
                    if ((Bit & 0x4) == 0x4)
                    {
                        Mensaje = "Bit 10 - entrega está activa";
                        MessageBox.Show(Mensaje);
                    }

                    if ((Bit & 0x8) == 0x8)
                    {
                        Mensaje = "Bit 11 - preset activo neto es ";
                        MessageBox.Show(Mensaje);
                    }
                    if ((Bit & 0x10) == 0x10)
                    {
                        Mensaje = "Bit 12 - gross preset está activo ";
                        MessageBox.Show(Mensaje);
                    }

                    if ((Bit & 0x20) == 0x20)
                    {
                        Mensaje = "Bit 13 - ATC está activo ";
                        MessageBox.Show(Mensaje);
                    }

                    if ((Bit & 0x40) == 0x40)
                    {
                        Mensaje = "Bit 14 - Entrega completa ";
                        MessageBox.Show(Mensaje);
                    }

                    if ((Bit & 0x80) == 0x80)
                    {
                        Mensaje = "Bit 15 - error de entrega ";
                        MessageBox.Show(Mensaje);
                    }

                }
            }
                
            catch (Exception Excep)
            {
                string MensajeExcepcion = "Excepcion: en Estados" + Excep;
                MessageBox.Show(MensajeExcepcion);

            }
            
            
        }
        
        private void B_Volumen_Click(object sender, EventArgs e)
        {
            try 
            {
            TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'G', (byte)'K', Convert.ToByte(CRC), 0X7E };

            CalcularCRC();

            TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'G', (byte)'K', Convert.ToByte(CRC), 0X7E };

            EnviarComando();
            RecivirComando();

            int ElementoInicial = 5;
            int Longitud = (TramaRx.Length - (ElementoInicial + 2));

            ObtenerValor16(ElementoInicial, Longitud);

            Volumen_Despachado.Text =  Dato.Text ;
        }

            catch (Exception Excepcion)
            {
                string MensajeExcepcion = "Excepcion en B_Volumen " + Excepcion;
                MessageBox.Show(MensajeExcepcion);
            }

           
        }
       
        private void Volumen_String_Click(object sender, EventArgs e)
        {

            try
            {
                TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'G', (byte)'k', Convert.ToByte(CRC), 0X7E };

                CalcularCRC();

                TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'G', (byte)'k', Convert.ToByte(CRC), 0X7E };

                EnviarComando();
                RecivirComando();

                int ElementoInicial = 6;
                int ElementoFinal = (TramaRx.Length - 4);

              Volumen_Despachado.Text = Convert.ToString(Volumen_string(ElementoInicial, ElementoFinal));
            }

            catch (Exception Excepcion)
            {
                string MensajeExcepcion = "Excepcion en Volumen_string " + Excepcion;
                MessageBox.Show(MensajeExcepcion);
            }

        }
        private void Totalizador_Click(object sender, EventArgs e)        
        {
            try
            {
                TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'G', (byte)'L', Convert.ToByte(CRC), 0X7E };

                CalcularCRC();

                TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'G', (byte)'L', Convert.ToByte(CRC), 0X7E };


                EnviarComando();

                RecivirComando();


                int ElementoInicial = 5;
                int Longitud = (TramaRx.Length - (ElementoInicial + 2));



                ObtenerValor16(ElementoInicial, Longitud);

                LCD.Text = Dato.Text;
            }

            catch (Exception Excepcion)
            {
                string MensajeExcepcion = "Excepcion en Totalizador " + Excepcion;
                MessageBox.Show(MensajeExcepcion);
            }
        }


        private void Totalizador_String_Click(object sender, EventArgs e)
        {
            TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'G', (byte)'l', Convert.ToByte(CRC), 0X7E };

            CalcularCRC();

            TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'G', (byte)'l', Convert.ToByte(CRC), 0X7E };


            EnviarComando();

            RecivirComando();


            int ElementoInicial = 5;
            int ElementoFinal = (TramaRx.Length- 4);



            Valor_string(ElementoInicial, ElementoFinal);

           
        }
        
        private decimal Valor_string(int ElementoInicial, int Longitud)
        {


            Decimal resultado = 0;
          
            byte [] Data = new byte[9];
            //INvierto la posicion del Daton en TramaRX
            int j = 0;
            for (int i = ElementoInicial; i <= Longitud; i++, j++)
            {
                Data[j] = TramaRx[i];
            }
            
            string str = ASCIIEncoding.ASCII.GetString(Data);

            if (str.IndexOf(".") > 0)
                resultado = Convert.ToDecimal(str.Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator));
            else
                resultado = Convert.ToDecimal(str);

            LCD.Text = str;
            return resultado;
        }

        private decimal Volumen_string(int ElementoInicial, int Longitud)
        {


            Decimal resultado = 0;

            byte[] Data = new byte[TramaRx.Length - 9];
            //INvierto la posicion del Daton en TramaRX
            int j = 0;
            for (int i = ElementoInicial; i <= Longitud; i++, j++)
            {
                if (TramaRx[i] != ',')
                    Data[j] = TramaRx[i];
                else
                    j = j - 1;
            }

            string str = ASCIIEncoding.ASCII.GetString(Data);


            

            if (str.IndexOf(".") > 0)
                resultado = Convert.ToDecimal(str.Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator));
            else
                resultado = Convert.ToDecimal(str);

            LCD.Text = str;
            return resultado;
        }



        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

            switch (See_tabla_4)
            {

                case  'O':

                TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)'O', (byte)See_tabla_5, (byte)Code_B, (byte)(CRC), 0X7E };
                CalcularCRC();

                TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)'O', (byte)See_tabla_5, (byte)Code_B, (byte)(CRC), 0X7E };

                EnviarComando();

                RecivirComando();


                    break;

                case 'E': //Obtener Precio de venta 

                    //TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)See_tabla_4, (byte)See_tabla_5, (byte)(TanKe), (byte)(CRC), 0X7E };

                    //CalcularCRC();

                    //TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)See_tabla_4, (byte)See_tabla_5, (byte)(TanKe), (byte)(CRC), 0X7E };

                    break;

                case 'D': //Precio 
                   //TramaTx = new byte[13] { 0x7E, 0X01, 0XFF, (byte)See_tabla_4, 0x00, 0x01, 0x01, 0X00, 0XE0, 0X8A, 0X44, (byte)(CRC), 0X7E };
                    TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)See_tabla_4, 0X02, 0x00, (byte)(CRC), 0X7E };
                    CalcularCRC();

                    TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)See_tabla_4, 0X02, 0x00, (byte)(CRC), 0X7E };

                    break;

                    case 'R':
            
                    TramaTx = new byte[6] { 0x7E, 0X01, 0XFF, (byte)See_tabla_4, 0X00, 0X7E };

                    CalcularCRC();
                    TramaTx = new byte[6] { 0x7E, 0X01, 0XFF, (byte)See_tabla_4, (byte)(CRC), 0X7E };

                 break;

                case 'G':


                 if (See_tabla_5 == 'k')
                 {
                     //7E 01 FF 47 61 00 7E // 0x47-G / 0x4B-K
                     TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)See_tabla_4, (byte)See_tabla_5, 0X03, (byte)(CRC), 0X7E };

                     CalcularCRC();
                     TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)See_tabla_4, (byte)See_tabla_5, 0X03,  (byte)(CRC), 0X7E };

                     break;
                 }

                //7E 01 FF 47 61 00 7E // 0x47-G / 0x4B-K
                TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)See_tabla_4, (byte)See_tabla_5, 0X00, 0X7E };

                CalcularCRC();
                TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)See_tabla_4, (byte)See_tabla_5, (byte)(CRC), 0X7E };
           
                 break; 
            }

            EnviarComando();

            RecivirComando();
        }

             catch (Exception Excepcion)
            {
                string MensajeExcepcion = "Excepcion en Get Comandos: " + Excepcion;
                MessageBox.Show(MensajeExcepcion);
            }
        }



        private void envio_digitos()//4 Byte Float = 32 Bit
        {
            try
            {
                char[] Vector_IEEE_32 = new char[32];
                TramaTx = new byte[13];//Trama para enviar el precio 
               

                for (int i = 0; i < 32; i++) //Cargo todo los bytes en 0 = 30 hex
                    Vector_IEEE_32[i] = '0';

                //Precio 
                //string precio_TX = (SetPrecio.Text).ToString();
                byte xx = 0;
                bool signo;


                //asignacion de signo 1= - // 0 = +
                if (SetPrecio.Text.Contains("-"))
                {
                    Vector_IEEE_32[0] = '1'; //-
                }
                else
                    Vector_IEEE_32[0] = '0';//+


                //Modifica el separador decimal por el del equipo.
                //Dat = Convert.ToDecimal(ModificarFormatoDecimal(SetPrecio.Text));

                //Obtener parte Entera
                 decimal Entero = Math.Truncate(Dat);

                //obtener parte Decimal y convertirla a Binario tipo string 
                decimal Dec = Dat - Entero;
                decimal frac = Dec;
                int conta = 0;
                string bina_dec = "";
                while (frac != 1 && conta < 23)
                {
                    frac = frac * 2;

                    if (frac > 1)
                    {
                        bina_dec += "1";
                        frac = frac - 1;
                    }
                    else
                        bina_dec += "0";

                    conta++;
                }


                Int64 Dato_preci = Convert.ToInt64(Entero);

                Int64 potencia = 0;
                double BIt = 0;
                string binario = "";
                string Mantisa = "";
                bool Activa_punto = false;
                Int16 nume_expo = 0;

                for (int j = 31; j >= 0; j--)
                {
                    potencia = Convert.ToInt64(Math.Pow(2, j)); //2^7, 2^6, 2^5, 2^4, 2^3, 2^2, 2^1, 2^0, 
                    //128, 64,  32,   16,  8,  4,   2,   1
                    BIt = (Dato_preci & potencia) / potencia;

                    if (Activa_punto)
                    {
                        nume_expo++;

                        Mantisa += Convert.ToString(BIt);
                    }

                    binario += Convert.ToString(BIt);

                    if (BIt == 1)
                        Activa_punto = true;
                }

                int exponente_dec = 127 + nume_expo;

                string exponente_String = Convert.ToString(exponente_dec, 2).PadLeft(8, '0');//convierte el dato a Binario.

                int h = 1;
                for (h = 1; h < 9; h++)//Insercion del exponente al vector
                {
                    //Vector_IEEE_32[h] = Convert.ToByte(Convert.ToInt16(exponente_String[h-1]));
                    Vector_IEEE_32[h] = Convert.ToChar(exponente_String[h - 1]);
                }

                for (h = 9; h < Mantisa.Length + 9; h++)//Insercion Mantisa
                {
                    Vector_IEEE_32[h] = Convert.ToChar(Mantisa[h - 9]);
                }

                int f = 0;


                for (; h < 32; h++)
                {
                    Vector_IEEE_32[h] = Convert.ToChar(bina_dec[f]);
                    f++;
                }

                //convertir los bytes  a hex******************************************************************************
                string byte_hex = "";
                int L = 0;
                int H = 0;
                int byteH = 0;
                int byteL = 0;

                for (int n = 0; n <= 32; n++)
                {
                    if (L == 4)
                    {
                        Dato_Hex(byte_hex, ref byteL);
                        byte_hex = "";
                        byteL = byteL << 4;
                    }

                    if (L == 8)
                    {
                        Dato_Hex(byte_hex, ref byteH);
                        byte_hex = "";
                        L = 0;
                        int cccn = byteL + byteH;
                        Precio_[3 - H] = (byte)cccn;
                        H++;
                        //byteH = byteH << 4;
                    }

                    if (n <= 31)
                        byte_hex += Vector_IEEE_32[n];

                    L++;
                }

            }
            catch (Exception Excepcion)
            {
                string MensajeExcepcion = "Excepcion en SET_Precio: " + Excepcion;
                MessageBox.Show(MensajeExcepcion);
            }

        }
            
        private void SET_Precio_Click(object sender, EventArgs e)
        {
            Dat = Convert.ToDecimal(ModificarFormatoDecimal(SetPrecio.Text));
            envio_digitos();


            TramaTx = new byte[13] { 0x7E, 0X01, 0XFF, 0x44, 0x00, (byte)TanKeSET, (byte)TanKeSET, Precio_[0], Precio_[1], Precio_[2], Precio_[3], (byte)(CRC), 0X7E };

            CalcularCRC();
            TramaTx = new byte[13] { 0x7E, 0X01, 0XFF, 0x44, 0x00, (byte)TanKeSET, (byte)TanKeSET, Precio_[0], Precio_[1], Precio_[2], Precio_[3], (byte)(CRC), 0X7E };

            EnviarComando();

            RecivirComando();
        }

           
        private void PrgramarVOl_Click(object sender, EventArgs e)
        {
             Dat = Convert.ToDecimal(ModificarFormatoDecimal(Predeterminacion.Text));
            
            envio_digitos();

            TramaTx = new byte[11] { 0x7E, 0X01, 0XFF, (byte)'S', (byte)'c', Precio_[0], Precio_[1], Precio_[2], Precio_[3], (byte)(CRC), 0X7E };

            CalcularCRC();
            //TramaTx = new byte[11] { 0x7E, 0X01, 0XFF, (byte)'S', (byte)'c', Precio_[0], Precio_[1], Precio_[2], Precio_[3], (byte)(CRC), 0X7E };


            EnviarComando();

            RecivirComando();
        }

        private void Pro_Importe_Click(object sender, EventArgs e)
        {          

            envio_digitos();

            TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'G', (byte)'c', (byte)(CRC), 0X7E };

            CalcularCRC();
            TramaTx = new byte[7] { 0x7E, 0X01, 0XFF, (byte)'G', (byte)'c',  (byte)(CRC), 0X7E };

            EnviarComando();

            RecivirComando();

            PredeImporte.Text = Dato.Text;

        }

        private void Dato_Hex(string dato, ref int Byte_)
        {
            try
            {
                switch (dato)
                {
                    case "0000":
                        Byte_ = 0x00;
                        break;

                    case "0001":
                        Byte_ = 0x01;
                        break;

                    case "0010":
                        Byte_ = 0x02;
                        break;

                    case "0011":
                        Byte_ = 0x03;
                        break;

                    case "0100":
                        Byte_ = 0x04;
                        break;

                    case "0101":
                        Byte_ = 0x05;
                        break;

                    case "0110":
                        Byte_ = 0x06;
                        break;

                    case "0111":
                        Byte_ = 0x07;
                        break;

                    case "1000":
                        Byte_ = 0x08;
                        break;

                    case "1001":
                        Byte_ = 0x09;
                        break;

                    case "1010":
                        Byte_ = 0x0A;
                        break;

                    case "1011":
                        Byte_ = 0x0B;
                        break;

                    case "1100":
                        Byte_ = 0x0C;
                        break;

                    case "1101":
                        Byte_ = 0x0D;
                        break;

                    case "1110":
                        Byte_ = 0x0E;
                        break;

                    case "1111":
                        Byte_ = 0x0F;
                        break;

                }
            }
            catch (Exception Excepcion)
            {
                string MensajeExcepcion = "Excepcion en Dato_Hex: " + Excepcion;
                MessageBox.Show(MensajeExcepcion);
               
            }

           
        }
        
        private string ModificarFormatoDecimal(string valor)
        {
            try
            {
                //Return CStr(Entero + Fraccion)
                Decimal resultado = 0;

                if (valor.IndexOf(".") > 0)
                    resultado = Convert.ToDecimal(valor.Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator));
                else
                    resultado = Convert.ToDecimal(valor);

                return resultado.ToString();
            }

            catch (Exception Excepcion)
            {
                string MensajeExcepcion = "Excepcion en ModificarFormatoDecimal: " + Excepcion;
                MessageBox.Show(MensajeExcepcion);
                return "";
            }
            
        }

        private void EnviarComando()
        {
            try
            {
                //Limpia todo lo que este en el Buffer de salida y Buffer de entrada del puerto
                PuertoCom.DiscardOutBuffer();
                PuertoCom.DiscardInBuffer();

                //Escribe en el puerto el comando a Enviar.
                PuertoCom.Write(TramaTx, 0, TramaTx.Length);

                /////////////////////////////////////////////////////////////////////////////////
                //LOGUEO DE TRAMA TRANSMITIDA
                string strTrama = "";
                for (int i = 0; i <= TramaTx.Length - 1; i++)
                    strTrama += TramaTx[i].ToString("X2") + " ";

                TX.Text = strTrama;


                SWTramas.WriteLine(
                    DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" +
                    DateTime.Now.Year.ToString().PadLeft(4, '0') + "|" +
                    DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + ":" +
                    DateTime.Now.Second.ToString().PadLeft(2, '0') + "." + DateTime.Now.Millisecond.ToString().PadLeft(3, '0') +
                    "|"  + "|Tx|" + Encoding.Default.GetString(TramaTx));
                SWTramas.Flush();
                ///////////////////////////////////////////////////////////////////////////////////

                //Tiempo muerto mientras el Surtidor Responde
                Thread.Sleep(Convert.ToInt16(Tiem_Out.Text));

            }
            catch (Exception Excepcion)
            {
                string MensajeExcepcion = "Excepcion en EnviarComando: " + Excepcion;
                MessageBox.Show(MensajeExcepcion);
            }
        }
      
        private void RecivirComando()
        {
            try
            {

            if (PuertoCom.IsOpen)
            {

                int BytesRecibidos = PuertoCom.BytesToRead;
                TramaRx = new byte[BytesRecibidos];

                //Almacena informacion en la Trama Temporal para luego eliminarle el eco
                PuertoCom.Read(TramaRx, 0, BytesRecibidos);

                //Loguea en el archivo plano la trama recibiida
                SWTramas.WriteLine(DateTime.Now + "|Rx|" + System.Text.ASCIIEncoding.ASCII.GetString(TramaRx));
                SWTramas.Flush();
                //ASCII A PUNTO FLOTANTE

                string Tramarx = "";

                for (int i = 0; i <= TramaRx.Length - 1; i++)
                    Tramarx += TramaRx[i].ToString("X2") + " ";

                RX.Text = Tramarx;
            }
            else
            {
                MessageBox.Show("El Puerto COM está Cerrado");


                if (!PuertoCom.IsOpen)
                {
                    PuertoCom.PortName = Puerto;
                    PuertoCom.BaudRate = 9600;
                    PuertoCom.StopBits = StopBits.One;
                    PuertoCom.Parity = Parity.None;
                    PuertoCom.DataBits = 8;
                    PuertoCom.Open();
                }
            } 

            int ElementoInicial = 5;
            int Longitud = (TramaRx.Length - (ElementoInicial + 2));

            if ((TramaTx[3] == 'E'))
            {
                ElementoInicial = 7;
                Longitud = (TramaRx.Length - (ElementoInicial + 2));

                ObtenerValor(ElementoInicial, Longitud);
            }


            if (See_tabla_5 == 'c' || See_tabla_5 == 'n' || See_tabla_5 == 't')
            {
                ObtenerValor(ElementoInicial, Longitud);
            }

            if (See_tabla_5 == 'a' || See_tabla_5 == 'b' || See_tabla_5 == 'e' ||
                See_tabla_5 == 'f' || See_tabla_5 == 'g' || See_tabla_5 == 'j' ||
                See_tabla_5 == 'K' || See_tabla_5 == 'L')  
            {
                ObtenerValor16(ElementoInicial, Longitud);
            }

        }
            catch (Exception Excepcion)
            {
                string MensajeExcepcion = "Excepcion en RecivirComando: " + Excepcion;
                MessageBox.Show(MensajeExcepcion);
            }

        }        
        
        private void ObtenerValor(int ElementoInicial, int Longitud)
        {
            try
            {

                G_a.Text = "";
                input = "";
                IEEE.Text = "";
                doublestr = "";          
                
                for (int i = (TramaRx.Length - 3); i >= (ElementoInicial); i--)
                {
                    //00 00 00 00 00 DC 83 40 BA 7E                 
                    input += TramaRx[i].ToString("X2");
                }
                                    
            doublestr = "";
            UInt64 bigendian;
            //consulta si la cadena de string es validad, y convierte es string a hex = out bigendian
            bool success = UInt64.TryParse(input,System.Globalization.NumberStyles.HexNumber, null, out bigendian);
            if (success)
            {
                double fractionDivide = Math.Pow(2, 23);
                double doubleout;
                
                int sign = (bigendian & 0x80000000) == 0 ? 1 : -1;
                //0x7F800000 = 11111111 00000000000000000000000 //corre 23 posiciones a la derecha... ceros "0"
                Int64 exponent = ((Int64)(bigendian & 0x7F800000) >> 23) - (Int64)127;
               UInt64 fraction = (bigendian & 0x007FFFFF); //0000 0000 0111 1111 1111 1111 1111 1111
                if (fraction == 0)
                    doubleout = sign * Math.Pow(2, exponent);
                else
                    doubleout = sign * (1 + (fraction / fractionDivide)) * Math.Pow(2, exponent);

                decimal rounded = decimal.Round(Convert.ToDecimal(doubleout), 2);
                doublestr = doubleout.ToString();


                G_a.Text = input;
                IEEE.Text = doublestr;

                Dato.Text = Convert.ToString(doublestr);              
            }
             

            }

            catch (Exception Excepcion)
            {
                string MensajeExcepcion = "Excepcion en el metodo ObtenerValor: " + Excepcion;
                MessageBox.Show(MensajeExcepcion);
            }
        }

    private void ObtenerValor16(int ElementoInicial, int Longitud)
    {
        try
        {

            G_a.Text = "";
            input = "";
            IEEE.Text = "";
            doublestr = "";

            //INvierto la posicion del Daton en TramaRX
            for (int i =(TramaRx.Length - 3); i >= (ElementoInicial); i--)
            {
                //00 00 00 00 00 DC 83 40 BA 7E                 
                input += TramaRx[i].ToString("X2");
            }

            doublestr = "";
            UInt64 bigendian;
            //consulta si la cadena de string es validad, y convierte es string a hex = out bigendian
            bool success = UInt64.TryParse(input, System.Globalization.NumberStyles.HexNumber, null, out bigendian);
            if (success)
            {
                double fractionDivide = Math.Pow(2, 52);
                double doubleout;

                int sign = (bigendian & 0x8000000000000000) == 0 ? 1 : -1;
                //0x7FF0000000000000 = 111 1111 1111 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 //corre 23 posiciones a la derecha... ceros "0"
                Int64 E = ((Int64)(bigendian & 0x7FF0000000000000) >> 52) - (Int64)1023;
                double Exponente = Math.Pow(2,E);
                UInt64 M = (bigendian & 0x000FFFFFFFFFFFFF); //0000 0000 0000 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111
                double Mantisa = (1 + (M / fractionDivide));
                double Value = sign * Exponente * Mantisa;
                
                G_a.Text = input;
                IEEE.Text = doublestr;


                Dato.Text = Convert.ToString(Value);


                if (See_tabla_5 == 0x65) // "e" Meter net totalizer reading for current product
                {
                    LCD.Text = Convert.ToString(Value);
                }

                if (See_tabla_5 == 0x4B)//"K" Real-time volume displayed during delivery. Unformatted, no rounding applied
                {
                    Volumen_Despachado.Text = Value.ToString();
                }

                //IEEE 64bit Flot
            }
            
        }

        catch (Exception Excepcion)
        {
            string MensajeExcepcion = "Excepción en ObtenerValor16: " + Excepcion;
            MessageBox.Show(MensajeExcepcion);
        }
    }
     
        static string Hex32toFloat(string Hex32Input)
        {
            try
            {

            string doublestr = "";
            UInt64 bigendian;
            bool success = UInt64.TryParse(Hex32Input,
                System.Globalization.NumberStyles.HexNumber, null, out bigendian);
            if (success)
            {
                double fractionDivide = Math.Pow(2, 23);
                double doubleout;
                
                int sign = (bigendian & 0x80000000) == 0 ? 1 : -1;
                Int64 exponent = ((Int64)(bigendian & 0x7F800000) >> 23) - (Int64)127;
                UInt64 fraction = (bigendian & 0x007FFFFF);
                if (fraction == 0)
                    doubleout = sign * Math.Pow(2, exponent);
                else
                    doubleout = sign * (1 + (fraction / fractionDivide)) * Math.Pow(2, exponent);
                doublestr = doubleout.ToString();
            }
            return doublestr;
        }
            catch (Exception Excepcion)
            {               
                string MensajeExcepcion = "Excepción en el CalcularCRC: " + Excepcion;
                MessageBox.Show(MensajeExcepcion);

                return "Excepción";
            }
            
        }

        private void CalcularCRC()
        {
            try
            {
                CRC = 0x00;


                for (int i = 1; i < TramaTx.Length - 2; i++)
                {
                    CRC += TramaTx[i];
                }

                CRC = (0 - CRC) & 255;

                TramaTx[TramaTx.Length - 2] = (byte)CRC; //Agreag el Byte del CRC a la Trama TX                
                
                      List<byte> lst = new List<byte>();
                      lst.AddRange(TramaTx);
                      byte t, scape;
                      int p;
                     
                      t = 0x7E; 
                      p = lst.IndexOf(t);
                      if (!(p > 0 && p < lst.Count)) p = -1; else p++;

                     if(p < 0)
                     {  t = 0x7D;  
                        p = lst.IndexOf(0x7D);
                        if (!(p > 0 && p < lst.Count)) p = -1; else p++;
                     }

                     if (p >= 0)
                     {   scape = ((byte)(0x20 ^ t));
                         lst.Insert(p, scape);

                         TramaTx = lst.ToArray();

                         SWRegistro.WriteLine(DateTime.Now  + "|Proceso|Se modifica caracteres prohibidos TramaTx. ");
                         SWRegistro.Flush();
                     }
            }

            catch (Exception Excepcion)
            {
                string MensajeExcepcion = "Excepción en el CalcularCRC: " + Excepcion;
                MessageBox.Show(MensajeExcepcion);
            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            See_tabla_5 = Convert.ToInt32(Convert.ToChar(comboBox2.Text)) - Convert.ToInt32('0');
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            See_tabla_4 = Convert.ToInt32(Convert.ToChar(comboBox3.Text));
        }

        private void TanK_SelectedIndexChanged(object sender, EventArgs e)
        {
            TanKe = Convert.ToInt32(Convert.ToDecimal(TanK.Text));
        }

        private void Cod_precio_TextChanged(object sender, EventArgs e)
        {

        }

        private void TanK1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TanKeSET = Convert.ToInt32(Convert.ToDecimal(TanK1.Text));
        }

        private void Code_Binary_SelectedIndexChanged(object sender, EventArgs e)
        {
            Code_B = Convert.ToInt16(Code_Binary.Text);
        }

        private void button3_Click_1(object sender, EventArgs e) //fin 
        {
            TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)'S', (byte)'u', 0x01, (byte)(CRC), 0X7E };

            CalcularCRC();
            TramaTx = new byte[8] { 0x7E, 0X01, 0XFF, (byte)'S', (byte)'u', 0x01, (byte)(CRC), 0X7E };

            EnviarComando();

            RecivirComando();
        }

       
      
      



      

   
            

    }
}
