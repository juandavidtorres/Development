using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using PosStation.gsClientes;
using gasolutions.UInterface;
using PosStation.Generaciones;
using PosStation.gsDevoluciones;
using PayOffice;
using Controles;
using System.Diagnostics;
using POSstation.Fabrica;


namespace  PosStation.MenuFinanciera
{
    public partial class MenuFinanciera : gasolutions.UInterface.Menu
    {

        //Constructor
         public MenuFinanciera() 
         { 
             InitializeComponent();
             base.Initialize();
         }
        
         protected override void InitializeOptions()
         {
             base.View = this.panel2;

             //nombre del boton y la vista o item de menu que se va a mostrar
             base.menuItems = new Dictionary<string, ItemMenu>
             { 
                   { "btnFinanciera",       new gsFinacieras()},                
                   { "btnTransportadora",   new gsTransportadora()},           
                   { "btnConsignacion",     new gsConsigTransportadora()},
                   { "btnCheque",           new gsCheques()},
                   { "btnDevolucion",       new gsDevolucion()},
                   { "btnFacturar",         new gsOrdenPedido()}               
             };      

         }


        //permisos que se van a aplicar por opciones
        protected override void AplicarPermisosPorAcciones()
        {
            try
            {
                Helper oHelper = new Helper();

                if (MainForm.UserId.HasValue)
                {
                    btnFinanciera.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.ABMFinancieras);
                    btnTransportadora.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.ABMTransportadoras);
                    btnConsignacion.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.ConsignacionesTransportadora);
                    btnCheque.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.AutorizacionCheques);
                    btnFacturar.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.SolicitudOrdenPedidoCombustible);
                    btnDevolucion.Enabled = oHelper.ValidarPermisosPorAccion(MainForm.UserId.Value, (int)AccionesDataAdminColombia.DevolucionCheques);
                }
                else
                {
                    MessageBox.Show("El usuario actual no se ha podido autenticar en el sistema");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
    }
}
