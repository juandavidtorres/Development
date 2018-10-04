using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using POSstation.Fabrica;
using System.ComponentModel.Design;
namespace PosConfiguracion
{
    public partial class Visualizacion : UserControl
    {

        Helper oHelper = new Helper();
        Boolean EsGridEstacionContruido = false;
        Color[] Colores = { Color.LightCyan, Color.LightGoldenrodYellow, Color.LightGray, Color.LightGreen, Color.LightPink, Color.LightSalmon, Color.LightSeaGreen, Color.LightSkyBlue, Color.LightSlateGray, Color.LightSteelBlue, Color.LightYellow, Color.LemonChiffon, Color.LightBlue, Color.LightCoral };
        

        public Visualizacion()
        {
            InitializeComponent();
           
        }

        public void IniciarControl()
        {
            try
            {
                RecuperarConfiguracion();
                AplicarPermisosPorAcciones();
                RecuperarEstaciones();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
           
        }

        private void AplicarPermisosPorAcciones()
        {
            try
            {
                if (frmMain.UserId.HasValue)
                {
                    if (!oHelper.ValidarPermisosPorAccion(frmMain.UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionEstacion))
                    {
                        this.btnEditar.Enabled = false;
                    }

                    if (!oHelper.ValidarPermisosPorAccion(frmMain.UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionDatosEstacion))
                    {
                        this.grdEstaciones.Enabled = false;
                    }
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
                Application.Exit();
            }
        }

        public string MensajeBoton
        {
            set
            { toolTip1.SetToolTip(btnEditar, value);}
        }

        private void RecuperarEstaciones()
        {

            DataGridViewComboBoxColumn ComboC = (DataGridViewComboBoxColumn)this.grdEstaciones.Columns["IdCiudadGrillaEstacion"];
            ComboC.DisplayMember = "Nombre";
            ComboC.ValueMember = "IdCiudad";
            ComboC.DataSource = oHelper.RecuperarMunicipios().Tables[0];
            
            this.grdEstaciones.DataSource = oHelper.RecuperarEstaciones().Tables[0];
            EsGridEstacionContruido = true;
        }

        private void RecuperarConfiguracion()
        {
            try
            {
                //IslaActual = "";
                
                Int32 IndiceColor = 0;

                DataTable ds = oHelper.RecuperarConfiguracion().Tables[0];
                grdConfiguracion.Rows.Clear();
                for (Int32 I = 0; I < ds.Rows.Count; I++)
                {
                    grdConfiguracion.Rows.Add(ds.Rows[I].ItemArray);
                    grdConfiguracion.Rows[I].DefaultCellStyle.BackColor = Colores[IndiceColor];

                    if (Colores.GetLength(0) - 1 == IndiceColor)
                    {
                        IndiceColor = 0;
                    }
                    else
                    {
                        IndiceColor += 1;
                    }
                }
                //grdConfiguracion.Rows.DefaultCellStyle.BackColor = Colores[1];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdEstaciones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               
                
                if (EsGridEstacionContruido)
                {
                    if ((!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["IdEstacionGrillaEstacion"].Value.ToString())) && (!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["CodigoGrillaEstacion"].Value.ToString())) && (!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["NombreGrillaEstacion"].Value.ToString())) && (!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["NitGrillaEstacion"].Value.ToString())) && (!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["DireccionGrillaEstacion"].Value.ToString())) && (!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["TelefonoGrillaEstacion"].Value.ToString())) && (!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["IdCiudadGrillaEstacion"].Value.ToString())) && (!String.IsNullOrEmpty(grdEstaciones.Rows[0].Cells["CodigoEstacionMenoCash"].Value.ToString())))
                    {
                        oHelper.ActualizarEstacion(Int16.Parse(grdEstaciones.Rows[0].Cells["IdEstacionGrillaEstacion"].Value.ToString()), grdEstaciones.Rows[0].Cells["CodigoGrillaEstacion"].Value.ToString(), grdEstaciones.Rows[0].Cells["NombreGrillaEstacion"].Value.ToString(), grdEstaciones.Rows[0].Cells["NitGrillaEstacion"].Value.ToString(), grdEstaciones.Rows[0].Cells["DireccionGrillaEstacion"].Value.ToString(), grdEstaciones.Rows[0].Cells["TelefonoGrillaEstacion"].Value.ToString(), Int32.Parse(grdEstaciones.Rows[0].Cells["IdCiudadGrillaEstacion"].Value.ToString()), grdEstaciones.Rows[0].Cells["CodigoEstacionMenoCash"].Value.ToString());
                        RecuperarEstaciones();    
                    }

                    else if (((!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["CodigoGrillaEstacion"].Value.ToString())) && (!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["NombreGrillaEstacion"].Value.ToString())) && (!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["NitGrillaEstacion"].Value.ToString())) && (!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["DireccionGrillaEstacion"].Value.ToString())) && (!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["TelefonoGrillaEstacion"].Value.ToString())) && (!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["IdCiudadGrillaEstacion"].Value.ToString()))) && (!String.IsNullOrEmpty(grdEstaciones.Rows[0].Cells["CodigoEstacionMenoCash"].Value.ToString())))
                        {
                            oHelper.InsertarEstacion(grdEstaciones.Rows[0].Cells["CodigoGrillaEstacion"].Value.ToString(), grdEstaciones.Rows[0].Cells["NombreGrillaEstacion"].Value.ToString(), grdEstaciones.Rows[0].Cells["NitGrillaEstacion"].Value.ToString(), grdEstaciones.Rows[0].Cells["DireccionGrillaEstacion"].Value.ToString(), grdEstaciones.Rows[0].Cells["TelefonoGrillaEstacion"].Value.ToString(), Int32.Parse(grdEstaciones.Rows[0].Cells["IdCiudadGrillaEstacion"].Value.ToString()), grdEstaciones.Rows[0].Cells["CodigoEstacionMenoCash"].Value.ToString());
                        RecuperarEstaciones();    
                        }
                                  
                        //RecuperarDatosBasicos(oHelper);
                    
                               
                }
            }
            catch (Exception ex)
            {               
                MessageBox.Show(ex.Message);
            }
      

        }

        public event EventHandler Mostrar_Configuracion;

        private void btnEditar_Click(object sender, EventArgs e) 
        {
            Mostrar_Configuracion(sender, e);
        }

        private void grdEstaciones_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Estaciones [" + e.Exception.Message + "] \n fila: " + e.RowIndex.ToString() + " columna: " + e.ColumnIndex.ToString() );
        }

    

    

    }
}
