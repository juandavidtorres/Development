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
using POSstation;
using POSstation.Fabrica;

namespace gasolutions.UInterface
{
    public partial class Vehiculo : Form
    {
        
        Helper OHelper = new Helper();
        Int32 IdCliente;
        Dictionary<string, InformacionDispositivoLSIB4> ColDispositivosLSIB4 = new Dictionary<string, InformacionDispositivoLSIB4>();
        Dictionary<string, BytesLectura> LecturasLSIB4 = new Dictionary<string, BytesLectura>();
        List<LSIB4Reader> listaDispositivos = null;
        EstacionException LogFallas = new EstacionException();
        PropiedadesExtendidas LogPropiedades = new PropiedadesExtendidas();
        CategoriasLog LogCategorias = new CategoriasLog();
        Dictionary<string, string> RomEstacion = new Dictionary<string, string>();
        byte Cara = 0;

        public Vehiculo()
        {
            InitializeComponent();
        }

        public Int32 Cliente
        {
            set 
            {
                IdCliente = value;
            }
        }

        private void Vehiculo_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            IniciarForma();
            this.Cursor = Cursors.Default;          
        }

        private void IniciarForma()
        {
            txtPlaca.Tag = "";
            CargarTiposVehiculo();
            CargarFormasPago();
            CargarMotivosBloqueo();
            CargarFinancieras();
            CargarPuertosPC();
            IniciarDispositivosLSIB4();
            RecuperarConfiguracionCara();
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

        private void CargarFinancieras()
        {
            try
            {
                cmbFinanciera.DisplayMember = "Nombre";
                cmbFinanciera.ValueMember = "IdFinanciera";
                cmbFinanciera.DataSource = OHelper.RecuperarFinancieras().Tables[0];
            }
            catch
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nNo se pudieron cargar las financieras";
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

        private void CargarFormasPago()
        {
            try
            {
                cmbFormaPago.DisplayMember = "Descripcion";
                cmbFormaPago.ValueMember = "IdFormaPago";
                cmbFormaPago.DataSource = OHelper.RecuperarFormasPago().Tables[0];
            }
            catch
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nNo se pudieron cargar las formas de pago";
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

        private void FormatoFormularioInicial()
        {
            txtPlaca.Tag = "";
            txtModelo.Text = "";
            txtPlaca.Text = "";
            cmbTipoVehiculo.SelectedIndex = -1;
            cmbFormaPago.SelectedIndex = -1;
            cmbCausalBloqueo.SelectedIndex = -1;
            cmbFinanciera.SelectedIndex = -1;
            txtPorcentajeCredito.Text = "";
            txtNuip.Text = "";
            txtRom.Text = "";
            chkControlKm.Checked = false;
            HabilitarControles(true);
            txtPlaca.Focus();
        }

        private void LimpiarFormularioSecundario()
        {
            txtPlaca.Tag = "";
            txtModelo.Text = "";
            cmbTipoVehiculo.SelectedIndex = -1;
            cmbFormaPago.SelectedIndex = -1;
            cmbCausalBloqueo.SelectedIndex = -1;
            cmbFinanciera.SelectedIndex = -1;
            txtPorcentajeCredito.Text = "";
            txtNuip.Text = "";
            txtRom.Text = "";
            chkControlKm.Checked = false;
            txtModelo.Focus();
        }

        private void HabilitarControles(Boolean Valor)
        {
            this.mnuGuardar.Enabled = Valor;
        }

       
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
                if (txtModelo.Text.Trim().Length > 0 && txtPlaca.Text.Trim().Length > 0 && txtNuip.Text.Trim().Length > 0 && txtPorcentajeCredito.Text.Trim().Length > 0 && cmbFinanciera.SelectedIndex != -1 && cmbFormaPago.SelectedIndex != -1 && cmbCausalBloqueo.SelectedIndex != -1)
                {
                    if (OHelper.ExisteVehiculoLocal(txtPlaca.Text.Trim()))
                    {
                        OHelper.ActualizarVehiculo(txtPlaca.Text.Trim(), txtModelo.Text.Trim(), Int16.Parse(cmbTipoVehiculo.Text), Int16.Parse(cmbCausalBloqueo.SelectedValue.ToString()), txtNuip.Text.Trim(), 0, txtRom.Text.Trim(), chkControlKm.Checked);
                    }
                    else
                    {
                        OHelper.InsertarVehiculo(txtPlaca.Text.Trim(), txtModelo.Text.Trim(), Int16.Parse(cmbTipoVehiculo.Text), Int16.Parse(cmbCausalBloqueo.SelectedValue.ToString()), txtNuip.Text.Trim(), 0, txtRom.Text.Trim(), chkControlKm.Checked);
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

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
            this.Dispose();
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
                    Popup.ContentText = "\t\t\tData Administrator\n\nSe recuperaron los datos del vehiculo del CDC";
                    Popup.Popup();
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
                    txtPorcentajeCredito.Text = Vehiculo.GetDecimal(Vehiculo.GetOrdinal("PorcentajeCredito")).ToString();
                    cmbFormaPago.SelectedValue = Vehiculo.GetInt16(Vehiculo.GetOrdinal("IdFormaPago"));
                    cmbFinanciera.SelectedValue = Vehiculo.GetInt32(Vehiculo.GetOrdinal("IdFinanciera"));
                    cmbCausalBloqueo.SelectedValue = Vehiculo.GetInt16(Vehiculo.GetOrdinal("IdCausalBloqueo"));
                    txtNuip.Text = Vehiculo.GetString(Vehiculo.GetOrdinal("NuipCliente"));
                    txtRom.Text = Vehiculo.GetString(Vehiculo.GetOrdinal("ROM"));
                    estado = Vehiculo.GetInt32(Vehiculo.GetOrdinal("ControlKm"));
                    if (estado == 0)
                    {
                        chkControlKm.Checked = false;
                    }
                    else
                    {
                        chkControlKm.Checked = true;
                    }

                    txtModelo.Focus();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Vehiculo.Close();
            }
        }

        private void txtPlaca_Leave(object sender, EventArgs e)
        {
            if (txtPlaca.Text != txtPlaca.Tag.ToString())
            {
                txtPlaca.Tag = txtPlaca.Text;
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

      
        private void OEventos_EnviarBytesLecturaChipPorDti(System.Array Lectura, string Puerto, int IdDispositivoDti)
        {
            try
            {

                byte[] paginas = new byte[147];
                int i = 0;
                byte[] cabeceratrama = new byte[19];
                string trama = null;
                System.Text.UTF8Encoding convercion = new System.Text.UTF8Encoding();
                string[] Temporal = null;
                string puertodti = "";
                string identificador = null;

                Helper oHelper = new Helper();
                string CadenaAuxiliar = "";
                int j = 0;


                //'Datos de la lectura del chip
                if (Lectura.Length >= 147)
                {

                    for (i = 0; i <= 18; i++)
                    {
                        cabeceratrama[i] = (byte)Lectura.GetValue(i);
                    }


                    for (i = 0; i <= Lectura.Length - 1; i++)
                    {
                        paginas[j] = (byte)Lectura.GetValue(i);
                        j = j + 1;
                    }

                    //Saco la cabecera de la trama que corresponde al puerto de la dti y el rom
                    trama = convercion.GetString(cabeceratrama);

                    if (!string.IsNullOrEmpty(trama))
                    {
                        Temporal = trama.Split(('.'));
                        puertodti = Temporal[0];
                        identificador = Temporal[1];
                    }

                    if (paginas.Length >= 128)
                    {

                        try
                        {
                            Cara = oHelper.RecuperarCaraPorDispositivo(IdDispositivoDti, puertodti);
                            BytesLectura Bytes = new BytesLectura();
                            Bytes.ArregloBytes = paginas;


                            if (LecturasLSIB4.ContainsKey(Cara.ToString()))
                            {
                                LecturasLSIB4.Remove(Cara.ToString());
                            }
                            else
                            {
                                LecturasLSIB4.Add(Cara.ToString(), Bytes);
                            }


                        }
                        catch (System.Exception ex)
                        {
                            LogCategorias.Clear();
                            LogCategorias.Agregar("SeguimientoCodigoDTI");
                            LogPropiedades.Clear();
                            LogPropiedades.Agregar("Mensaje", ex.Message);
                            POSstation.Fabrica.LogIt.Loguear("Error recuperando ROM chip ExtraerInformacionPaginas", LogPropiedades, LogCategorias);
                            throw ex;
                        }
                    }
                }
                else
                {
                    //Aqui saco la informacion del Puerto y el donde se deconecto el chip
                    for (i = 0; i <= 4; i++)
                    {
                        cabeceratrama[i] = (byte)Lectura.GetValue(i);
                    }

                    System.Text.UTF8Encoding datos = new System.Text.UTF8Encoding();
                    //convierto a string los primeros 19 byets para sacar el rom y el puerto
                    CadenaAuxiliar = datos.GetString(cabeceratrama);


                    LogCategorias.Clear();
                    LogCategorias.Agregar("SeguimientoCodigoDTI");
                    LogPropiedades.Clear();
                    LogPropiedades.Agregar("Puerto Recibido", puertodti);
                    POSstation.Fabrica.LogIt.Loguear("Logueando la separacion de la trama cuando se desconecta el chip", LogPropiedades, LogCategorias);

                    if (!string.IsNullOrEmpty(CadenaAuxiliar))
                    {
                        string[] cadenaTemporal = null;

                        //Hago un split para separa la trama, por ejemplo me llega I2.NC, hago el slit para sacar el puerto y la trama
                        cadenaTemporal = CadenaAuxiliar.Split('.');

                        //Almaceno el puerto

                        puertodti = cadenaTemporal[0];
                        //Aqui le informo al autorizador que se desconecto el chip de la DTI

                        Cara = oHelper.RecuperarCaraPorDispositivo(IdDispositivoDti, puertodti);
                        // OEventosInformarCaraSinChipDti(Cara, puertodti, Puerto);
                    }
                    else
                    {
                        throw new System.Exception("Falla en extraer Puerto en la trama de desconexion de chip LSIB4");
                    }
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        private InformacionVehiculo EsperarDatosChipLectorDtiImpresionTicket(string ocara, bool EsLecturaObligatoria = true)
        {
            Helper oDatos = new Helper();
            int intentos = Convert.ToInt32(oDatos.RecuperarParametro("LecturaChipReintentos"));
            Int32 Delay = Convert.ToInt32(oDatos.RecuperarParametro("LecturaChipDelay"));
            InformacionVehiculo OPlaca = new InformacionVehiculo();
            POSstation.EncriptacionDti.EncriptacionDti oNorma = new POSstation.EncriptacionDti.EncriptacionDti();
            int i = 0;
            try
            {
                while (i <= intentos)
                {
                    if (LecturasLSIB4.ContainsKey(ocara))
                    {
                        //OPlaca = oNorma.ExtraerInformacionPaginasImpresiones(LecturasLSIB4(ocara).ArregloBytes)
                        OPlaca = DesencriptarBytesDti(EsLecturaObligatoria, Convert.ToByte(ocara), LecturasLSIB4[ocara].ArregloBytes);
                        LecturasLSIB4.Remove(ocara);

                        if (OPlaca == null)
                        {
                            throw new System.Exception("Retire y coloque nuevamente el chip en el lector");
                        }

                        break; // TODO: might not be correct. Was : Exit While
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(Convert.ToInt32(Delay / 3));
                    }

                    if (i >= intentos)
                    {
                        throw new System.Exception("No hay un chip conectado");
                    }

                }
                return OPlaca;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public InformacionVehiculo DesencriptarBytesDti(bool EsLecturaChipObligatoria, byte cara, byte[] Paginas)
        {
            InformacionVehiculo oInformacion = new InformacionVehiculo();
            try
            {
                try
                {
                    System.Text.UTF8Encoding convercion = new System.Text.UTF8Encoding();
                    string strSalida = null;
                    string identificador = "";
                    string PuertoDti = null;

                    if (Paginas.Length > 0)
                    {
                        try
                        {
                            POSstation.EncriptacionDti.EncriptacionDti oEncripcion = new POSstation.EncriptacionDti.EncriptacionDti();

                            if (EsLecturaChipObligatoria)
                            {
                                byte[] ContenidoChip = new byte[128];
                                int j = 0;
                                int i = 0;
                                j = 0;
                                for (i = 19; i <= Paginas.Length - 1; i++)
                                {
                                    ContenidoChip[j] = Paginas[i];
                                    j = j + 1;
                                }

                                dynamic Temporal = new byte[19];

                                System.Text.UTF8Encoding datos = new System.Text.UTF8Encoding();

                                i = 0;
                                for (i = 0; i <= 18; i++)
                                {
                                    Temporal[i] = Paginas[i];
                                }

                                //convierto a string los primeros 19 byets para sacar el rom y el puerto
                                strSalida = datos.GetString(Temporal);
                                if (!string.IsNullOrEmpty(strSalida))
                                {
                                    string[] Tmp = strSalida.Split('.');
                                    PuertoDti = Tmp[0];
                                    identificador = Tmp[1];
                                }

                                LogCategorias.Clear();
                                LogCategorias.Agregar("SeguimientoCodigoDTI");
                                LogPropiedades.Clear();
                                LogPropiedades.Agregar("Mensaje", "Se saca el Rom de la cabacera del LSIB4");
                                LogPropiedades.Agregar("Rom", identificador);
                                POSstation.Fabrica.LogIt.Loguear("DesencriptarDTI", LogPropiedades, LogCategorias);

                                oInformacion = oEncripcion.ExtraerInformacionPaginas(ContenidoChip, identificador, EsLecturaChipObligatoria);
                            }
                            else
                            {
                                dynamic Temporal = new byte[19];
                                System.Text.UTF8Encoding datos = new System.Text.UTF8Encoding();

                                for (int i = 0; i <= 18; i++)
                                {
                                    Temporal[i] = Paginas[i];
                                }

                                //convierto a string los primeros 19 byets para sacar el rom y el puerto
                                strSalida = datos.GetString(Temporal);
                                if (!string.IsNullOrEmpty(strSalida))
                                {
                                    string[] Tmp = strSalida.Split('.');
                                    PuertoDti = Tmp[0];
                                    identificador = Tmp[1];
                                }
                                oInformacion = oEncripcion.ExtraerInformacionPaginas(Paginas, identificador, EsLecturaChipObligatoria);
                            }

                        }
                        catch (System.Exception ex)
                        {
                            LogCategorias.Clear();
                            LogCategorias.Agregar("SeguimientoCodigoDTI");
                            LogPropiedades.Clear();
                            LogPropiedades.Agregar("Mensaje", ex.Message);
                            POSstation.Fabrica.LogIt.Loguear("Error recuperando ROM chip ExtraerInformacionPaginas", LogPropiedades, LogCategorias);
                            throw ex;
                        }

                    }

                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return oInformacion;
        }

        private void RecuperarConfiguracionCara()
        {
            try
            {
                Helper OHelper = new Helper();
                IDataReader Lector = null;
                Lector = OHelper.RecuperarConfiguracionCara();
                InformacionDispositivoLSIB4 oDatos = default(InformacionDispositivoLSIB4);
                string oCara = null;

                while (Lector.Read())
                {
                    oDatos = new InformacionDispositivoLSIB4();
                    oCara = Convert.ToString(Lector["IdCara"].ToString());
                    oDatos.IdDti = Convert.ToInt32(Lector["IdDti"].ToString());
                    oDatos.Puerto = Convert.ToString(Lector["Puerto"].ToString());
                    oDatos.IdPuerto = Convert.ToInt32(Lector["IdPuertoDti"].ToString());
                    if (!ColDispositivosLSIB4.ContainsKey(oCara))
                    {
                        ColDispositivosLSIB4.Add(oCara, oDatos);
                    }
                }
                Lector.Close();
                Lector = null;
            }
            catch (System.Data.DataException EXBD)
            {
                LogFallas.ReportarError(EXBD, "RecuperarConfiguracionCara", "", "Autorizador");
            }
            catch (System.Data.SqlClient.SqlException EXSQL)
            {
                LogFallas.ReportarError(EXSQL, "RecuperarConfiguracionCara", "", "Autorizador");
            }
            catch (System.Exception EXCapturadores)
            {
                LogFallas.ReportarError(EXCapturadores, "RecuperarConfiguracionCara", "", "Autorizador");
            }
        }

        private void IniciarDispositivosLSIB4()
        {
            try
            {

                Helper OHelper = new Helper();
                IDataReader DrDispositivos;
                LSIB4Reader Dispositivo = new LSIB4Reader();
                listaDispositivos = new List<LSIB4Reader>();
                DrDispositivos = OHelper.RecuperarDispositivosDti();

                while (DrDispositivos.Read())
                {
                    Dispositivo = new LSIB4Reader();
                    Dispositivo.ReaderHostMain(DrDispositivos["Puerto"].ToString(), Convert.ToInt32(DrDispositivos["IdLectorDti"].ToString()));
                    Dispositivo.EnviarBytesLecturaChipPorDti += OEventos_EnviarBytesLecturaChipPorDti;
                    this.listaDispositivos.Add(Dispositivo);
                }
                DrDispositivos.Close();
                DrDispositivos.Dispose();
            }
            catch (System.Data.DataException EXBD)
            {
                LogFallas.ReportarError(EXBD, "IniciarDispositivosDti", "", "Autorizador");
            }
            catch (System.Data.SqlClient.SqlException EXSQL)
            {
                LogFallas.ReportarError(EXSQL, "IniciarDispositivosDti", "", "Autorizador");
            }
            catch (System.Exception EXCapturadores)
            {

                LogFallas.ReportarError(EXCapturadores, "IniciarDispositivosDti", "", "Autorizador");
            }
        }

        private void btnLeerChip_Click(object sender, EventArgs e)
        {
            try
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("Ibutton");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Cara", Cara.ToString());
                POSstation.Fabrica.LogIt.Loguear("Se solicita la lectura del ibutton", LogPropiedades, LogCategorias);


                Helper OHelper = new Helper();

                if (ColDispositivosLSIB4.ContainsKey(Cara.ToString()))
                {
                    InformacionVehiculo OPlaca = new InformacionVehiculo();
                    OPlaca = EsperarDatosChipLectorDtiImpresionTicket(Cara.ToString());



                    if (!String.IsNullOrEmpty(OPlaca.Rom))
                    {
                        txtRom.Text = OPlaca.Rom;
                        ColDispositivosLSIB4.Remove(Cara.ToString());

                    }
                    else
                    {
                        Popup.ContentText = "No se pudo leer el Chip, intente nuevamente";
                        Popup.Popup();
                    }
                }
                else
                {
                    Popup.ContentText = "No se ha detectado un lector Chip Conectado, por favor verifique";
                    Popup.Popup();
                }

            }
            catch (System.Data.DataException EXBD)
            {
                LogFallas.ReportarError(EXBD, "oEventos_SolicitudDatosIbutton", "Cara: " + Cara.ToString(), " Puerto: Ibutton");
                // ImpresoraTurno.ImprimirExcepcion(EXBD.Message, ImpresoraEstacion.CrearImpresora(cara))
            }
            catch (System.Data.SqlClient.SqlException EXSQL)
            {
                LogFallas.ReportarError(EXSQL, "oEventos_SolicitudDatosIbutton", "Cara: " + Cara.ToString(), " Puerto: Ibutton");
            }
            catch (System.Exception ex)
            {
                LogFallas.ReportarError(ex, "oEventos_SolicitudDatosIbutton", "Cara: " + Cara.ToString(), " Puerto: Ibutton");
            }


        }
    }
}