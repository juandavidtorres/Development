//KELMER COMAS
//Development by Kelmer Ashley Comas Cardona © 2015

using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;


namespace gasolutions
{

    public static class ValidateData
    {

        // Validaciones de entrada de datos
        public static void ReadOnlyNumbers(System.Object sender, KeyPressEventArgs e)
        {
            if (Convert.ToString("0123456789" + Constants.vbBack + Constants.vbCr).IndexOf(e.KeyChar) < 0)
                e.Handled = true;
        }

        public static void ReadOnlyLetters(System.Object sender, KeyPressEventArgs e, bool withSpace)
        {
            string vbSpace = (withSpace ? " " : "");
            if (!char.IsLetter(e.KeyChar) && (Constants.vbBack + Constants.vbCr + vbSpace).IndexOf(e.KeyChar) < 0)
                e.Handled = true;
        }

        public static void ReadOnlyLettersAndNumbers(System.Object sender, KeyPressEventArgs e, bool withSpace)
        {
            string vbSpace = (withSpace ? " " : "");
            if (!char.IsLetter(e.KeyChar) && ("0123456789" + Constants.vbBack + Constants.vbCr + vbSpace).IndexOf(e.KeyChar) < 0)
                e.Handled = true;
        }

        public static void ReadOnlySymbols(System.Object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && !(("0123456789" + Constants.vbBack + Constants.vbCr).IndexOf(e.KeyChar) < 0))
                e.Handled = true;
        }

    }
}
