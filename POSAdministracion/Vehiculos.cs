using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using System.Collections;
using gasolutions.UInterface;
using System.IO.Ports;
using Controles;
using POSstation.Fabrica;
using POSstation.Protocolos;
using POSstation;





namespace gasolutions
{
    public partial class Vehiculos : UserControl
    {
        Helper OHelper = new POSstation.AccesoDatos.Helper();
        Int32 IdCliente;
        Int32 oCredito;
        string oPlaca = "";

        //Dictionary<string, InformacionDispositivoLSIB4> ColDispositivosLSIB4 = new Dictionary<string, InformacionDispositivoLSIB4>();
        //Dictionary<string, BytesLectura> LecturasLSIB4 = new Dictionary<string, BytesLectura>();
        //List<LSIB4Reader> listaDispositivos = null;
        EstacionException LogFallas = new EstacionException();
        PropiedadesExtendidas LogPropiedades = new PropiedadesExtendidas();
        CategoriasLog LogCategorias = new CategoriasLog();
        Dictionary<string, string> RomEstacion = new Dictionary<string, string>();
        //byte Cara = 0;
        string identificadorChip = null;
       



        public Vehiculos()
        {
            InitializeComponent();
        }

        public string Placa
        {
            get
            {
                return oPlaca;
            }
            set
            {
                oPlaca = value;
            }
        }

        public Int32 Cliente
        {
            set
            {
                IdCliente = value;
            }
        }

        public Int32 IdCredito
        {
            get
            {
                return oCredito;
            }
        }

        public void IniciarForma()
        {
            this.Cursor = Cursors.WaitCursor;
            txtPlaca.Tag = oPlaca;
            txtPlaca.Text = oPlaca;
            CargarTiposIdentificadoresVehiculo();
            CargarTiposVehiculo();
            CargarMotivosBloqueo();
            CargarPuertosPC();
            FormatoFormularioInicial();
            this.Cursor = Cursors.Default;

            if (!String.IsNullOrEmpty(oPlaca))
                this.txtPlaca.Text = oPlaca;
            this.CargarDatosVehiculo(oPlaca);

        }

        private void CargarTiposIdentificadoresVehiculo()
        {
            try
            {
                cmbTipoIdentificador.DisplayMember = "Nombre";
                cmbTipoIdentificador.ValueMember = "IdTipoIdentificacion";
                cmbTipoIdentificador.DataSource = OHelper.RecuperarTiposIdentificacion().Tables[0];
            }
            catch
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nNo se pudieron cargar los tipos de identificacion de vehiculo";
                Popup.Popup();
            }
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
            catch
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nNo se pudieron cargar los puertos del PC para leer el chip";
                Popup.Popup();
            }
        }


        private void CargarMotivosBloqueo()
        {
            try
            {
                cmbCausalBloqueo.DisplayMember = "Descripcion";
                cmbCausalBloqueo.ValueMember = "IdCausal";
                cmbCausalBloqueo.DataSource = OHelper.RecuperarMotivosBloqueo().Tables[0];
            }
            catch
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nNo se pudieron cargar los motivos de bloqueo";
                Popup.Popup();
            }
        }


        private void CargarTiposVehiculo()
        {
            try
            {
                cmbTipoVehiculo.DisplayMember = "Descripcion";
                cmbTipoVehiculo.ValueMember = "IdTipoVehiculo";
                cmbTipoVehiculo.DataSource = OHelper.RecuperarTiposVehiculo().Tables[0];
            }
            catch
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nNo se pudieron cargar los tipos de vehiculo";
                Popup.Popup();
            }
        }

        public void FormatoFormularioInicial()
        {
            txtPlaca.Tag = "";
            txtModelo.Text = "";
            txtPlaca.Text = "";
            cmbTipoVehiculo.SelectedIndex = -1;
            //cmbFormaPago.SelectedIndex = -1;
            cmbCausalBloqueo.SelectedIndex = -1;
            //cmbFinanciera.SelectedIndex = -1;
            //txtPorcentajeCredito.Text = "";
            txtNuip.Text = "";
            txtIdentificador.Text = "";
            txtNroTanques.Text = "";
            txtPropietario.Text = "";
            HabilitarControles(true);
            txtPlaca.Focus();
            txtNuip.ReadOnly = false;
            txtPropietario.ReadOnly = false;
            ChkAplicaDataTrack.Checked = false;

        }

        private void LimpiarFormularioSecundario()
        {
            txtPlaca.Tag = "";
            txtModelo.Text = "";
            cmbTipoVehiculo.SelectedIndex = -1;
            //cmbFormaPago.SelectedIndex = -1;
            cmbCausalBloqueo.SelectedIndex = -1;
            //cmbFinanciera.SelectedIndex = -1;
            //txtPorcentajeCredito.Text = "";
            txtNuip.Text = "";
            txtPropietario.Text = "";
            txtIdentificador.Text = "";

            txtModelo.Focus();
            ChkAplicaDataTrack.Checked = false;
        }

        private void HabilitarControles(Boolean Valor)
        {
            this.mnuGuardar.Enabled = Valor;
        }

        //private void btnLeerChip_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        LogCategorias.Clear();
        //        LogCategorias.Agregar("Ibutton");
        //        LogPropiedades.Clear();
        //        LogPropiedades.Agregar("Cara", Cara.ToString());
        //        POSstation.Fabrica.LogIt.Loguear("Se solicita la lectura del ibutton", LogPropiedades, LogCategorias);


        //        //IniciarDispositivosLSIB4();
        //        //RecuperarConfiguracionCara();

        //        Helper OHelper = new Helper();
        //        if (ColDispositivosLSIB4.ContainsKey(Cara.ToString()))
        //        {
        //            InformacionVehiculo OPlaca = new InformacionVehiculo();
        //            OPlaca = EsperarDatosChipLectorDtiImpresionTicket(Cara.ToString());

        //            if (!String.IsNullOrEmpty(OPlaca.Rom))
        //            {
        //                txtIdentificador.Text = OPlaca.Rom;
        //                ColDispositivosLSIB4.Remove(Cara.ToString());

        //            }
        //            else
        //            {
        //                Popup.ContentText = "No se pudo leer el Chip, intente nuevamente";
        //                Popup.Popup();
        //            }

        //        }
        //        else
        //        {
        //            Popup.ContentText = "\t\t\tData Administrator\n\nNo hay un Chip conectado, por favor verifique.";
        //            Popup.Popup();
        //        }

        //    }
        //    catch (System.Data.DataException EXBD)
        //    {
        //        LogFallas.ReportarError(EXBD, "oEventos_SolicitudDatosIbutton", "Cara:  " + Cara.ToString(), " Puerto:  Ibutton");
        //        // ImpresoraTurno.ImprimirExcepcion(EXBD.Message, ImpresoraEstacion.CrearImpresora(cara))

        //    }
        //    catch (System.Data.SqlClient.SqlException EXSQL)
        //    {
        //        LogFallas.ReportarError(EXSQL, "oEventos_SolicitudDatosIbutton", "Cara:  " + Cara.ToString(), " Puerto:  Ibutton");
        //        // ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, ImpresoraEstacion.CrearImpresora(cara))

        //    }
        //    catch (System.Exception ex)
        //    {
        //        LogFallas.ReportarError(ex, "oEventos_SolicitudDatosIbutton", "Cara:  " + Cara.ToString(), " Puerto:  Ibutton");
        //        //  ImpresoraTurno.ImprimirExcepcion(ex.Message, ImpresoraEstacion.CrearImpresora(cara))
        //        Popup.ContentText = "\t\t\tData Administrator\n\nNo hay un Chip conectado, por favor verifique.";
        //        Popup.Popup();
        //    }

        //}

        private void mnuNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                FormatoFormularioInicial();
            }
            catch (ArgumentNullException)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nEl argumento hizo referencia a un objeto cuyo estado es nulo";
                Popup.Popup();
            }
            catch (FormatException)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nEl formato de la cadena a convertir no es válido";
                Popup.Popup();
            }
            catch (OverflowException)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nLa cadena a convertir representa un número menor que MinValue o mayor que MaxValue.";
                Popup.Popup();
            }
            catch (ArgumentOutOfRangeException)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nRowIndex está fuera del intervalo válido, que va desde 0 hasta el número de filas del control menos 1.";
                Popup.Popup();
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
                if (txtModelo.Text.Trim().Length > 0 && txtPlaca.Text.Trim().Length > 0 && txtNuip.Text.Trim().Length > 0 && cmbCausalBloqueo.SelectedIndex != -1 && txtNroTanques.Text.Trim().Length > 0 && cmbTipoIdentificador.SelectedIndex != -1)
                {
                    if (Int16.Parse(txtNroTanques.Text) < 1)
                    {
                        throw new Exception("Debe Ingresar minimo un tanque");
                    }

                    if (OHelper.ExisteVehiculoLocal(txtPlaca.Text.Trim()))
                    {
                       
                        OHelper.ActualizarVehiculo(txtPlaca.Text.Trim(), txtModelo.Text.Trim(), Int32.Parse(cmbTipoVehiculo.SelectedValue.ToString()), Int16.Parse(cmbCausalBloqueo.SelectedValue.ToString()), txtNuip.Text.Trim(), 0, txtIdentificador.Text.Trim(), Int32.Parse(cmbTipoIdentificador.SelectedValue.ToString()), false, short.Parse(txtNroTanques.Text.Trim()), txtPropietario.Text.Trim(),ChkAplicaDataTrack.Checked);
                        LimpiarCampos();

                    }
                    else
                    {
                        OHelper.InsertarVehiculo(txtPlaca.Text.Trim(), txtModelo.Text.Trim(), Int32.Parse(cmbTipoVehiculo.SelectedValue.ToString()), Int16.Parse(cmbCausalBloqueo.SelectedValue.ToString()), txtNuip.Text.Trim(), 0, txtIdentificador.Text.Trim(), Int32.Parse(cmbTipoIdentificador.SelectedValue.ToString()), false, short.Parse(txtNroTanques.Text.Trim()), txtPropietario.Text.Trim(), ChkAplicaDataTrack.Checked);
                        LimpiarCampos();
                    }

                    Popup.ContentText = "\t\t\tData Administrator\n\nEl vehiculo fue guardado satisfactoriamente";
                    Popup.Popup();
                }
                else
                {
                    Popup.ContentText = "\t\t\tData Administrator\n\nHay campos obligatorios que no han sido llenados";
                    Popup.Popup();
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }


        private void LimpiarCampos()
        {
            txtIdentificador.Clear();
            txtModelo.Clear();
            txtNroTanques.Clear();
            txtPlaca.Clear();
            txtNuip.Clear();
            txtPropietario.Clear();
        }

        public event EventHandler oClosed;

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            //if (Dispositivo != null)
            //{
            //    Dispositivo.CerrarPuerto();
            //}


           // this.Dispose();
            this.Visible = false;
            oClosed(sender, e);
        }

        private void CargarDatosVehiculo(String placa)
        {
            try
            {
                IDataReader Vehiculo;

                if (OHelper.ExisteVehiculoLocal(placa))
                {
                    Vehiculo = OHelper.RecuperarVehiculoLocalPorPlaca(placa);
                    EstablecerDatosVehiculo(Vehiculo);
                }
                else
                {
                    Vehiculo = OHelper.RecuperarVehiculoPorPlaca(placa);
                    EstablecerDatosVehiculo(Vehiculo);
                    //Popup.ContentText = "\t\t\tData Administrator\n\nSe recuperaron los datos del vehiculo del CDC";
                    //Popup.Popup();
                }
            }
            catch (Exception ex)
            {
                LimpiarFormularioSecundario();
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void EstablecerDatosVehiculo(IDataReader Vehiculo)
        {
            try
            {
                if (Vehiculo.Read())
                {
                    Int32 estado = 0;
                    txtModelo.Text = Vehiculo.GetString(Vehiculo.GetOrdinal("Modelo"));
                    cmbTipoVehiculo.SelectedValue = Vehiculo.GetInt32(Vehiculo.GetOrdinal("IdTipoVehiculo"));
                    cmbCausalBloqueo.SelectedValue = Vehiculo.GetInt16(Vehiculo.GetOrdinal("IdCausalBloqueo"));
                    txtNuip.Text = Vehiculo.GetString(Vehiculo.GetOrdinal("NuipCliente"));
                    txtIdentificador.Text = Vehiculo.GetString(Vehiculo.GetOrdinal("Identificador"));
                    cmbTipoIdentificador.SelectedValue = Vehiculo.GetInt32(Vehiculo.GetOrdinal("IdTipoIdentificador"));
                    estado = Vehiculo.GetInt32(Vehiculo.GetOrdinal("ControlKm"));
                    txtNroTanques.Text = Vehiculo.GetInt32(Vehiculo.GetOrdinal("NroTanque")).ToString();
                    txtPropietario.Text = Vehiculo.GetString(Vehiculo.GetOrdinal("NuipPropietario"));
                    ChkAplicaDataTrack.Checked = Vehiculo.GetBoolean(Vehiculo.GetOrdinal("AplicaDataTrack"));

                    if (estado == 0)
                    {
                        //  chkControlKm.Checked = false;
                    }
                    else
                    {
                        // chkControlKm.Checked = true;
                    }

                    txtModelo.Focus();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtPlaca_Leave(object sender, EventArgs e)
        {
            if (txtPlaca.Text != txtPlaca.Tag.ToString())
            {
                txtPlaca.Tag = txtPlaca.Text;
                oPlaca = txtPlaca.Text;
                CargarDatosVehiculo(txtPlaca.Text);
            }
        }

        private void txtNuip_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataSet oInformacion = new DataSet();
                oInformacion.Load(OHelper.RecuperarClienteLocal("*"), LoadOption.Upsert, "Cliente");
                Controles.frmAyuda oAyuda = new frmAyuda();
                oAyuda.TituloVentana = "Clientes";
                oAyuda.UbicacionFormulario = FormStartPosition.CenterParent;
                oAyuda.Informacion = oInformacion.Tables[0];
                oAyuda.ColumnReturn = 0;
                oAyuda.ShowDialog();
                if (string.IsNullOrEmpty(oAyuda.ValorRegistroSeleccionado))
                {
                    txtNuip.Text = "";
                }
                else
                {
                    txtNuip.Text = oAyuda.ValorRegistroSeleccionado.ToString();
                }
                oAyuda.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public event WorkerEndHandler MostrarCredito;

        //private void mnuSalir_Click(object sender, EventArgs e)
        //{
        //    this.Visible = false;
        //    oClosed(sender, e);
        //}

        private void txtModelo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!(e.KeyValue == 8 || e.KeyValue == 46 || e.KeyValue >= 48 && e.KeyValue <= 57 || e.KeyValue >= 96 && e.KeyValue <= 105))
                {
                    e.SuppressKeyPress = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modelo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtNroTanques_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!(e.KeyValue == 8 || e.KeyValue == 46 || e.KeyValue >= 48 && e.KeyValue <= 57 || e.KeyValue >= 96 && e.KeyValue <= 105))
                {
                    e.SuppressKeyPress = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NroTanques", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmbTipoIdentificador_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoIdentificador.SelectedIndex != -1)
                {
                    if (TipoIdentificadorVehiculo.CHIP == (TipoIdentificadorVehiculo)cmbTipoIdentificador.SelectedValue)
                    {
                        btnLeerChip.Enabled = true;
                        cmbPuerto.Enabled = true;
                    }
                    else
                    {
                        btnLeerChip.Enabled = false;
                        cmbPuerto.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NroTanques", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtNuipPropietario_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataSet oInformacion = new DataSet();
                oInformacion.Load(OHelper.RecuperarClienteLocal("*"), LoadOption.Upsert, "Cliente");
                Controles.frmAyuda oAyuda = new frmAyuda();
                oAyuda.TituloVentana = "Propietario";
                oAyuda.UbicacionFormulario = FormStartPosition.CenterParent;
                oAyuda.Informacion = oInformacion.Tables[0];
                oAyuda.ColumnReturn = 0;
                oAyuda.ShowDialog();
                if (string.IsNullOrEmpty(oAyuda.ValorRegistroSeleccionado))
                {
                    txtPropietario.Text = "";
                }
                else
                {
                    txtPropietario.Text = oAyuda.ValorRegistroSeleccionado.ToString();
                }
                oAyuda.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

                 

        private void mnuCredito__Click(object sender, EventArgs e)
        {
            Controles.frmAyuda oAyuda = new frmAyuda();
            try
            {

                oAyuda.TituloVentana = "Creditos Asociados";
                oAyuda.UbicacionFormulario = FormStartPosition.CenterParent;
                oAyuda.Informacion = OHelper.RecuperarIdCreditoLocal(oPlaca).Tables[0];
                oAyuda.ColumnReturn = 0;
                oAyuda.ShowDialog();

                if (string.IsNullOrEmpty(oAyuda.ValorRegistroSeleccionado) == false)
                {

                    if (!string.IsNullOrEmpty(txtNuip.Text.Trim()))
                    {
                        FrmCreditoPorVehiculo frm = new FrmCreditoPorVehiculo();
                        frm.Dni = txtNuip.Text;
                        frm.IdCredito = oAyuda.ValorRegistroSeleccionado.ToString();
                        frm.ShowDialog();
                    }             
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                oAyuda.Dispose();
            }
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
        //        if (Dispositivo != null)
        //        {
        //            this.Dispositivo.CerrarPuerto();
        //          //  this.Dispositivo.Dispose();
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
           

        //}

        //delegate void setText(string text);

        //private void ColocarIdentificadorEnTextBox(string identificador)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(identificador))
        //        {
        //            if (this.txtIdentificador.InvokeRequired)
        //            {
        //                setText d = new setText(ColocarIdentificadorEnTextBox);
        //                this.Invoke(d, new object[] { identificador });
        //            }
        //            else
        //            {
        //                this.txtIdentificador.Text = identificador;

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

      


        public void MostrarError(string mensaje, int delay, bool eserror)
        {
            try
            {

                POSstation.Notificacion.Notification Control = new POSstation.Notificacion.Notification();
                Control.Mensaje = mensaje;
                Control.EsError = eserror;
                Control.TimerTiempo = delay;
                Control.Show();
            }
            catch (Exception)
            {


            }


        }

        //private void cmbPuerto_SelectedIndexChanged_1(object sender, EventArgs e)
        //{
        //    txtIdentificador.Text = "";
        //    IniciarDispositivolsib4();
        //}

        private void btnLeerChip_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPuerto.SelectedIndex != -1)
                {
                    String puerto = cmbPuerto.SelectedItem.ToString();
                    ctrlOcxChip.Puerto = puerto.Substring(puerto.IndexOf("M") + 1);
                    txtIdentificador.Text = ctrlOcxChip.LeerRom();
                    txtIdentificador.Text = ctrlOcxChip.ROM;
                }
            }
            catch (Exception)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nNo se pudo leer el chip. Revise la configuración";
                Popup.Popup();
            }
        }

        private void mnuplaca_Click(object sender, EventArgs e)
        {
            IdentificadorPlaca oIdentPlaca = new IdentificadorPlaca();

            oIdentPlaca.ShowDialog();


        }

        private void txtPlaca_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtModelo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCausalBloqueo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPuerto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtIdentificador_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNuip_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNroTanques_TextChanged(object sender, EventArgs e)
        {

        }

  

    }
    public delegate void WorkerEndHandler(object o, EventVehiculo e);

    public class EventVehiculo : EventArgs
    {

        public readonly string TheString;

        public EventVehiculo(string s)
        {
            TheString = s;
        }
    }
}
