using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel; 

namespace Controles
{
    public static class Inputbox
    {

        static Form oForma;
        static Label oMensaje;
        static TextBox oTexto; // Elementos necesarios
        static Button oAceptar;
        static Button oCancelar;
        static string Valor;

        /// <summary>
        /// Objeto Estático que muestra un pequeño diálogo para introducir datos
        /// </summary>
        /// <param name="title">Título del diálogo</param>
        /// <param name="prompt">Texto de información</param>
        /// <param name="posicion">Posición de inicio</param>
        /// <returns>Devuelve la escrito en la caja de texto como string</returns>
        public static string Show(string title, string prompt, FormStartPosition posicion)
        {

            oForma = new Form();
            oForma.Text = title;
            oForma.ShowIcon = true;
            //f.Icon =default;
            oForma.KeyPreview = true;
            oForma.ShowInTaskbar = false;
            oForma.MaximizeBox = false;
            oForma.MinimizeBox = false;
            oForma.Width = 400;
            oForma.FormBorderStyle = FormBorderStyle.FixedDialog;
            oForma.Height = 120;
            oForma.StartPosition = posicion;
            oForma.KeyPress += new KeyPressEventHandler(f_KeyPress);

            oMensaje = new Label();
            oMensaje.AutoSize = true;
            //oMensaje.Font = "Microsoft Sans Serif, 8,25pt, style=Bold";
            oMensaje.Text = prompt;

            oTexto = new TextBox();
            oTexto.Width = 382;
            oTexto.Top = 40;

            oAceptar = new Button();
            oAceptar.Text = "Aceptar";
            oAceptar.Click += new EventHandler(oAceptar_Click);


            oCancelar = new Button();
            oCancelar.Text = "Cancelar";
            oCancelar.Click += new EventHandler(oCancelar_Click);

            oForma.Controls.Add(oMensaje);
            oForma.Controls.Add(oTexto);
            oForma.Controls.Add(oAceptar);
            oForma.Controls.Add(oCancelar);

            oMensaje.Top = 10;
            oTexto.Left = 5;
            oTexto.Top = 30;

            oAceptar.Left = 235;
            oAceptar.Top = 60;

            oCancelar.Left = 310;
            oCancelar.Top = 60;

            oForma.ShowDialog();
            return (Valor);
        }

        static void f_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (Convert.ToChar(e.KeyChar))
            {

                case ('\r'):
                    Acepta();
                    break; ;

                case (''):
                    Cancela();
                    break; ;
            }
        }
        static void oCancelar_Click(object sender, EventArgs e)
        {
            Cancela();
        }
        static void oAceptar_Click(object sender, EventArgs e)
        {
            Acepta();
        }
        private static string Val
        {

            get { return (Valor); }
            set { Valor = value; }
        }
        private static void Acepta()
        {
            Val = oTexto.Text;
            oForma.Dispose();
        }
        private static void Cancela()
        {
            Val = null;
            oForma.Dispose();
        }


    }

}
