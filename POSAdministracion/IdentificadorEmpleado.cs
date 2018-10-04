using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using System.IO.Ports;
using POSstation.Fabrica;
using POSstation;
using System.Threading;


namespace gasolutions
{
    public partial class IdentificadorEmpleado : UserControl
    {        
        Helper OHelper = new Helper();
       // Dictionary<string, InformacionDispositivoLSIB4> ColDispositivosLSIB4 = new Dictionary<string, InformacionDispositivoLSIB4>();
       // Dictionary<string, BytesLectura> LecturasLSIB4 = new Dictionary<string, BytesLectura>();
       // List<LSIB4Reader> listaDispositivos = null;
        EstacionException LogFallas = new EstacionException();
        PropiedadesExtendidas LogPropiedades = new PropiedadesExtendidas();
        CategoriasLog LogCategorias = new CategoriasLog();
        Dictionary<string, string> RomEstacion = new Dictionary<string, string>();
        byte Cara = 0;
        string identificadorChip = null;
       // LSIB4Reader Dispositivo; 
     


        public Int32 IdEmpleado
        {
            get
            {
                return Int32.Parse(lblIdEmpleado.Text);
            }
            set
            {
                lblIdEmpleado.Text = value.ToString();
            }
        }


        public void MostrarError(string mensaje,int delay,bool eserror) {
            try
            {

                POSstation.Notificacion.Notification Control = new POSstation.Notificacion.Notification();
                Control.Mensaje = mensaje;
                Control.EsError = eserror;
                Control.TimerTiempo = delay;
                Control.Show();
            }
            catch (Exception )
            {
                
              
            }
                    

        }

        public IdentificadorEmpleado()
        {
            InitializeComponent();
        }

        public void IniciarControl()
        {
            try
            {
                CargarPuertosPC();
                cmbTipoIdent.DisplayMember = "Nombre";
                cmbTipoIdent.ValueMember = "IdTipoIdentificacion";
                cmbTipoIdent.DataSource = OHelper.RecuperarTiposIdentificacion().Tables[0];
                dgvIdentificador.DataSource = OHelper.RecuperarIdentificadoresEmpleado(Int32.Parse(lblIdEmpleado.Text));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmbTipoIdent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtRom.Text = "";
                if (cmbTipoIdent.SelectedValue.ToString() == "1")
                {
                    cmbPuerto.Enabled = true;
                    this.btnLeerChip.Enabled = true;                 
                    //this.txtRom.ReadOnly = true;
                }
                else
                {
                    cmbPuerto.Enabled = false;
                    this.btnLeerChip.Enabled = false;
                    //this.txtRom.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        public EventHandler OClose;
        private void mnuCerrar_Click(object sender, EventArgs e)
        {
           
            this.Dispose();
            OClose(sender, e);
        }

        private void CargarPuertosPC()
        {
            try
            {
                foreach (string strPuertos in SerialPort.GetPortNames())
                {
                    cmbPuerto.Items.Add(strPuertos);
                }
            }
            catch(Exception ex)
            {
                MostrarError(ex.Message, 3000, true);
            }
        }

     
        private void btnLeerChip_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPuerto.SelectedIndex != -1)
                {
                    String puerto = cmbPuerto.SelectedItem.ToString();
                    ctrlOcxChip.Puerto = puerto.Substring(puerto.IndexOf("M") + 1);
                    txtRom.Text = ctrlOcxChip.LeerRom();
                    txtRom.Text = ctrlOcxChip.ROM;
                }
            }
            catch (Exception)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nNo se pudo leer el chip. Revise la configuración";
                Popup.Popup();
            }


        }

        private void mnuNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                txtRom.Text = String.Empty;
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void dgvIdentificador_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (Boolean.Parse(dgvIdentificador.Rows[e.RowIndex].Cells["Activo"].Value.ToString()) == true)
                    {
                        OHelper.ActualizarEstadoIdIdentificador(Int32.Parse(dgvIdentificador.Rows[e.RowIndex].Cells["IdIdentificador"].Value.ToString()), false);
                    }
                    else
                    {
                        OHelper.ActualizarEstadoIdIdentificador(Int32.Parse(dgvIdentificador.Rows[e.RowIndex].Cells["IdIdentificador"].Value.ToString()), true);
                    }


                    dgvIdentificador.DataSource = OHelper.RecuperarIdentificadoresEmpleado(Int32.Parse(lblIdEmpleado.Text));
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void mnuGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtRom.TextLength > 0)
                    OHelper.InsertarIdentificadorEmpleado(Int32.Parse(lblIdEmpleado.Text), txtRom.Text, Int16.Parse(cmbTipoIdent.SelectedValue.ToString()), true);

                dgvIdentificador.DataSource = OHelper.RecuperarIdentificadoresEmpleado(Int32.Parse(lblIdEmpleado.Text));

                Popup.ContentText = "Operacion exitosa";
                Popup.Popup();
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }


        private void IdentificadorEmpleado_Load(object sender, EventArgs e)
        {
            IniciarControl();  
        }


        //private void IniciarDispositivolsib4()
        //{
        //    try
        //    {
                 
                
        //        Helper OHelper = new Helper();          
                
        //        if (string.IsNullOrEmpty(cmbPuerto.Text))
        //        {
        //            throw new Exception("Por favor seleccione un puerto");
        //        }    
        //        if (Dispositivo!=null )
        //        {
        //           this.Dispositivo.CerrarPuerto();
        //           //this.Dispositivo.Dispose();
        //        }

                
        //        Dispositivo = new LSIB4Reader();
        //        Dispositivo.ReaderHostMain(cmbPuerto.SelectedItem.ToString(), 0);
        //        Dispositivo.EnviarBytesLecturaChipPorDti += OEventos_EnviarBytesLecturaChipPorDti;
                         
        //    }
        //    catch (Exception ex)
        //    {
        //        LogCategorias.Clear();
        //        LogCategorias.Agregar("SeguimientoCodigoDTI");
        //        LogPropiedades.Clear();
        //        LogPropiedades.Agregar("Mensaje", ex.Message);
        //        POSstation.Fabrica.LogIt.Loguear("Error iniciando lectores lsib4", LogPropiedades, LogCategorias);
        //        MostrarError(ex.Message + " El puerto " + cmbPuerto.Text + " esta siendo usado. Por favor verifique e intente nuevamente. ", 3000, true);
        //    }

        //}


        //private void OEventos_EnviarBytesLecturaChipPorDti(System.Array Lectura, string Puerto, int IdDispositivoDti)
        //{
        //    try
        //    {

        //        byte[] paginas = new byte[147];
        //        int i = 0;
        //        byte[] cabeceratrama = new byte[19];
        //        string trama = null;
        //        System.Text.UTF8Encoding convercion = new System.Text.UTF8Encoding();
        //        string[] Temporal = null;
        //        string puertodti = "";

        //        Helper oHelper = new Helper();
        //        int j = 0;


        //        //'Datos de la lectura del chip
        //        if (Lectura.Length >= 147)
        //        {

        //            for (i = 0; i <= 18; i++)
        //            {
        //                cabeceratrama[i] = (byte)Lectura.GetValue(i);
        //            }


        //            for (i = 0; i <= Lectura.Length - 1; i++)
        //            {
        //                paginas[j] = (byte)Lectura.GetValue(i);
        //                j = j + 1;
        //            }

        //            //Saco la cabecera de la trama que corresponde al puerto de la dti y el rom
        //            trama = convercion.GetString(cabeceratrama);

        //            if (!string.IsNullOrEmpty(trama))
        //            {
        //                Temporal = trama.Split(('.'));
        //                puertodti = Temporal[0];
        //                identificadorChip = Temporal[1];
        //                ColocarIdentificadorEnTextBox(identificadorChip);                        
        //            }

        //        }
        //        else
        //        {
        //            throw new System.Exception("Falla al intentar leer el chip por LSIB4");
        //        }

        //    }
        //    catch (System.Exception ex)
        //    {
        //        MostrarError(ex.Message, 3000, true);
        //    }
        //    finally
        //    {             
        //       // Dispositivo.CerrarPuerto();
        //    }

        //}

       // delegate void setText( string text);

        //private void ColocarIdentificadorEnTextBox(string identificador)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(identificador))
        //        {
        //            if (this.txtRom.InvokeRequired)
        //            {
        //                setText d = new setText(ColocarIdentificadorEnTextBox);
        //                this.Invoke(d, new object[] { identificador });
        //            }
        //            else
        //            {
        //                this.txtRom.Text = identificador;

        //            }


        //        }
        //        else
        //        {

        //            MostrarError("No se pudo leer el chip, por favor verifique e intente nuevamente", 3000, true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MostrarError(ex.Message, 3000, true);
        //    }         
            
        //}

        //private void cmbPuerto_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    txtRom.Text = "";
        //    IniciarDispositivolsib4();
        //}

      
                   
    }
}
