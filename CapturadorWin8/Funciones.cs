using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace SATELITELite
{
    public static class Funciones
    {
        public static async void MsgBox(string mensaje)
        {
            try
            {
                var messageDialog = new MessageDialog(mensaje);
                // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers


                // Show the message dialog
                await messageDialog.ShowAsync();
            }
            catch
            {
                //throw;
            }
        }
    }
}
