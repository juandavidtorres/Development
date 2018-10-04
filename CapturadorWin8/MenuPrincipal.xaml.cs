using SATELITELite.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página básica está documentada en http://go.microsoft.com/fwlink/?LinkId=234237

namespace SATELITELite
{
    /// <summary>
    /// Página básica que proporciona características comunes a la mayoría de las aplicaciones.
    /// </summary>
    public sealed partial class MenuPrincipal : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// Este puede cambiarse a un modelo de vista fuertemente tipada.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper se usa en cada una de las páginas para ayudar con la navegación y 
        /// la administración de la duración de los procesos
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public MenuPrincipal()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        /// <summary>
        /// Rellena la página con el contenido pasado durante la navegación. Cualquier estado guardado se
        /// proporciona también al crear de nuevo una página a partir de una sesión anterior.
        /// </summary>
        /// <param name="sender">
        /// El origen del evento; suele ser <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Datos de evento que proporcionan tanto el parámetro de navegación pasado a
        /// <see cref="Frame.Navigate(Type, Object)"/> cuando se solicitó inicialmente esta página y
        /// un diccionario del estado mantenido por esta página durante una sesión
        /// anterior. El estado será null la primera vez que se visite una página.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Mantiene el estado asociado con esta página en caso de que se suspenda la aplicación o
        /// se descarte la página de la memoria caché de navegación.  Los valores deben cumplir los requisitos
        /// de serialización de <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">El origen del evento; suele ser <see cref="NavigationHelper"/></param>
        /// <param name="e">Datos de evento que proporcionan un diccionario vacío para rellenar con
        /// un estado serializable.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region Registro de NavigationHelper

        /// Los métodos proporcionados en esta sección se usan simplemente para permitir
        /// que NavigationHelper responda a los métodos de navegación de la página.
        /// 
        /// Debe incluirse lógica específica de página en los controladores de eventos para 
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// y <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// El parámetro de navegación está disponible en el método LoadState 
        /// junto con el estado de página mantenido durante una sesión anterior.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button oBoton = (Button) sender;
            switch (oBoton.Name)
            {
                case "btnTurno":
                    if (!Frame.Navigate(typeof(MenuTurno)))
                    {
                        throw new Exception("Failed to create MenuTurno page");
                    }
                    break;
                case "btnImpresion":
                    if (!Frame.Navigate(typeof(MenuImpresion)))
                    {
                        throw new Exception("Failed to create MenuImpresion page");
                    }
                    break;
                case "btnPredeterminar":
                    if (!Frame.Navigate(typeof(MenuPredeterminacion)))
                    {
                        throw new Exception("Failed to create MenuPredeterminacion page");
                    }
                    break;
                case "btnProductos":
                    if (!Frame.Navigate(typeof(MenuProductosCanastilla)))
                    {
                        throw new Exception("Failed to create MenuProductosCanastilla page");
                    }
                    break;
                case "btnFidelizacion":
                    if (!Frame.Navigate(typeof(MenuFidelizacion)))
                    {
                        throw new Exception("Failed to create MenuFidelizacion page");
                    }
                    break;
                case "btnGerenciamiento":
                    if (!Frame.Navigate(typeof(MenuGerenciamiento)))
                    {
                        throw new Exception("Failed to create MenuGerenciamiento page");
                    }
                    break;
                case "btnAdicional":
                    if (!Frame.Navigate(typeof(MenuAdicional)))
                    {
                        throw new Exception("Failed to create MenuAdicional page");
                    }
                    break;
                case "btnOperaciones":
                    if (!Frame.Navigate(typeof(MenuOperaciones)))
                    {
                        throw new Exception("Failed to create MenuOperaciones page");
                    }
                    break;
                case "btnModificacionVenta":
                    if (!Frame.Navigate(typeof(MenuModificacionVenta)))
                    {
                        throw new Exception("Failed to create MenuModificacionVenta page");
                    }
                    break;
                case "btnVentaCheque":
                    if (!Frame.Navigate(typeof(MenuVentaCheque)))
                    {
                        throw new Exception("Failed to create MenuVentaCheque page");
                    }
                    break;
                case "btnVentaPrepago":
                    if (!Frame.Navigate(typeof(MenuVentaPrepago)))
                    {
                        throw new Exception("Failed to create MenuVentaPrepago page");
                    }
                    break;
                case "btnDevoluciones":
                    if (!Frame.Navigate(typeof(MenuCambioCheque)))
                    {
                        throw new Exception("Failed to create MenuCambioCheque page");
                    }
                    break;
                case "btnConfiguracion":
                    if (!Frame.Navigate(typeof(MenuConfiguracion)))
                    {
                        throw new Exception("Failed to create MenuConfiguracion page");
                    }
                    break;
                case "btnEnviarDatosConductor":
                    if (!Frame.Navigate(typeof(MenuEnvioDatosConductor)))
                    {
                        throw new Exception("Failed to create MenuEnvioDatosConductor page");
                    }
                    break;
                    
                default:
                    Funciones.MsgBox(string.Format("Boton No Asignado: {0}", oBoton.Name));
                    break;
            }
        }
    }

  
}
