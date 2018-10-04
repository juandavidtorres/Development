using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using POSstation.AccesoDatos;
using POSstation.FabricaCanastilla;
using POSstation.Fabrica;
using POSstation.Protocolos;

namespace POSstation
{
    public class DTI : iTerminal
    {
        #region "Eventos"

        public event iTerminal.AutorizarVentaChequeEventHandler AutorizarVentaCheque;

        public event iTerminal.GuardarPlacaEventHandler GuardarPlaca;

        public event iTerminal.AnularDocumentoEventHandler AnularDocumento;

        public event iTerminal.AperturaTurnoEventHandler AperturaTurno;

        public event iTerminal.AutorizarVentaManualCreditoEventHandler AutorizarVentaManualCredito;

        public event iTerminal.CierreImpresoraPorPuertoEventHandler CierreImpresoraPorPuerto;

        public event iTerminal.CierreTurnoEventHandler CierreTurno;

        public event iTerminal.CierreTurnoTrabajoEventHandler CierreTurnoTrabajo;

        public event iTerminal.ConsultarSaldoTarjetaFidelizacionEventHandler ConsultarSaldoTarjetaFidelizacion;

        public event iTerminal.DescuentoClienteRucEventHandler DescuentoClienteRuc;

        public event iTerminal.EnviarAlturasCierreDeTanquesEventHandler EnviarAlturasCierreDeTanques;

        public event iTerminal.EnviarCambioChequeEventHandler EnviarCambioCheque;

        public event iTerminal.EnviarDatosChipMrEventHandler EnviarDatosChipMr;

        public event iTerminal.EnviarRemarcacionCombustibleEventHandler EnviarRemarcacionCombustible;

        public event iTerminal.EnvioCalibracionCombustibleEventHandler EnvioCalibracionCombustible;

        public event iTerminal.EnvioVentaConsumoCombustibleEventHandler EnvioVentaConsumoCombustible;

        public event iTerminal.ExcepcionOcurridaEventHandler ExcepcionOcurrida;

        public event iTerminal.FidelizarUltimaVentaEventHandler FidelizarUltimaVenta;

        public event iTerminal.FidelizarVentaEventHandler FidelizarVenta;

        public event iTerminal.GuardarKilometrajeEventHandler GuardarKilometraje;

        public event iTerminal.ImprimirAjusteTanquesEventHandler ImprimirAjusteTanques;

        public event iTerminal.ImprimirArqueoEventHandler ImprimirArqueo;

        public event iTerminal.ImprimirArqueoImpresoraEventHandler ImprimirArqueoImpresora;

        public event iTerminal.ImprimirDocumentoReciboCombustibleEventHandler ImprimirDocumentoReciboCombustible;

        public event iTerminal.ImprimirFacturaCanastillaUnicaEventHandler ImprimirFacturaCanastillaUnica;

        public event iTerminal.ImprimirReciboBypassEventHandler ImprimirReciboBypass;

        public event iTerminal.ImprimirResumenDiarioEventHandler ImprimirResumenDiario;

        public event iTerminal.InformarCierreConsignacionesEventHandler InformarCierreConsignaciones;

        public event iTerminal.InformarStocksTanquesCierreTurnoServicioEventHandler InformarStocksTanquesCierreTurnoServicio;

        public event iTerminal.PredeterminarPagoVentaEventHandler PredeterminarPagoVenta;

        public event iTerminal.PrepararTipoDocumentoEventHandler PrepararTipoDocumento;

        public event iTerminal.PresetEventHandler Preset;

        public event iTerminal.ReImprimirVentaCreditoPorCaraEventHandler ReImprimirVentaCreditoPorCara;

        public event iTerminal.ReImprimirVentaCreditoPorConsecutivoEventHandler ReImprimirVentaCreditoPorConsecutivo;

        public event iTerminal.RedencionBonosFidelizacionEventHandler RedencionBonosFidelizacion;

        public event iTerminal.ReimprimirDocumentoPorCaraEventHandler ReimprimirDocumentoPorCara;

        public event iTerminal.ReimprimirDocumentoPorNumeroEventHandler ReimprimirDocumentoPorNumero;

        public event iTerminal.ReimprimirTurnoPorEmpleadoEventHandler ReimprimirTurnoPorEmpleado;

        public event iTerminal.ReimprimirTurnoPorSurtidorEventHandler ReimprimirTurnoPorSurtidor;

        public event iTerminal.SolicitudDatosIbuttonEventHandler SolicitudDatosIbutton;

        public event iTerminal.VentaCreditoEstacionEventHandler VentaCreditoEstacion;
        public event iTerminal.PagoEnEfectivoEventHandler PagoEnEfectivo;
        public event iTerminal.ImprimirVentaCanastillaTerpelEventHandler ImprimirVentaCanastillaTerpel;
        public event iTerminal.VentaCreditoCanastillaEventHandler VentaCreditoCanastilla;
        public event iTerminal.AnularFacturaCanastillaEventHandler AnularFacturaCanastilla;
        public event iTerminal.RegistrarPlacaEventHandler RegistrarPlaca;
        #endregion


        #region VARIABLES
        SerialPort PuertoTerminal;
        string Puerto;

        //Vector de string que almacenara que tendrá como elementos cada uno de los campos de la trama
        string[] TramaCampos = new string[1];
        char[] TramaRx = new char[1];
        string stringTramaRx;
        string Tiquete;
        bool EsContado;
        int IdEmpresa = 0;
        ReciboDeCombustible OReciboCombustible;
        string Cara;
        List<string> lstTanques = new List<string>();
        ColConsignacion oColConsignacion;
        #endregion
        double sobresFijo = 0;
        double sobresVariable = 0;
        #region VARIABLES QUE DEBEN SER BORRADAS
        

        POSstation.Fabrica.PropiedadesExtendidas LogPropiedades = new POSstation.Fabrica.PropiedadesExtendidas();
        CategoriasLog LogCategorias = new CategoriasLog();

        ColTanques alturasTanques = new ColTanques();

        string valorCambio = string.Empty;
        string ValorCheque = string.Empty;
        string ReciboCambioCheque = string.Empty;
        string CodigocambioCheque = string.Empty;
        string CodigoTanqueAjuste = string.Empty;

        string IdEmpleado;
        string Password;
        List<string> Parrafo = new List<string>();
        private string Empleado;
        private string clave;
        private string Tarjeta;
        private Helper oHelper = new Helper();
        string TanqueRem = "";
        string Tanque;
        Factura oFactura;
        short idTipoTurno = 0;

        Nullable<Int32> IdTurno = null;
        private string ValeCredito;
        private string NumeroOrden;
        CupoPrepago oCupoPrepago;
        long IdDocumento = 0;
        private long Consecutivo;
        decimal ValorVentaCanastilla = 0;
        #endregion

        public DTI(string strPuerto)
        {
            PuertoTerminal = new SerialPort();
            PuertoTerminal.DataReceived += new SerialDataReceivedEventHandler(PuertoTerminal_DataReceived);

            //CONFIGURACION DEL PUERTO DE LA TERMINAL REMOTA
            Puerto = strPuerto;
            PuertoTerminal.PortName = Puerto;
            PuertoTerminal.BaudRate = 38400;
            PuertoTerminal.DataBits = 8;
            PuertoTerminal.StopBits = StopBits.One;
            PuertoTerminal.Parity = Parity.None;
            PuertoTerminal.DtrEnable = false;
            PuertoTerminal.RtsEnable = false;
            PuertoTerminal.ReadBufferSize = 5096;
            PuertoTerminal.WriteBufferSize = 5096;
            try
            {
                PuertoTerminal.Open();
            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion Iniciando TerminalDTI", LogPropiedades, LogCategorias);
            }



        }

        private void PuertoTerminal_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int CantidadPaquetes = 0;
            int Longitud;
            stringTramaRx = "";
            System.Threading.Thread.Sleep(300);
            while (!stringTramaRx.EndsWith("|") && CantidadPaquetes <= 5)
            {
                System.Threading.Thread.Sleep(100);
                Longitud = PuertoTerminal.BytesToRead;
                TramaRx = new char[Longitud];
                PuertoTerminal.Read(TramaRx, 0, Longitud);
                PuertoTerminal.DiscardInBuffer();
                stringTramaRx += new string(TramaRx);
                CantidadPaquetes += 1;
            }

            if (stringTramaRx.EndsWith("|"))
                PuertoTerminal.Write(AnalizarPeticion());
            else
                PuertoTerminal.Write("M1*Fallo de Comunicacion|");

            PuertoTerminal.DiscardInBuffer();
            PuertoTerminal.DiscardOutBuffer();
        }

        private string AnalizarPeticion()
        {
            //Almacena en el string sTramaRx el Vector trama recibida
            //string stringTramaRx = new string(TramaRx);
            string TramaRx = "";

            TramaCampos = stringTramaRx.Substring(0, stringTramaRx.Length - 1).Split('*', '|');

            switch (TramaCampos[0])
            {
                case "GP":
                    //TramaRx = ValidarTarjeta();
                    TramaRx = "M1*Funcion No disponible|";
                    break;
                case "CA":      //Valida las credenciales del Administrador
                    TramaRx = ValidarCredencialesAdministrador("CA");
                    break;

                case "VR":
                    TramaRx = RecuperarValorPorRecibo(TramaCampos[0]);
                    break;

                case "VC ":
                    TramaRx = RecuperarValorPorRecibo(TramaCampos[0]);
                    break;

                case "O5":      //Valida las credenciales del Administrador
                    TramaRx = ValidarCredencialesAdministrador("O5");
                    break;
                case "O8":      //Remarcacion combustible
                    TramaRx = ValidarProductosCombustibleFullPeru();
                    break;
                case "O6":      //Valida las credenciales del Administrador
                    TramaRx = ObtenerCombustible(true, TramaCampos[1]);
                    Tanque = TramaCampos[1];
                    break;
                case "O7":      //Valida las credenciales del Administrador
                    TramaRx = ObtenerCombustible(true, TramaCampos[1]);
                    TanqueRem = TramaCampos[1];
                    break;
                case "O10":
                    TramaRx = CambioTanqueBypass();//Cambio Bypass
                    break;
                case "CN":      //Valida las credenciales del Administrador
                    TramaRx = ValidarIslero("CN");
                    break;
                case "O9":      //Valida las credenciales del Administrador
                    TramaRx = ValidarIslero("O9");
                    break;
                case "CD":      //Valida las credenciales del Despachador
                    TramaRx = ValidarCredencialesDespachador();
                    break;
                case "02":
                    TramaRx = InsertarDetalleReciboCombustible();
                    break;
                case "CP":
                    TramaRx = ObtenerProducto();
                    break;

                case "FC":
                    TramaRx = ObtenerFranquiciaTarjetaCredito();
                    break;

                case "FD":
                    TramaRx = ObtenerFranquiciaTarjetaDebito();
                    break;

                case "V1":
                    TramaRx = EmisionDocumentoCombustible();
                    break;

                case "V2":
                    TramaRx = ProcesoCanastilla();
                    break;

                case "V3":
                    TramaRx = CopiaVentas();
                    break;

                case "V4":
                    TramaRx = ModificarVenta();
                    break;

                case "TT"://Listo
                    TramaRx = TipoTiquete();
                    break;

                case "VT":
                    TramaRx = ValidaExistenciaTiquete();
                    break;

                case "T0":    //Listo  
                    //Valida credenciales y surtidores disponibles para apertura
                    TramaRx = SurtidoresDisponiblesApertura();
                    break;

                case "T1":      //Listo
                    //Proceso Apertura de Turno
                    TramaRx = AbrirTurno();
                    break;

                case "T2":   //Listo   
                    //Valida Credenciales y cierra Turno
                    if (Convert.ToInt16(TramaCampos[3]) == 1)
                        TramaRx = SurtidorDisponibleCierre();
                    else
                        TramaRx = CerrarTurnoTotal();
                    break;

                case "T3":
                    TramaRx = CerrarTurno();
                    break;

                case "T4":      //Cierre de Tanques con Veeder Root
                    TramaRx = CerrarTanquesVeederRoot();
                    break;

                case "T5":      //Valida Credenciales para Cierre de Tanques Manual
                    TramaRx = ObtenerTanques();
                    break;

                case "T6":      //Cierre de Tanques Manual
                    TramaRx = CerrarTanquesManual();
                    break;

                case "T7":
                    TramaRx = ObtenerFaltantesSobrantes();
                    break;

                case "T8":      //Obtener Valor de Sobre Fijo
                    TramaRx = ObtenerValorSobreFijo();
                    break;

                case "T9":      //Consignar Sobre Fijo
                    TramaRx = ConsignarSobreFijo();
                    break;

                case "TA":      //Consigna Sobre Variable
                    TramaRx = ConsignarSobreVariable();
                    break;

                case "TB":      //Cierra proceso de sobres
                    TramaRx = CerrarSobres();
                    break;

                case "TC":    //Listo
                    //Copia de Cierre por Surtidor y Fecha
                    TramaRx = CopiaCierreTurnoSurtidor();
                    break;

                case "TD":   //Listo
                    //Copia de Cierre Por Empleado y Fecha
                    TramaRx = CopiaCierreTurnoEmpleado();
                    break;

                case "TE":    //Listo 
                    //Reporte de Auditoria
                    TramaRx = Auditoria();
                    break;

                case "TF":   //Listo
                    //Resumen Diario
                    TramaRx = ResumenDia();
                    break;

                case "TX": //Listo
                    TramaRx = ReporteX();
                    break;

                case "TZ": //Listo
                    TramaRx = ReporteZ();
                    break;

                case "A1": //Queda pendiente que se corriga el problema para indicar si es ultima o siguiente venta
                    TramaRx = AlmacenarPlaca();
                    break;

                case "A2":
                    TramaRx = AlmacenarKilometraje();
                    break;

                case "A3"://Listo
                    TramaRx = ProgramarVenta();
                    break;

                case "A4":
                    TramaRx = ObtenerDatosChip();
                    break;

                case "A7":
                    //Descuento por RUC
                    //trama = ImpresionDatosChip();
                    TramaRx = DescuentoPorRuc();
                    break;

                case "A5":
                    TramaRx = ObtenerValorCheque();
                    break;

                case "A6":
                    TramaRx = AlmacenarDineroDevolver();
                    break;

                case "F1"://Listo
                    TramaRx = FidelizarVentaF();
                    break;

                case "F2"://Listo
                    TramaRx = SaldoTarjeta();
                    break;

                case "F3"://Listo
                    TramaRx = PagoConBono();
                    break;

                case "O1":
                    TramaRx = ConsumoInterno();
                    break;

                case "RP":
                    TramaRx = ObtenerCombustible(false, "");
                    break;

                case "RT":
                    TramaRx = ObtenerTanque();
                    break;

                case "O2":
                    TramaRx = RecibirCombustible();
                    break;

                case "O3":
                    TramaRx = AjusteTanqueInventario();
                    break;

                case "O4":
                    TramaRx = Calibrar();
                    break;
                case "V5"://Listo
                    TramaRx = VentaCheque();
                    break;
                case ("T10"):
                    TramaRx = EnviarConsignaciones(false, false);
                    break;
                case ("T11"):
                    TramaRx = EnviarConsignaciones(false, false);
                    break;
                #region PGN
                case "A8":
                    TramaRx = ImpresionDatosChip();
                    break;




                #endregion;
                default:
                    TramaRx = "M1*Comando No Valido|";
                    break;
            }

            return TramaRx;
        }



        private string AjusteTanqueInventario()
        {
            string trama = string.Empty;
            try
            {

                short Producto = Convert.ToInt16(TramaCampos[1]);
                string Cantidad = TramaCampos[3];
                string tipo = TramaCampos[4];
                string Tanque = TramaCampos[2];
                int TipoOper;
                decimal Saldo = 0;
                decimal Entero = 0;
                decimal Fraccion = 0;
                string[] Vector;
                double Numero;
                bool TipoAjuste = false;
                decimal Valor;
                char[] r = { '.' };

                Vector = new string[2];

                if (Cantidad.IndexOf(".") > 0)
                {
                    Vector = Cantidad.Split(r);

                    Entero = Convert.ToDecimal(Vector[0]);
                    Fraccion = Convert.ToDecimal(Vector[1]);

                    Numero = System.Math.Pow(10.0, Convert.ToDouble(Convert.ToString(Fraccion).Length));

                    Fraccion = Fraccion / Convert.ToInt32(Numero);

                }
                else
                    Entero = Convert.ToDecimal(Cantidad);

                Cantidad = Convert.ToString(Entero + Fraccion);
                Valor = Convert.ToDecimal(Cantidad);



                try
                {


                    if (TramaCampos[4].Equals("1"))
                        TipoOper = 0;//Baja
                    else
                        TipoOper = 1;//Alta


                    IDataReader drValidar = oHelper.ValidarProductoEnTanqueAjustes(Tanque, Convert.ToDecimal(Cantidad), Convert.ToInt32(Producto), TipoOper);

                    if (drValidar.Read())
                    {
                        if (Convert.ToBoolean(drValidar["EsValido"]) == true)
                        {

                            Saldo = Inventario.ManagementKardex.RecuperarSaldoTanque(Tanque, Producto);

                            string CantidadTemp = Cantidad.ToString();
                            Decimal SaldoAnterior = Saldo;
                            string Productotemp = Producto.ToString();

                            if (tipo.Equals("2"))
                            {
                                TipoAjuste = true;
                                Saldo = Saldo + Convert.ToDecimal(Cantidad);
                                oHelper.InsertarAjustePorOperacion(Tanque, Saldo);
                                Saldo = Inventario.ManagementKardex.RecuperarSaldoTanque(Tanque, Producto);
                                if (ImprimirAjusteTanques != null)
                                {
                                    ImprimirAjusteTanques(Tanque, Productotemp, CantidadTemp, TipoAjuste, Puerto);
                                }
                                Saldo = Inventario.ManagementKardex.RecuperarSaldoTanque(Tanque, Producto);

                                oHelper.InsertarLogeo(IdEmpleado, Tanque, Convert.ToDecimal(CantidadTemp), SaldoAnterior, Saldo);
                            }
                            else
                            {
                                Saldo = Saldo - Convert.ToDecimal(Cantidad);

                                if (Saldo < 0)
                                {
                                    throw new Exception("La cantidad digitada debe ser menor o igual que la cantidad actual  del tanque");

                                }

                                oHelper.InsertarAjustePorOperacion(Tanque, Saldo);
                                if (ImprimirAjusteTanques != null)
                                {
                                    ImprimirAjusteTanques(Tanque, Productotemp, CantidadTemp, TipoAjuste, Puerto);
                                }

                                Saldo = Inventario.ManagementKardex.RecuperarSaldoTanque(Tanque, Producto);
                                oHelper.InsertarLogeo(IdEmpleado, Tanque, Convert.ToDecimal(CantidadTemp), SaldoAnterior, Saldo);
                            }

                            trama = "M1*Peticion en proceso|";

                        }
                        else
                        {
                            throw new Exception(drValidar["Mensaje"].ToString());
                        }
                    }

                    drValidar.Close();
                }
                catch (Exception ex)
                {
                    LogCategorias.Clear();
                    LogCategorias.Agregar("SeguimientoDTI");
                    LogPropiedades.Clear();
                    LogPropiedades.Agregar("Mensaje", ex.Message);
                    LogIt.Loguear("Excepcion en AjusteTanqueInventario", LogPropiedades, LogCategorias);
                    /********************************************************************************************************/
                    Parrafo.Clear();
                    Parrafo = Utilidades.SeccionarTexto(ex.Message);
                    trama = "M1*";
                    foreach (string linea in Parrafo)
                    {
                        trama += linea + (char)(0x0D);
                    }
                    trama += "|";
                    string mensaje = ex.Message;
                    bool imprime = true;
                    bool valor = false;
                    if (ExcepcionOcurrida != null)
                    {
                        ExcepcionOcurrida(mensaje, imprime, valor, Puerto);
                    }
                }
            }
            catch (Exception ex)
            {
                /********************************************************************************************************/
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en AjusteTanqueInventario", LogPropiedades, LogCategorias);
                /********************************************************************************************************/
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";

            }
            return trama;
        }


        private string CambioTanqueBypass()
        {
            string trama = string.Empty;
            try
            {
                string Tanque = TramaCampos[1];

                //Verificamos que exista una conexión por Bypass
                if (oHelper.ValidarCambioTanqueBypass(Tanque))
                {
                    System.Text.StringBuilder sbStr = new System.Text.StringBuilder();

                    IDataReader drValidar;

                    drValidar = oHelper.RecuperarManguerasDescolgadasPorTanque(Tanque + "|");

                    //Si trae datos los mandamos a la MR
                    if (drValidar.Read())
                    {

                        throw new Exception(sbStr.ToString());
                    }
                    else
                    {
                        trama = "Peticion en proceso|";
                        //Mandamos a cambiar mangueras y a insertar en las tablas para llevar una bitacora
                        string tanqueACambiar = POSstation.Inventario.ManagementKardex.RealizarCambioTanqueBypass(Tanque, IdEmpleado);
                        //Lanzamos el evento para la impresión
                        if (ImprimirReciboBypass != null)
                        {
                            ImprimirReciboBypass(IdEmpleado, Password, tanqueACambiar, Tanque, Puerto);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                /********************************************************************************************************/
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en CambioTanqueBypass", LogPropiedades, LogCategorias);
                /********************************************************************************************************/
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";

            }
            return trama;
        }
        private void ValidarDocumentoReciboCombustible()
        {
            string trama;
            try
            {
                //Instanciamos la clase ReciboDeCombustible
                OReciboCombustible = new ReciboDeCombustible();

                //Recibimos la Información de la MR
                string Documento = TramaCampos[2];
                string Placa = TramaCampos[4];

                //Evaluamos lo que vamos a hacer en la MR, si se va a comenzar un nuevo Recibo y terminar uno viejo             
                ConfigurarProductos(Documento, Placa);


                //Los tanques no se encuentran bloqueados
                OReciboCombustible.RealizarBloqueoTanque = false;
            }
            catch (Exception ex)
            {
                /********************************************************************************************************/
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en Validar Documento Recibo Combustible", LogPropiedades, LogCategorias);
                /********************************************************************************************************/
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";


            }
        }

        private string RecuperarProductosCombustible()
        {

            string trama = "RP";
            int i = 0;
            try
            {
                ReciboDeCombustible temporal;
                string Fila = "";

                //Creamos e Instanciamos el StringBuilder que nos servirá para crear el paquete que va para la MR
                System.Text.StringBuilder sbStr = new System.Text.StringBuilder();

                //Obtenemos la información que viene de la BD
                temporal = oHelper.RecuperarProductosCombustiblePedido("", "");

                //Seguimos armando el paquete que va para la MR
                foreach (CantidadProductos oProducto in temporal.lstProductos)
                {
                    Fila = oProducto.Nombre;

                    if (Fila.Length > 10)
                    {
                        Fila = Fila.Substring(0, 9);
                    }
                    if (i > 2)
                    {
                        i = 0;
                        sbStr.Append("*" + oProducto.CodigoProducto + ") " + "*" + Fila + " " + (char)(0x0D));
                        i++;
                    }
                    else
                        sbStr.Append("*" + oProducto.CodigoProducto + ") " + "*" + Fila + " ");

                }

                //Terminamos de armar la trama de salida
                trama += sbStr.ToString() + "|";
            }
            catch (Exception ex)
            {
                /********************************************************************************************************/
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en RecuperarProductosCoombustible", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";

            }
            return trama;
        }
        private string ConfigurarProductos(string Documento, string Placa)
        {
            string trama = "RP";
            int i = 0;
            try
            {
                Documento = TramaCampos[2];
                Placa = TramaCampos[1];
                //Creamos e Instanciamos el StringBuilder que nos servirá para crear el paquete que va para la MR
                System.Text.StringBuilder sbStr = new System.Text.StringBuilder();

                //Obtenemos la información que viene de la BD
                OReciboCombustible = oHelper.RecuperarProductosCombustiblePedido(Documento, Placa);
                string Fila = "";

                //Seguimos armando el paquete que va para la MR
                foreach (CantidadProductos oProducto in OReciboCombustible.lstProductos)
                {
                    Fila = oProducto.Nombre;

                    if (Fila.Length > 10)
                    {
                        Fila = Fila.Substring(0, 9);
                    }

                    if (i > 2)
                    {
                        i = 0;
                        sbStr.Append("*" + oProducto.CodigoProducto + ") " + "*" + Fila + " " + (char)(0x0D));
                        i++;
                    }
                    else
                        sbStr.Append("*" + oProducto.CodigoProducto + ") " + "*" + Fila + " ");
                }

                //Terminamos de armar la trama de salida
                trama += sbStr.ToString() + "|";
            }
            catch (Exception ex)
            {
                /********************************************************************************************************/
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ConfigurarProductos", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";

            }
            return trama;
        }


        #region PGN



        public string ValidarIslero(string cabecera)
        {
            string trama;
            Helper oDataAccess;
            try
            {
                oDataAccess = new Helper();
                IdEmpleado = Convert.ToString(TramaCampos[1]);
                Password = Convert.ToString(TramaCampos[2]);

                oDataAccess.ValidarCredencialesIslero(IdEmpleado, Password);
                //Para las ventas de canastilla
                oFactura = new Factura();

                IDataReader drTurno = oDataAccess.RecuperarTurnoCredencialesPorTipo(IdEmpleado, Password);
                if (drTurno.Read())
                {
                    idTipoTurno = Convert.ToInt16(drTurno["IdTipoTurno"].ToString());
                    IdTurno = Convert.ToInt32(drTurno["IdTurno"].ToString());
                }

                drTurno.Close();
                trama = cabecera + "|";


            }
            catch (Exception ex)
            {


                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ValidarIslero ", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";

                string mensaje = ex.Message;
                bool imprime = true;
                bool valor = false;
                if (ExcepcionOcurrida != null)
                {
                    ExcepcionOcurrida(mensaje, imprime, valor, Puerto);
                }
            }
            return trama;
        }







        public string ValidarCredencialesUsuario()
        {
            string trama;
            Helper oDataAccess;
            try
            {
                oDataAccess = new Helper();
                IdEmpleado = Convert.ToString(TramaCampos[2]);
                Password = Convert.ToString(TramaCampos[3]);
                oDataAccess.ValidarCredencialesIslero(IdEmpleado, Password);
                trama = "VC|";


            }
            catch (Exception ex)
            {


                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ValidarCredencialesUsuario ", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";

                string mensaje = ex.Message;
                bool imprime = true;
                bool valor = false;
                if (ExcepcionOcurrida != null)
                {
                    ExcepcionOcurrida(mensaje, imprime, valor, Puerto);
                }
            }
            return trama;
        }




        #endregion
        /// <summary>
        /// Imprime una venta seleccionada por el usuario
        /// </summary>
        /// <returns></returns>
        private string VentaCheque()
        {
            byte Cara = 0;
            string numeroAutorizacionCheque = "";
            short TipoIdentificacion = 0;
            string Placa = "";
            bool EsClienteIdentificado = false;


            string trama = "";
            try
            {
                Cara = Convert.ToByte(TramaCampos[4]);
                numeroAutorizacionCheque = TramaCampos[5];
                Placa = TramaCampos[6];
                if (TramaCampos[1].Equals("1"))
                {
                    EsClienteIdentificado = true;

                    if (TramaCampos[3].Equals("1"))
                    {
                        TipoIdentificacion = 3;
                    }
                    else if (TramaCampos[3].Equals("2"))
                    {
                        TipoIdentificacion = 4;
                    }
                    else if (TramaCampos[3].Equals("0"))
                    {
                        TipoIdentificacion = 1;
                    }

                }
                else
                {
                    TipoIdentificacion = 2;
                    EsClienteIdentificado = false;
                }
                if (AutorizarVentaCheque != null)
                {
                    AutorizarVentaCheque(Cara, numeroAutorizacionCheque, TipoIdentificacion, "0", Placa, EsClienteIdentificado, Puerto);

                }


            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ImprimirUltimaVentaPeru", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;
        }

        private string ValidarCredencialesAdministrador(string Cabecera)
        {

            string trama = string.Empty;
            try
            {
                IdEmpleado = TramaCampos[1];
                Password = TramaCampos[2];
                oHelper.ValidarCredencialesUsuarioAdministrador(IdEmpleado, Password);
                trama = Cabecera + "|";
            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ValidarCredencialesAdministrador", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;

        }

        private string ValidarCredencialesDespachador()
        {

            string trama = string.Empty;
            try
            {
                IdEmpleado = TramaCampos[1];
                Password = TramaCampos[2];
                oHelper.ValidarCredencialesIslero(IdEmpleado, Password);
                trama = "CD|";
            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ValidarCredencialesDespachador", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;

        }

        private string ObtenerProducto()
        {
            string trama = "";
            try
            {

                POSstation.FabricaCanastilla.Producto oProducto = new POSstation.FabricaCanastilla.Producto();
                int CodigoProductoTmp = Convert.ToInt32(TramaCampos[1]);
                int IdIsla = -1;
                InformacionProducto oInformacion;

                //Si es consumo o es canastilla normal
                oInformacion = oProducto.RecuperarProductoTerpel(CodigoProductoTmp, IdIsla);

                string Nombre = oInformacion.Descripcion;

                if (Nombre.Length > 14)
                {
                    Nombre = Nombre.Substring(0, 14);
                }
                string Precio = Convert.ToString(oInformacion.Precio);
                string CantidadDisponible = "";
                //Si es consumo no tenemos que verificar si se van a mostrar las existencias o no              
                if (!oInformacion.ManejaExistencias)
                    trama = "CP*" + Nombre + "*" + "Ilimitada" + "*" + Precio + "|";
                else
                {
                    CantidadDisponible = oInformacion.Existencias.ToString();
                    trama = "CP*" + Nombre + "*" + CantidadDisponible + "*" + Precio + "|";
                }


            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ObtenerProducto", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";

            }
            return trama;
        }

        private string ObtenerFranquiciaTarjetaCredito()
        {
            return RecuperarFranquicias(true);
        }




        private string RecuperarFranquicias(Boolean EsDebito)
        {
            string trama = string.Empty;
            try
            {
                StringBuilder Lista = new StringBuilder();
                int tipoBusqueda;
                if (EsDebito)
                    tipoBusqueda = 0;
                else
                    tipoBusqueda = 3;
                DataTable Franquicias = oHelper.RecuperarFranquicias(tipoBusqueda);

                if (Franquicias.Rows.Count > 0)
                {
                    Lista.Append("V0");
                }
                else
                    Lista.Append("VR");

                string Nombre = "";

                foreach (DataRow item in Franquicias.Rows)
                {
                    Nombre = item["Descripcion"].ToString();

                    if (Nombre.Length > 13)
                    {
                        Nombre = Nombre.Substring(0, 10);
                    }
                    Lista.Append(item["IdFranquicia"].ToString() + ") " + Nombre + (char)(0x0D));
                }

                trama = Lista.ToString() + "|";

            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en SurtidoresDisponiblesApertura", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;

        }
        private string ObtenerFranquiciaTarjetaDebito()
        {
            return RecuperarFranquicias(false);
        }

        /// <summary>
        /// Obtiene los surtidores que estan disponibles para una apertura de turno
        /// </summary>
        /// <returns></returns>
        private string SurtidoresDisponiblesApertura()
        {
            IdEmpleado = TramaCampos[1];
            Password = TramaCampos[2];

            IDataReader Lector = null;
            Helper oDataAccess = new Helper();
            String trama = "T0";
            try
            {
                oDataAccess.ValidarCredencialesIslero(IdEmpleado, Password);// Valido las Credenciales antes de mandar abrir turno
                Lector = oDataAccess.RecuperarSurtidoresSinTurnoAbierto();

                while (Lector.Read())
                {

                    if (Lector["IdSurtidor"].ToString().Length > 1)
                    {
                        trama += "*" + Lector["IdSurtidor"].ToString();
                    }
                    else
                    {
                        trama += "*" + "0" + Lector["IdSurtidor"].ToString();
                    }

                }
                trama += "|";
                Lector.Close();
                Lector.Dispose();


            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en SurtidoresDisponiblesApertura", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }


            return trama;
            //return "T0*01*02*03*04*05*08|";
        }

        private string AbrirTurno()
        {
            Helper oDataAccess = new Helper();
            String trama;
            IdEmpleado = TramaCampos[1];
            string Surtidores = "";

            try
            {


                for (int i = 2; i <= TramaCampos.Length - 1; i++)
                {
                    Surtidores = Surtidores + TramaCampos[i] + "|";

                }
                if (AperturaTurno != null)
                {
                    AperturaTurno(IdEmpleado, Password, Surtidores, Puerto);
                }
                trama = "M1*Apertura de turno" + (char)(0x0D) + "en proceso|";
            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en AbrirTurno", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }


            return trama;
        }

        private string SurtidorDisponibleCierre()
        {
            IdEmpleado = TramaCampos[1];
            string Clave = TramaCampos[2];
            IdEmpleado = TramaCampos[1];
            Password = TramaCampos[2];

            IDataReader Lector = null;
            Helper oDataAccess = new Helper();
            String trama = "T2";
            try
            {
                oDataAccess.ValidarCredencialesIslero(IdEmpleado, Password);// Valido las Credenciales antes de mandar abrir turno
                Lector = oDataAccess.RecuperarSurtidoresConTurnoAbierto();

                while (Lector.Read())
                {

                    if (Lector["IdSurtidor"].ToString().Length > 1)
                    {
                        trama += "*" + Lector["IdSurtidor"].ToString();
                    }
                    else
                    {
                        trama += "*" + "0" + Lector["IdSurtidor"].ToString();
                    }

                }
                trama += "|";
                Lector.Close();
                Lector.Dispose();


            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en SurtidorDisponibleCierre", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;
        }

        private string CerrarTurno()
        {
            string trama = string.Empty;
            /* VALIDA: 
             *  Credenciales del Despachador
             *  Surtidores en Estado para Cerrar Turno: Mangueras colagadas, no vendiendo
             *  Surtidores con Turno Abierto
             * PROCESA:
             *  CerrarTurno
             */
            try
            {
                IdEmpleado = TramaCampos[1];
                string Surtidores = TramaCampos[2];


                for (int i = 2; i <= TramaCampos.Length - 1; i++)
                {
                    Surtidores = Surtidores + TramaCampos[i] + "|";

                }

                if (CierreTurno != null)
                {
                    CierreTurno(IdEmpleado, Password, Puerto, Surtidores);
                }
                trama = "M1*Cierre de turno" + (char)(0x0D) + "en proceso|";
            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en CerrarTurnoTotal", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;

        }

        private string CerrarTurnoTotal()
        {

            string trama, key = "";

            try
            {

                IdEmpleado = TramaCampos[1];
                Password = TramaCampos[2];
                if (CierreTurno != null)
                {
                    CierreTurno(IdEmpleado, Password, Puerto, key);
                }
                trama = "M1*Cierre de turno" + (char)(0x0D) + "en proceso|";
            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en CerrarTurnoTotal", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;
        }

        private string CerrarTanquesVeederRoot()
        {
            string trama = string.Empty;
            try
            {

                int turnoTemporal = 0;
                if (InformarStocksTanquesCierreTurnoServicio != null)
                {
                    InformarStocksTanquesCierreTurnoServicio(turnoTemporal);
                }
                trama = "M1*Cierre de tanques" + (char)(0x0D) + "en proceso|";
            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en CerrarTanquesVeederRoot", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;
        }

        private string ObtenerTanques()
        {

            string trama = string.Empty;
            try
            {
                bool AplicaAlturas = Convert.ToBoolean(oHelper.RecuperarParametro("AplicaSolicitudAlturas"));

                //    //Datos del Empleado
                IdEmpleado = TramaCampos[1];
                Password = TramaCampos[2];

                Boolean esDispositivo = true;
                lstTanques = new List<string>();

                System.Text.StringBuilder sbStr;
                sbStr = new System.Text.StringBuilder();

                //Llamamos al sp de validación
                IDataReader drValidar = oHelper.RecuperarTanquesCierreAutomatico(IdEmpleado, Password);

                sbStr.Append("T5*");

                if (drValidar.Read())
                {
                    if (!Convert.ToBoolean(drValidar["ManejaDispositivoMedicion"]))
                    {
                        //Guardamos el tanque
                        lstTanques.Add(drValidar["Codigo"].ToString());

                        sbStr.Append(drValidar["Codigo"].ToString() + "*");
                        esDispositivo = false;
                    }

                    while (drValidar.Read())
                    {

                        if (!Convert.ToBoolean(drValidar["ManejaDispositivoMedicion"]))
                        {
                            //Guardamos el tanque
                            lstTanques.Add(drValidar["Codigo"].ToString());

                            sbStr.Append(drValidar["Codigo"].ToString() + "*");
                            esDispositivo = false;
                        }
                    }

                    //Retornamos A si todos los tanques tienen dispositivo de medición y Y si se van a pedir alturas
                    if (esDispositivo)
                        throw new Exception("Existe un dispositipo de medicion configurado, entre a la opcion de VeederRoot");
                    else
                    {
                        trama = sbStr.ToString();
                        trama = trama + "1|";
                    }

                }
                else
                    throw new Exception(" No hay informacion de tanques para el turno");

                drValidar.Close();

            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ObtenerTanques", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
                /********************************************************************************************************/
            }
            return trama;
        }

        private decimal CalcularFraccion(string Cantidad)
        {
            double Numero;

            decimal Entero = 0;
            decimal Fraccion = 0;
            string[] Vector;

            char[] r = { '.' };

            Vector = new string[Cantidad.Length - 1];

            if (Cantidad.IndexOf(".") > 0)
            {

                Vector = Cantidad.Split(r);

                Entero = Convert.ToDecimal(Vector[0]);
                Fraccion = Convert.ToDecimal(Vector[1]);

                Numero = System.Math.Pow(10.0, Convert.ToDouble(Convert.ToString(Fraccion).Length));

                Fraccion = Fraccion / Convert.ToInt32(Numero);

            }
            else
                Entero = Convert.ToDecimal(Cantidad);

            return Entero + Fraccion;
        }
        private string CerrarTanquesManual()
        {
            string trama = string.Empty;
            try
            {
                //if (TramaCampos[1] == "")    //Envía Altura y Volumen por Tanque
                //{
                //        decimal altAgua = 0;
                //        decimal altMax = 0;
                //        Boolean Error = false;
                //        Boolean esActivo = true;
                //        List<string> lstTanquesPorVolumen = new List<string>();

                //        //Mandamos a hacer el ajuste por recibo a todos los tanques
                //        for (int i = 2; i <= TramaCampos.Length - 1; i += 3)
                //        {

                //            if (lstTanques.Contains(Convert.ToInt32(TramaCampos[i]).ToString()))
                //            {
                //                altMax = CalcularFraccion(TramaCampos[i + 1]);
                //                altAgua = CalcularFraccion(TramaCampos[i + 2]);

                //                try { oHelper.RecuperarCantidadporAforo(TramaCampos[i], altMax, altAgua); }
                //                catch (Exception ex)
                //                {
                //                    //Añadimos el tanque a la lista que se va a enviar a la MR para solicitar el volúmen
                //                    lstTanquesPorVolumen.Add(TramaCampos[i]);
                //                    /********************************************************************************************************/
                //                    LogCategorias.Clear();
                //                    LogCategorias.Agregar("SeguimientoDTI");
                //                    LogPropiedades.Clear();
                //                    LogPropiedades.Agregar("Mensaje", ex.Message);
                //                    gasolutions.Factory.LogIt.Loguear("Excepcion en Ajustes por Operacion Cierre de Turno", LogPropiedades, LogCategorias);
                //                    /********************************************************************************************************/
                //                    Error = true;
                //                }

                //            }

                //        }

                //        string codTanque = "";
                //        string stock = "";
                //        string volumenAgua = "";

                //        trama = "Y|";

                //        alturasTanques = new ColTanques();

                //        //Mandamos a hacer el ajuste por recibo a todos los tanques
                //        for (int i = 2; i <= TramaCampos.Length - 1; i += 6)
                //        {

                //            if (lstTanques.Contains(Convert.ToInt32(TramaCampos[i]).ToString()))
                //            {
                //                altMax = CalcularFraccion(TramaCampos[i + 2]);
                //                altAgua = CalcularFraccion(TramaCampos[i + 4]);

                //                codTanque = TramaCampos[i];

                //                //Adicionamos los datos a la colección
                //                if (!lstTanquesPorVolumen.Contains(Convert.ToInt32(codTanque).ToString()))
                //                {

                //                    stock = Convert.ToString(altMax);
                //                    volumenAgua = Convert.ToString(altAgua);

                //                    alturasTanques.Add(codTanque, esActivo, stock, volumenAgua);
                //                }
                //            }

                //        }

                //        //Lanzamos el evento de ajuste de los tanques
                //        if (!Error)
                //        {
                //            string key = string.Empty;
                //            //Lanzamos el evento del cierre de turno
                //            oEventos.CerrarTurno(IdEmpleado, Password, Puerto, key);
                ////            //Lanzamos el evento de ajuste de los tanques
                ////            oEventos.SolicitarEnviarAlturasCierreDeTanques(IdEmpleado, Password, alturasTanques, esActivo, Puerto);
                ////        }
                //        else
                //        {
                //            StringBuilder sbrTanques = new StringBuilder();

                //            sbrTanques.Append("N");

                //            for (int i = 0; i <= lstTanquesPorVolumen.Count - 1; i++)
                //            {
                //                sbrTanques.Append(lstTanquesPorVolumen[i]);
                //            }

                //            trama = sbrTanques.ToString() + "|";
                //        }
                //}
                if (TramaCampos[1] == "1")                      //Envía Volumen por Tanque
                {
                    decimal altAgua = 0;
                    decimal altMax = 0;
                    Boolean Error = false;
                    Boolean esActivo = true;
                    List<string> lstTanquesPorVolumen = new List<string>();

                    string codTanque = "";
                    string stock = "";
                    string volumenAgua = "";

                    trama = "Y|";

                    alturasTanques = new ColTanques();

                    //Mandamos a hacer el ajuste por recibo a todos los tanques
                    for (int i = 2; i <= TramaCampos.Length - 1; i += 2)
                    {
                        codTanque = TramaCampos[i];
                        if (lstTanques.Contains(Convert.ToInt32(codTanque).ToString()))
                        {


                            codTanque = TramaCampos[i];

                            //Adicionamos los datos a la colección
                            if (!lstTanquesPorVolumen.Contains(Convert.ToInt32(codTanque).ToString()))
                            {

                                stock = Convert.ToString(altMax);
                                volumenAgua = Convert.ToString(altAgua);
                                codTanque = (Convert.ToInt32(codTanque).ToString()).ToString();

                                alturasTanques.Add(codTanque, esActivo, stock, volumenAgua);
                            }
                        }

                    }

                    codTanque = "";
                    //Lanzamos el evento de ajuste de los tanques
                    if (!Error)
                    {
                        string key = string.Empty;
                        //Lanzamos el evento del cierre de turno
                        if (CierreTurno != null)
                        {
                            CierreTurno(IdEmpleado, Password, Puerto, key);
                        }
                        //Lanzamos el evento de ajuste de los tanques
                        if (EnviarAlturasCierreDeTanques != null)
                        {
                            EnviarAlturasCierreDeTanques(IdEmpleado, Password, alturasTanques, esActivo, Puerto);
                        }
                        trama = "T6|";
                    }
                    else
                    {
                        StringBuilder sbrTanques = new StringBuilder();

                        sbrTanques.Append("N");

                        for (int i = 0; i <= lstTanquesPorVolumen.Count - 1; i++)
                        {
                            sbrTanques.Append(lstTanquesPorVolumen[i] + ":");
                        }

                        trama = sbrTanques.ToString() + "|";
                    }
                }



            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ObtenerTanques", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
                /********************************************************************************************************/
            }
            return trama;
        }




        private string ObtenerFaltantesSobrantes()
        {
            string trama = string.Empty;
            try
            {
                IdEmpleado = TramaCampos[1];
                Password = TramaCampos[2];


                if (!Convert.ToBoolean(oHelper.RecuperarParametro("AplicaConsignacionesdeSobre")))
                {
                    throw new Exception("Active esta funcionalidad en los parametros de la estacion");
                }

                oColConsignacion = new ColConsignacion();
                short idTipoTurno = 0;
                int turno = 0;


                IDataReader drTurno;
                drTurno = oHelper.RecuperarTurnoConsignaciones(IdEmpleado, Password, true);

                if (drTurno.Read())
                {
                    idTipoTurno = Convert.ToInt16(drTurno["IdTipoTurno"].ToString());
                    turno = Convert.ToInt32(drTurno["IdTurno"].ToString());
                }

                drTurno.Close();


                IDataReader ODatos;

                ODatos = oHelper.RecuperarSobranteFaltanteTurno(turno, idTipoTurno);

                if (ODatos.Read())
                {
                    if (Convert.ToDecimal(ODatos["Valor"].ToString()) > 0)
                    {
                        if (Convert.ToBoolean(ODatos["EsSobrante"]) == true)
                        {
                            trama = "T7*1*" + ODatos["Valor"].ToString() + "|";
                            sobresVariable = Convert.ToDouble(ODatos["Valor"].ToString());
                        }

                        else
                        {
                            trama = "T7*0*" + ODatos["Valor"].ToString() + "|";
                            sobresVariable = Convert.ToDouble(ODatos["Valor"].ToString());
                        }

                    }
                }
                else
                {
                    trama = "M1*No hay valores pendientes para consignar|";

                }
                ODatos.Close();
                ODatos = null;
            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ObtenerFaltantesSobrantes", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }

            return trama;

        }

        private string ObtenerValorSobreFijo()
        {
            string trama = string.Empty;
            try
            {
                trama = "T8*";
                trama += oHelper.RecuperarParametro("ValorSobre") + "|";
            }
            catch (Exception ex)
            {


                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ObtenerValorSobreFijo", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;

        }

        private string ConsignarSobreFijo()
        {
            string trama = string.Empty;
            try
            {
                if (!Convert.ToBoolean(oHelper.RecuperarParametro("AplicaConsignacionesdeSobre")))
                {

                    throw new Exception("Active esta funcionalidad en los parametros de la estacion");
                }

                double Cantidad = Convert.ToDouble(TramaCampos[2]);
                short idTipo = 0;
                double valor = 0;
                trama = "T9|";
                short TipoMoneda = 1;

                //Adicionamos el valor
                sobresFijo += Cantidad;

                idTipo = Convert.ToInt16(ConsignacionSobres.Total);
                valor = Convert.ToDouble(Cantidad);

                if (oColConsignacion == null)
                {
                    oColConsignacion = new ColConsignacion();
                }

                oColConsignacion.Add(idTipo, valor, TipoMoneda);
            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ConsignarSobreFijo", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
                //Inicializamos nuevamente las variables
                sobresFijo = 0;
                sobresVariable = 0;
                oColConsignacion = null;

            }
            return trama;
        }

        private string ConsignarSobreVariable()
        {


            string trama = string.Empty;
            try
            {

                IdEmpleado = TramaCampos[1];
                Password = TramaCampos[2];
                string cadena = TramaCampos[3];
                string TipoMoneda = TramaCampos[4];

                if (!Convert.ToBoolean(oHelper.RecuperarParametro("AplicaConsignacionesdeSobre")))
                {

                    throw new Exception("Active esta funcionalidad en los parametros de la estacion");
                }

                decimal Valortemp = Convert.ToDecimal(Utilidades.ModificarFormatoDecimal(cadena));
                //  double Valor = Convert.ToDouble(TramaElementos[2]);
                double Valor = Convert.ToDouble(Valortemp);

                string ValorSobre;

                try
                {
                    ValorSobre = oHelper.RecuperarParametro("ValorSobre");
                }
                catch (Exception ex)
                {
                    /********************************************************************************************************/
                    LogCategorias.Clear();
                    LogCategorias.Agregar("SeguimientoDTI");
                    LogPropiedades.Clear();
                    LogPropiedades.Agregar("Mensaje", ex.Message);
                    LogIt.Loguear("Excepcion en Consignar -- ConsignarSobreVariable", LogPropiedades, LogCategorias);
                    /********************************************************************************************************/
                    ValorSobre = null;
                }

                if (ValorSobre != null)
                {

                    short idtipo = 0;
                    double valor = 0;
                    short Moneda = Convert.ToInt16(TipoMoneda);
                    idtipo = Convert.ToInt16(ConsignacionSobres.Pico);
                    valor = Convert.ToDouble(Valor);

                    if (oColConsignacion == null)
                    {
                        oColConsignacion = new ColConsignacion();
                    }
                    oColConsignacion.Add(idtipo, valor, Moneda);
                    trama = "TA|";

                }
                else
                {
                    trama = "M1*No existen valores por " + (char)(0x0D) + "consignar|";

                }

            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ConsignarSobreVariable", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;
        }


        private string EnviarConsignaciones(Boolean EsTurnoTrabajo, Boolean EsCierreTurno)
        {
            string trama = string.Empty;
            try
            {

                Boolean aplica = false;

                if (oColConsignacion.Count > 0)
                    aplica = true;


                //Lanzamos el evento
                if (EsTurnoTrabajo)
                {
                    if (EsCierreTurno)
                        if (CierreTurnoTrabajo != null)
                        {
                            CierreTurnoTrabajo(IdEmpleado, oColConsignacion, aplica, Puerto);
                        }
                        else
                            if (InformarCierreConsignaciones != null)
                            {
                                InformarCierreConsignaciones(IdEmpleado, Password, oColConsignacion, aplica, Puerto);
                            }
                }
                else
                    if (InformarCierreConsignaciones != null)
                    {
                        InformarCierreConsignaciones(IdEmpleado, Password, oColConsignacion, aplica, Puerto);
                    }


                //Inicializamos nuevamente las variables
                sobresFijo = 0;
                sobresVariable = 0;
                oColConsignacion = null;
                trama = "M1*Peticion en proceso|";
            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en EnviarConsignaciones", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
                sobresFijo = 0;
                sobresVariable = 0;
                oColConsignacion = null;
            }
            return trama;
        }


        string ModificarMedioPagoRecarga()
        {
            string trama = "";
            try
            {
                string[] TramaValores = new string[3];
                string[] TramaMediosPagos = new string[3];
                TramaMediosPagos[0] = TramaCampos[0];

                //oCupoPrepago.AgregarMedioPago(MedioPago, Convert.ToDouble(ValorCarga));

            }
            catch (Exception ex)
            {

                /********************************************************************************************************/
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ValidarTarjeta", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
                sobresFijo = 0;
                sobresVariable = 0;
                oColConsignacion = null;

            }

            return trama;
        }

        private string ValidarTarjeta()
        {
            string trama = "";
            string NumeroTarjeta = TramaCampos[2];
            try
            {
                IdEmpleado = Convert.ToString(TramaCampos[1]);
                Password = Convert.ToString(TramaCampos[2]);

                IDataReader drTurno = oHelper.RecuperarTurnoCredencialesPorTipo(IdEmpleado, Password);
                if (drTurno.Read())
                {
                    idTipoTurno = Convert.ToInt16(drTurno["IdTipoTurno"].ToString());
                    IdTurno = Convert.ToInt32(drTurno["IdTurno"].ToString());
                }

                drTurno.Close();
                drTurno = null;

                if (oHelper.ExisteTarjeta(NumeroTarjeta) == true)
                {
                    trama = "GP|";
                    oCupoPrepago = new CupoPrepago();

                }
                else
                {
                    throw new Exception("Tarjeta no existe o esta inactiva");
                }
            }
            catch (Exception ex)
            {

                /********************************************************************************************************/
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ValidarTarjeta", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
                sobresFijo = 0;
                sobresVariable = 0;
                oColConsignacion = null;

            }

            return trama;
        }
        private string CerrarSobres()
        {
            string trama = string.Empty;
            try
            {

                if (!Convert.ToBoolean(oHelper.RecuperarParametro("AplicaConsignacionesdeSobre")))
                {

                    throw new Exception("Active esta funcionalidad en los parametros de la estacion");
                }

                if (TramaCampos.Length > 0)
                {
                    IdEmpleado = TramaCampos[1];
                    Password = TramaCampos[2];
                }


                InformarCierreConsignaciones(IdEmpleado, Password, new ColConsignacion(), true, Puerto);
                trama = "M1*Peticion en proceso";
            }
            catch (Exception ex)
            {
                /********************************************************************************************************/
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en CerrarSobres", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
                sobresFijo = 0;
                sobresVariable = 0;
                oColConsignacion = null;

            }

            return trama;
        }

        private string CopiaCierreTurnoSurtidor()
        {
            string Fecha;
            byte Surtidor;
            byte Turno;
            string trama;
            string dia;
            string mes;
            string ano;

            try
            {

                Fecha = TramaCampos[1];
                Surtidor = Convert.ToByte(TramaCampos[2]);
                Turno = Convert.ToByte(TramaCampos[3]);


                if (Fecha.Length < 6)
                {
                    throw new Exception("La fecha no tiene el formato correcto");

                }
                else
                {
                    dia = Fecha.Substring(0, 2);
                    mes = Fecha.Substring(2, 2);
                    ano = Fecha.Substring(4, 2);
                    Fecha = "20" + ano + mes + dia;

                    if (Convert.ToInt32(dia) > 31)
                        throw new Exception("El dia digitado es incorrecto no, existe el dia numero: " + dia);

                    if (Convert.ToInt32(mes) > 12)
                        throw new Exception("El mes digitado es incorrecto no, existe el mes numero: " + mes);
                    if (ReimprimirTurnoPorSurtidor != null)
                    {
                        ReimprimirTurnoPorSurtidor(Turno, Fecha, Surtidor, Puerto);
                    }
                    trama = "M1*Copia de Cierre" + (char)0x0D + "en Proceso|";
                }
            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en CopiaCierreTurnoSurtidor", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }

            /* PROCESA:
             * Impresión de Cierre con Fecha, Surtidor y Turno
             */
            return trama;
        }

        private string CopiaCierreTurnoEmpleado()
        {
            string Fecha;
            string dia;
            string mes;
            string ano;


            string trama;
            try
            {

                Fecha = TramaCampos[2];
                IdEmpleado = TramaCampos[1];

                if (Fecha.Length < 6)
                {
                    throw new Exception("La fecha no tiene el formato correcto");

                }
                else
                {
                    dia = Fecha.Substring(0, 2);
                    mes = Fecha.Substring(2, 2);
                    ano = Fecha.Substring(4, 2);
                    Fecha = "20" + ano + mes + dia;

                    if (Convert.ToInt32(dia) > 31)
                        throw new Exception("El dia digitado es incorrecto no, existe el dia numero: " + dia);

                    if (Convert.ToInt32(mes) > 12)
                        throw new Exception("El mes digitado es incorrecto no, existe el mes numero: " + mes);

                    if (ReimprimirTurnoPorEmpleado != null)
                    {
                        ReimprimirTurnoPorEmpleado(IdEmpleado, Fecha, Puerto);
                    }
                    trama = "M1*Copia de Cierre" + (char)0x0D + "en Proceso|";
                }
            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en CopiaCierreTurnoSurtidor", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }

            return trama;

        }

        private string Auditoria()
        {
            string trama;
            Helper oDataAccess = new Helper();
            try
            {

                IdEmpleado = TramaCampos[1];
                Password = TramaCampos[2];
                oDataAccess.ValidarCredencialesIslero(IdEmpleado, Password);
                if (ImprimirArqueo != null)
                {
                    ImprimirArqueo(IdEmpleado, Password, Puerto);
                }
                trama = "M1*Impresion de" + (char)0x0D + "Auditoria en" + (char)0x0D + "Proceso|";
            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en Auditoria", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;

        }

        private string ResumenDia()
        {
            string Fecha;
            string trama;
            string dia;
            string mes;
            string ano;
            bool EsMrCombustible = true;

            try
            {
                Fecha = TramaCampos[1];

                if (Fecha.Length < 6)
                {
                    throw new Exception("La fecha no tiene el formato correcto");

                }
                else
                {
                    dia = Fecha.Substring(0, 2);
                    mes = Fecha.Substring(2, 2);
                    ano = Fecha.Substring(4, 2);

                    if (Convert.ToInt32(dia) > 31)
                        throw new Exception("El dia digitado es incorrecto no, existe el dia numero: " + dia);

                    if (Convert.ToInt32(mes) > 12)
                        throw new Exception("El mes digitado es incorrecto no, existe el mes numero: " + mes);

                    Fecha = "20" + ano + mes + dia;

                    if (TramaCampos.Length == 3)
                    {
                        string Turno = TramaCampos[2];
                        if (ImprimirResumenDiario != null)
                        {
                            ImprimirResumenDiario(Fecha, EsMrCombustible, Puerto);
                        }
                        trama = "M1*Impresion de" + (char)0x0D + "Datos del turno" + (char)0x0D + "en Proceso|";
                    }
                    else
                    {
                        if (ImprimirResumenDiario != null)
                        {
                            ImprimirResumenDiario(Fecha, EsMrCombustible, Puerto);
                        }
                        trama = "M1*Impresion de" + (char)0x0D + "Resumen Diario" + (char)0x0D + "en Proceso|";
                    }
                }
            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ResumenDia", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;

        }

        private string ReporteX()
        {
            string trama;
            try
            {
                if (ImprimirArqueoImpresora != null)
                {
                    ImprimirArqueoImpresora(Puerto);
                }
                trama = "M1*Impresion de" + (char)0x0D + "Reporte X" + (char)0x0D + "en proceso|";
            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ReporteX", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;


        }

        private string ReporteZ()
        {
            string trama;
            try
            {
                if (CierreImpresoraPorPuerto != null)
                {
                    CierreImpresoraPorPuerto(Puerto);
                }
                trama = "M1*Impresion de" + (char)0x0D + "Reporte Z" + (char)0x0D + "en proceso|";
            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ReporteX", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;

        }

        private string AlmacenarPlaca()
        {
            string Placa;
            byte Cara;
            string trama;
            Helper oDataAccess = new Helper();
            try
            {
                Placa = TramaCampos[1];
                Cara = Convert.ToByte(TramaCampos[3]);
                bool EsUltimaVenta = new bool();



                if (TramaCampos[2].Equals("1"))
                {
                    EsUltimaVenta = true; //asignacion realizado en el proceso de ajuste de la solucion estaba como  "EsUltimaVenta = t" BY:Yaky pas
                }

                if (oDataAccess.ExisteCara(Convert.ToInt16(Cara)))
                {

                    EsUltimaVenta = true;
                    if (RegistrarPlaca != null)
                    {
                        RegistrarPlaca(Cara, Placa, EsUltimaVenta, Puerto);
                    }

                    trama = "M1*Placa Almacenada|";
                }
                else
                    throw new Exception("La Cara " + Cara.ToString() + " no existe");
            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en AlmacenarPlaca", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }

            return trama;
        }

        private string AlmacenarKilometraje()
        {

            string trama;
            try
            {
                byte caratmp = Convert.ToByte(TramaCampos[1]);
                string Kilometraje = TramaCampos[2];
                Helper oDataAccess = new Helper();
                bool EsUltimaVenta = false;
                if (oDataAccess.ExisteCara(caratmp))
                {
                    if (GuardarKilometraje != null)
                    {
                        GuardarKilometraje(caratmp, Kilometraje, EsUltimaVenta, Puerto);
                    }
                    trama = "M1*Kilometraje" + (char)0x0D + "Almacenado|";
                }
                else
                    throw new Exception("La Cara No existe");

            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en AlmacenarKilometraje", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }

            return trama;
        }

        private string ProgramarVenta()
        {

            string Valor;
            byte Cara;
            string trama;
            byte tipo;
            Helper oDataAccess = new Helper();
            short idProducto = -1;
            try
            {
                Cara = Convert.ToByte(TramaCampos[2]);
                if (oDataAccess.ExisteCara(Convert.ToInt16(Cara)))
                {
                    Valor = TramaCampos[1];

                    if (TramaCampos[3].Equals("1"))
                        tipo = 0;
                    else
                        tipo = 1;
                    if (Preset != null)
                    {
                        Preset(Cara, Valor, tipo, idProducto, Puerto);
                    }
                    trama = "M1*Venta Cara " + Cara + (char)0x0D + "Programada|";
                }
                else
                    throw new Exception("La Cara " + Cara.ToString() + " No existe");

            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ProgramarVenta", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }


            return trama;
        }

        private string ObtenerDatosChip()
        {
            string trama = "";
            try
            {
                Helper oDataAccess = new Helper();
                string Cara = TramaCampos[1];
                string Datos = "";
                string Temporal = Cara.ToString();
                bool EsAutorizado = false;
                //Se solicita los datos al autorizador y se traen por referencia en la variable Datos, la variable temporal me sirve para enviar la cara y para recibir los mensaje
                //de error que se generan en el autorizador, la variable EsAutorizador me indica si todo salio bien

                if (EnviarDatosChipMr != null)
                {
                    EnviarDatosChipMr(Convert.ToByte(Cara),Datos, Puerto, ref Temporal, ref EsAutorizado);
                }

                if (EsAutorizado)
                {
                    string[] DatosChip = Datos.Split('|');
                    trama = "M2*Chip Cara: " + Cara + ":" + (char)0x0D + "Rom:" + DatosChip[0] + (char)0x0D + "Placa: " + DatosChip[1] +
                     (char)0x0D + "Fecha Proxima: " + (char)0x0D + DatosChip[2] + (char)0x0D + "Rev:  " + DatosChip[3] + "|";


                }
                else
                    throw new Exception(Temporal);

            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ObtenerDatosChip", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;

        }




        private string DescuentoPorRuc()
        {
            string trama;
            string ruc;
            string cara;
            Helper oDataAccess = new Helper();
            try
            {
                ruc = TramaCampos[1];
                cara = TramaCampos[2];

                if (oDataAccess.ExisteCara(Convert.ToInt16(cara)))
                {
                    if (DescuentoClienteRuc != null)
                    {
                        DescuentoClienteRuc(ruc, cara, Puerto);
                    }
                    return "M1*Proceso realizado|";
                }
                else
                    throw new Exception("La Cara " + cara.ToString() + " no existe");


            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en DescuentoPorRuc", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return "";
        }


        private string ImpresionDatosChip()
        {
            string trama = "";
            try
            {
                byte Cara = Convert.ToByte(TramaCampos[1]);
                if (SolicitudDatosIbutton != null)
                {
                    SolicitudDatosIbutton(Cara, Puerto);
                }
                return "M1*Impresion de" + (char)0x0D + "datos del chip en" + (char)0x0D + "proceso|";

            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ImpresionDatosChip", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return "";
        }




        private string ObtenerValorCheque()
        {
            string trama = string.Empty;
            try
            {
                if (TramaCampos.Length > 2)
                {
                    CodigocambioCheque = TramaCampos[1];
                    ReciboCambioCheque = TramaCampos[2];
                    ValorCheque = oHelper.RecuperarValorChequePorCodigo(CodigocambioCheque).ToString();
                    valorCambio = oHelper.ValidarCheque(Convert.ToInt64(CodigocambioCheque), Convert.ToDecimal(ValorCheque), Convert.ToInt64(ReciboCambioCheque));
                    trama = "A5*" + valorCambio + "|";
                }
                else
                {
                    Nullable<Int32> IdTurno = null;

                    if (oHelper.ValidarCredenciales(IdEmpleado, Password))
                    {
                        IdTurno = null;
                        string valorDti = TramaCampos[1];
                        int tempTurno = 0;
                        double dblValorCambio = Convert.ToDouble(valorCambio);

                        if (Convert.ToDouble(valorDti) > dblValorCambio)
                            throw new Exception("El valor digitado es mayor que el valor a cambiar por el cheque");

                        byte cara = oHelper.RecuperarCaraPorReciboVenta(Convert.ToInt32(ReciboCambioCheque));
                        //evaluamos si existe la cara
                        if (IdTurno.HasValue)
                            tempTurno = Convert.ToInt32(IdTurno);

                        IdTurno = Int32.Parse(oHelper.RecuperarTurnoAbiertoPorEmpleado(IdEmpleado));
                        oHelper.InsertarCambioChequeMr(Convert.ToInt64(CodigocambioCheque), Convert.ToDecimal(dblValorCambio), tempTurno, Convert.ToInt64(ReciboCambioCheque), Convert.ToInt16(Cara));

                        //Lanzamos el evento
                        if (EnviarCambioCheque != null)
                        {
                            EnviarCambioCheque(CodigocambioCheque, tempTurno, cara, ReciboCambioCheque, dblValorCambio, dblValorCambio, Puerto);
                        }

                        valorCambio = string.Empty;
                        ValorCheque = string.Empty;
                        ReciboCambioCheque = string.Empty;
                        CodigocambioCheque = string.Empty;

                        //Retornamos que todo salió bien
                        trama = "M1*Peticion en proceso|";
                    }

                }


            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ObtenerValorCheque", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;
        }

        private string AlmacenarDineroDevolver()
        {
            //string Recibo = TramaCampos[1];
            //string CodigoAutorizacion = TramaCampos[2];
            //string ValorADevolver = TramaCampos[3];
            ///*
            // * PROCESA:
            // *  Dinero a Devolver
            // */
            //return "M1*Proceso realizado|";
            return "M1*Opcion" + (char)(0x0D) + "No Disponible|";
        }
        public bool ValidarFormatoTarjeta(string tarjeta)
        {
            bool band = false;
            try
            {

                if (tarjeta.Contains(".") || tarjeta.Contains(",") || tarjeta.Contains("'") || tarjeta.Contains(";") || tarjeta.Contains(":") || tarjeta.Contains("*"))
                {
                    band = true;
                }
                else
                {
                    band = false;
                }



            }
            catch (Exception ex)
            {

                /********************************************************************************************************/
                LogCategorias.Clear();
                LogCategorias.Agregar("Anomalia");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ValidarFormatoTarjeta", LogPropiedades, LogCategorias);

            }

            return band;
        }



        private bool ValidarFidelizarNumeroTarjeta()
        {
            Boolean AplicaFidelizarConNumeroTarjeta = false;

            try
            {
                Helper oDataAccess = new Helper();
                AplicaFidelizarConNumeroTarjeta = Convert.ToBoolean(oDataAccess.RecuperarParametro("FidelizarConNumeroTarjeta"));
                if (AplicaFidelizarConNumeroTarjeta == true)
                {
                    AplicaFidelizarConNumeroTarjeta = true;
                }
                else
                {
                    AplicaFidelizarConNumeroTarjeta = false;
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                bool imprime = true;
                bool valor = false;
                if (ExcepcionOcurrida != null)
                {
                    ExcepcionOcurrida(mensaje, imprime, valor, Puerto);
                }
                throw ex;
            }
            return AplicaFidelizarConNumeroTarjeta;
        }

        private bool ValidarFidelizarRuc()
        {
            Boolean AplicaFidelizarConIdentificacion = false;

            try
            {
                Helper oDataAccess = new Helper();
                AplicaFidelizarConIdentificacion = Convert.ToBoolean(oDataAccess.RecuperarParametro("AplicaFidelizarConIdentificacion"));

                if (AplicaFidelizarConIdentificacion == true)
                {
                    AplicaFidelizarConIdentificacion = true;
                }
                else
                {
                    AplicaFidelizarConIdentificacion = false;
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                bool imprime = true;
                bool valor = false;
                if (ExcepcionOcurrida != null)
                {
                    ExcepcionOcurrida(mensaje, imprime, valor, Puerto);
                }
                throw ex;
            }
            return AplicaFidelizarConIdentificacion;
        }



        private string FidelizarVentaF()
        {
            string trama;
            byte Cara;
            string NumeroTarjeta;
            Helper odatos = new Helper();
            Int16 IdRedFidelizacion;
            string Rut = "";
            try
            {
                Cara = Convert.ToByte(TramaCampos[2]);
                NumeroTarjeta = TramaCampos[4];
                IdRedFidelizacion = odatos.ManejaRedFidelizacion();



                if (TramaCampos[3].Equals("3") && ValidarFidelizarNumeroTarjeta() == false)
                {
                    throw new Exception("La opcion de fidelizar por numero tarjeta esta inactiva");

                }

                if (TramaCampos[3].Equals("4") && ValidarFidelizarRuc() == false)
                {
                    throw new Exception("La opcion de fidelizar por Ruc  esta inactiva");

                }

                if (ValidarFormatoTarjeta(NumeroTarjeta))
                {
                    throw new Exception("La Tarjeta contiene caracteres no validos");
                }

                if (TramaCampos[1] == "1")
                {
                    //Fideliza venta en curcanastillaso   
                    if (FidelizarVenta != null)
                    {
                        FidelizarVenta(Cara, NumeroTarjeta, IdRedFidelizacion, Puerto, Rut);
                    }

                }
                else if (TramaCampos[1] == "2")
                {//Fideliza última venta
                    if (FidelizarUltimaVenta != null)
                    {
                        FidelizarUltimaVenta(Cara, NumeroTarjeta, IdRedFidelizacion, Puerto, Rut);
                    }
                }

                trama = "M1*Proceso de fidelizacion" + (char)0x0D + "de venta en cara " + Cara + (char)0x0D + "exitoso|";

            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en FidelizarVentaF", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }



            return trama;
        }


        private string PagoConBono()
        {
            string trama = "";
            try
            {
                Helper oDataAccess = new Helper();
                string ticket;
                string NumeroTarjeta = TramaCampos[4];
                byte TipoLectura = Convert.ToByte(TramaCampos[3]);
                //Obtenemos el prefijo y el consecutivo del documento
                string Prefijo = "";
                string Consecutivo = "";
                //Obtenemos el recibo de la venta
                string recibo = null;
                string Tipo = "1";
                string Rut = "";
                string NumeroBonos = "-1";
                string IdPremio = "-1";
                string DatosBono = string.Empty;

                byte cara = new Byte();


                if (TramaCampos[3].Equals("3") && ValidarFidelizarNumeroTarjeta() == false)
                {
                    throw new Exception("La opcion de fidelizar por numero tarjeta esta inactiva");

                }

                if (TramaCampos[3].Equals("4") && ValidarFidelizarRuc() == false)
                {
                    throw new Exception("La opcion de fidelizar por Ruc  esta inactiva");

                }

                //if (oDataAccess.ValidarBonoDescuentoPromocion())
                //{
                //    //if (TramaCampos[1] == "1")
                //    //{
                //    //    return "M1*Opcion" + (char)(0x0D) + "No Disponible|";
                //    //}

                //}
                //else
                //{
                //    //if (TramaCampos[1] == "2")
                //    //{
                //    //    return "M1*Opcion" + (char)(0x0D) + "No Disponible|";
                //    //}                    
                //}
                if (TramaCampos[1] == "1")
                {
                    ticket = TramaCampos[2];
                    if (oDataAccess.EsPGN())
                    {
                        if (ticket.Length > 4)
                        {
                            Prefijo = ticket.Substring(0, 4);
                            Consecutivo = ticket.Substring(4);
                        }
                        else
                            return "M1*Consecutivo" + (char)(0x0D) + "Invalido|";
                    }
                    else
                    {
                        if (ticket.Length > 3)
                        {
                            Prefijo = ticket.Substring(0, 3);
                            Consecutivo = ticket.Substring(3);
                        }
                        else
                            return "M1*Consecutivo" + (char)(0x0D) + "Invalido|";

                    }
                }
                else
                {
                    cara = Convert.ToByte(TramaCampos[2]);
                }



                if (NumeroBonos.Equals("-1") && IdPremio.Equals("-1"))
                {
                    DatosBono = string.Empty;
                }
                else
                    DatosBono = IdPremio + "|" + NumeroBonos;


                //if (Tipo == "03")
                //Rut = TramaCampos[4];


                if (ValidarFormatoTarjeta(NumeroTarjeta))
                {
                    throw new Exception("La Tarjeta contiene caracteres no validos");

                }

                if (TramaCampos[1] == "1")
                {
                    try
                    {
                        recibo = Convert.ToString(oDataAccess.RecuperarReciboParaBonoFidelizacion(Consecutivo, Prefijo));
                    }
                    catch (Exception exe)
                    {
                        throw new Exception(exe.Message);
                    }

                    if (recibo != null)
                    {
                        if (RedencionBonosFidelizacion != null)
                        {
                            RedencionBonosFidelizacion(NumeroTarjeta, recibo, Puerto);
                        }
                        trama = "M1*Pago Con Bono" + (char)0x0D + "Revise Ticket|";
                    }
                }
                else
                {
                    if (PredeterminarPagoVenta != null)
                    {
                        PredeterminarPagoVenta(cara, NumeroTarjeta, Puerto);
                    }

                    trama = "M1*Pago Con Bono" + (char)0x0D + "Revise Ticket|";
                }
            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Consultar Saldo Tarjeta Fidelizacion", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";

            }
            return trama;
        }


        private string SaldoTarjeta()
        {
            string NumeroIdentificacion = TramaCampos[2];
            string trama;
            string Rut = "";
            try
            {
                if (ValidarFormatoTarjeta(NumeroIdentificacion))
                {
                    throw new Exception("La Tarjeta contiene caracteres no validos");
                }


                if (TramaCampos[1].Equals("3") && ValidarFidelizarNumeroTarjeta() == false)
                {
                    throw new Exception("La opcion de fidelizar por numero tarjeta esta inactiva");

                }

                if (TramaCampos[1].Equals("4") && ValidarFidelizarRuc() == false)
                {
                    throw new Exception("La opcion de fidelizar por Ruc  esta inactiva");

                }
                if (ConsultarSaldoTarjetaFidelizacion != null)
                {
                    ConsultarSaldoTarjetaFidelizacion(NumeroIdentificacion, Puerto, Rut);
                }
                trama = "M1*Impresion de Saldo" + (char)0x0D + "en proceso|";
            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en SaldoTarjeta", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;
        }

        private string ConsumoInterno()
        {
            //Datos de la cara
            string trama = string.Empty;
            try
            {
                if (TramaCampos[1].Equals("1"))
                {


                    Byte cara = Convert.ToByte(TramaCampos[2]);
                    int Respuesta = oHelper.ValidarCaraConsumoInterno(Convert.ToInt16(cara));

                    if (Respuesta == 2)
                    {
                        trama = "M1*La Cara no existe|";
                    }
                    else if (Respuesta == 0)
                    {
                        if (EnvioVentaConsumoCombustible != null)
                        {
                            EnvioVentaConsumoCombustible(cara, Puerto);
                        }
                        trama = "M1*Ejecute el venta de consumo|";
                    }
                    else
                        trama = "M1*La Cara no existe|";
                }
                else
                {
                    long Consecutivo = 0;
                    int IdImpresora = oHelper.RecuperarIdImpresoraPorPuertoCapturador(Puerto);
                    int j = 0;
                    int y = 0;
                    string reciboCanastilla;
                    string CodigoFranquicia = "";
                    oFactura = new Factura();
                    j = 3;
                    y = 4;
                    while (y <= TramaCampos.Length)
                    {
                        oFactura.AgregarProductoTerpel(Convert.ToInt32(TramaCampos[j]), Convert.ToInt32(TramaCampos[y]), -1);
                        y += 2;
                        j += 2;
                    }
                    if (string.IsNullOrEmpty(CodigoFranquicia))
                    {
                        CodigoFranquicia = "-1";
                    }

                    Consecutivo = oFactura.GuardarVentaFullstationPeru(IdEmpleado, Password, "0", 0, "0", Convert.ToInt32(1), IdImpresora, 15, CodigoFranquicia, "");
                    reciboCanastilla = Consecutivo.ToString();
                    if (ImprimirFacturaCanastillaUnica != null)
                    {
                        ImprimirFacturaCanastillaUnica(reciboCanastilla, Puerto);
                    }
                    trama = "M1*Impresion en proceso|";


                }

            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ConsumoInterno", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;
        }
        private string ValidarProductosCombustibleFullPeru()
        {
            //Datos de la cara
            string trama = "";
            try
            {
                Int16 Producto = Convert.ToInt16(TramaCampos[1]);
                string Cantidad = TramaCampos[2];
                string TipoOperacion = "1";
                bool EsPorBaja = false;


                if (TipoOperacion.Equals("1"))
                {
                    EsPorBaja = false;
                }


                decimal Saldo = 0;
                decimal Entero = 0;
                decimal Fraccion = 0;
                string[] Vector;
                double Numero;


                char[] r = { '.' };

                Vector = new string[2];

                if (Cantidad.IndexOf(".") > 0)
                {
                    Vector = Cantidad.Split(r);

                    Entero = Convert.ToDecimal(Vector[0]);
                    Fraccion = Convert.ToDecimal(Vector[1]);

                    Numero = System.Math.Pow(10.0, Convert.ToDouble(Convert.ToString(Fraccion).Length));

                    Fraccion = Fraccion / Convert.ToInt32(Numero);

                }
                else
                    Entero = Convert.ToDecimal(Cantidad);

                Cantidad = Convert.ToString(Entero + Fraccion);

                try
                {
                    IDataReader drValidar = oHelper.ValidarProductoEnTanqueRemarcacionPeru(Tanque, Convert.ToDecimal(Cantidad), Convert.ToInt32(Producto), EsPorBaja);

                    if (drValidar.Read())
                    {
                        if (Convert.ToBoolean(drValidar["EsValido"]) == true)
                        {

                            Saldo = POSstation.Inventario.ManagementKardex.RecuperarSaldoTanque(Tanque, Producto);

                            if (Saldo >= Convert.ToDecimal(Cantidad))
                            {
                                short ProductoRem = Convert.ToInt16(TramaCampos[4]);

                                short IdProducto = Convert.ToInt16(Producto);
                                double CantidadARemarcar = Double.Parse(Cantidad);

                                IDataReader lector = oHelper.ValidarProductoEnTanqueRemarcacionPeru(TanqueRem, 0, ProductoRem, true);

                                if (lector.Read())
                                {
                                    if (Convert.ToBoolean(lector["EsValido"]) == true)
                                    {

                                        byte IdProductoBaja = Convert.ToByte(oHelper.RecuperarIdProductoCombustible(Convert.ToInt32(TramaCampos[1])));
                                        byte IdProductoAlta = Convert.ToByte(oHelper.RecuperarIdProductoCombustible(Convert.ToInt32(TramaCampos[4])));
                                        if (EnviarRemarcacionCombustible != null)
                                        {
                                            if (EnviarRemarcacionCombustible != null)
                                            {
                                                EnviarRemarcacionCombustible(Tanque, IdProductoBaja, CantidadARemarcar, TanqueRem, IdProductoAlta, Puerto);
                                            }
                                        }
                                        trama = "M1*Peticion en proceso";
                                    }
                                    else
                                    {
                                        throw new Exception(lector["Mensaje"].ToString());
                                    }
                                }

                                lector.Close();

                            }
                            else
                                throw new Exception("Cantidad excede saldo de Tanque");
                        }
                        else
                        {
                            throw new Exception(drValidar["Mensaje"].ToString());
                        }
                    }

                    drValidar.Close();
                }
                catch (Exception ex)
                {
                    LogCategorias.Clear();
                    LogCategorias.Agregar("SeguimientoDTI");
                    LogPropiedades.Clear();
                    LogPropiedades.Agregar("Mensaje", ex.Message);
                    LogIt.Loguear("Excepcion en ValidarProductosCombustibleFullPeru", LogPropiedades, LogCategorias);
                    Parrafo.Clear();
                    Parrafo = Utilidades.SeccionarTexto(ex.Message);
                    trama = "M1*";
                    foreach (string linea in Parrafo)
                    {
                        trama += linea + (char)(0x0D);
                    }
                    trama += "|";
                }

            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ValidarProductosCombustibleFullPeru", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";

            }
            return trama;
        }
        private string ObtenerCombustible(bool EsPorTanque, string tanque)
        {
            string trama = "";
            try
            {
                if (EsPorTanque)
                {
                    try
                    {

                        //Obtenemos la información que viene de la BD
                        DataTable dtProductos;
                        dtProductos = oHelper.RecuperarProductosTanque(tanque);

                        //Creamos e Instanciamos el StringBuilder que nos servirá para crear el paquete que va para la MR
                        System.Text.StringBuilder sbStr = new System.Text.StringBuilder();
                        string Fila;
                        int i = 0;

                        if (dtProductos.Rows.Count > 0)
                        {
                            sbStr.Append("RP"); // Datos correctos

                            foreach (DataRow oRow in dtProductos.Rows)
                            {

                                Fila = Convert.ToString(oRow["Nombre"]);

                                if (Fila.Length > 10)
                                {
                                    Fila = Fila.Substring(0, 9);
                                }
                                if (i >= 3)
                                {
                                    sbStr.Append("*" + Convert.ToString(oRow["Codigo"]) + ") " + "*" + Fila + " " + (char)(0x0D));
                                    i = 0;
                                }
                                else
                                    sbStr.Append("*" + Convert.ToString(oRow["Codigo"]) + ") " + "*" + Fila + " ");


                            }

                            sbStr.Append("|");
                        }

                        //Terminamos de armar la trama de salida
                        trama += sbStr.ToString();
                    }
                    catch (Exception ex)
                    {
                        /********************************************************************************************************/
                        LogCategorias.Clear();
                        LogCategorias.Agregar("SeguimientoDTI");
                        LogPropiedades.Clear();
                        LogPropiedades.Agregar("Mensaje", ex.Message);
                        LogIt.Loguear("Excepcion en ConfigurarProductos", LogPropiedades, LogCategorias);
                        Parrafo.Clear();
                        Parrafo = Utilidades.SeccionarTexto(ex.Message);
                        trama = "M1*";
                        foreach (string linea in Parrafo)
                        {
                            trama += linea + (char)(0x0D);
                        }
                        trama += "|";

                    }
                }
                else
                {
                    if (TramaCampos.Length > 1)
                    {
                        string documento = TramaCampos[2];
                        string placa = TramaCampos[1];
                        trama = ConfigurarProductos(documento, placa);
                    }
                    else
                    {
                        trama = RecuperarProductosCombustible();
                    }
                }
            }
            catch (Exception ex)
            {

                /********************************************************************************************************/
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ObtenerCombustible", LogPropiedades, LogCategorias);
                /********************************************************************************************************/

                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;
        }


        private string InsertarDetalleReciboCombustible()
        {
            string trama = "";
            try
            {
                //Recibimos la Información de la MR, Producto, Tanque, Cantidad y si Debemos traer nuevamente los datos
                short ProductoCombustible = Convert.ToInt16(TramaCampos[1]);
                string Tanque = TramaCampos[2];
                string Cantidad = TramaCampos[3];
                //  short TipoInsercion = Convert.ToInt16(TramaCampos[8]);
                //Cantidad en decimales de lo que viene de la MR
                decimal totalCantidad = CalcularFraccion(Cantidad);
                //Nos verifica si la cantidad digitada es mayor, menor o igual a la cantidad del pedido
                short verificarCantidad = OReciboCombustible.VerificarCantidad(ProductoCombustible, totalCantidad);

                ////Volvemos a guardar los datos del pedido en los diccionarios
                //if (Convert.ToInt16(TipoInsercionReciboCombuetible.REPETICION) == TipoInsercion)
                //    ConfigurarProductos(OReciboCombustible.Documento, OReciboCombustible.Placa);

                //Evaluamos si no excede la cantidad de combustible
                if (1 == 2)
                    trama = "M1*La cantidad " + Cantidad + " supera el pedido del producto " + Convert.ToString(ProductoCombustible) + "|";
                else
                {
                    //DataReader que nos definirá si es valido o no los productos en los tanques
                    IDataReader drValidar;
                    //Variable que nos va a tener la cantidad de combustible asociada al tanque actual
                    decimal cantidadEnTanque = OReciboCombustible.VerificarConfiguracionReciboCombustible(Tanque, ProductoCombustible, totalCantidad);

                    //Evaluamos si ya se tiene una configuración para ese tanque y producto
                    if (cantidadEnTanque == 0)
                        drValidar = oHelper.ValidarProductoEnTanque(Tanque, totalCantidad, ProductoCombustible);
                    else
                        drValidar = oHelper.ValidarProductoEnTanque(Tanque, cantidadEnTanque, ProductoCombustible);

                    //Verificamos si se traen datos, aunque siempre se trae al menos 1
                    if (drValidar.Read())
                    {

                        //Evaluamos si la validación es correcta
                        if (Convert.ToBoolean(drValidar["EsValido"]) == true)
                        {

                            //Agregamos la info en la Configuración del Recibo de Combustible
                            OReciboCombustible.AgregarConfiguracionReciboCombustible(Tanque, ProductoCombustible, totalCantidad, oHelper.RecuperarProductoCombustibleCodigo(ProductoCombustible));
                            oHelper.InsertarPedidoCombustibleTmp(OReciboCombustible.Documento, oHelper.RecuperarIdProductoCombustible(ProductoCombustible), Convert.ToDecimal(Cantidad), false);
                            if (TramaCampos.Length > 6)
                            {
                                trama = RecuperarProductosCombustible();
                            }
                            else
                            {
                                AlmacenarRecibocombustibleAlternoPeru();
                                trama = "M1*Pedido almacenado con exito|";
                            }
                        }
                        else
                        {
                            //Este mensaje lo devuelve el SP y se lo envíamos a la MR
                            throw new System.Exception(drValidar["Mensaje"].ToString());
                        }
                    }

                    //Cerramos el DataReader
                    drValidar.Close();
                }

            }
            catch (Exception ex)
            {
                /********************************************************************************************************/
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en Insertar Detalle Recibo Combustible", LogPropiedades, LogCategorias);
                /********************************************************************************************************/
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;
        }

        private void AlmacenarRecibocombustibleAlternoPeru()
        {
            try
            {

                //Cantidad que vamos a insertar
                decimal cantidad = 0;
                //Determina si es ley de frontera o no
                Boolean EsLeyFrontera = false;

                //Mandamos a insertar el pedido
                oHelper.InsertarPedidoCombustible(OReciboCombustible.Documento);

                //Recorremos la configuración que tenemos de los tanqueos
                for (int i = 0; i <= OReciboCombustible.lstConfiguracionRecibo.Count - 1; i++)
                {
                    //Obtenemos el valor de Ley de Frontera para ese producto
                    decimal valor = oHelper.RecuperarLeyFronteraPedidoCombustible(OReciboCombustible.Documento, OReciboCombustible.lstConfiguracionRecibo[i].CodProducto);

                    //Evaluamos que el valor sea igual a 0, osea, no tiene ley de frontera ese producto
                    if (valor == 0)
                    {
                        cantidad = OReciboCombustible.lstConfiguracionRecibo[i].Cantidad;
                        EsLeyFrontera = false;
                    }
                    else
                    {
                        //Evaluamos si la Cantidad es mayor que el valor a insertar
                        if (OReciboCombustible.lstConfiguracionRecibo[i].Cantidad > valor)
                        {
                            cantidad = valor;
                            EsLeyFrontera = true;

                            //Mandamos al kardex para que vaya a insertar el tanqueo con ley de frontera, siendo la cantidad el valor recuperado
                            Inventario.ManagementKardex.InsertarRecibodeCombustibles(cantidad, 0, OReciboCombustible.Placa, OReciboCombustible.Documento, OReciboCombustible.lstConfiguracionRecibo[i].Tanque, 0, OReciboCombustible.lstConfiguracionRecibo[i].CodProducto, EsLeyFrontera);

                            //Obtenemos la cantidad en base a la cantidad del producto en ese tanque y la variable valor
                            cantidad = OReciboCombustible.lstConfiguracionRecibo[i].Cantidad - valor;
                            EsLeyFrontera = false;
                        }
                        else
                        {
                            //Evaluamos si la Cantidad es Menor que el valor
                            if (OReciboCombustible.lstConfiguracionRecibo[i].Cantidad < valor)
                            {
                                cantidad = OReciboCombustible.lstConfiguracionRecibo[i].Cantidad;
                                EsLeyFrontera = true;
                            }
                            else
                            {
                                cantidad = valor;
                                EsLeyFrontera = true;
                            }
                        }
                    }


                    //Obtenemos el IdProducto
                    int idProducto = oHelper.RecuperarIdProductoCombustible(OReciboCombustible.lstConfiguracionRecibo[i].CodProducto);
                    //Mandamos al kardex para que vaya a insertar el tanqueo sin ley de frontera
                    Inventario.ManagementKardex.InsertarRecibodeCombustibles(cantidad, 0, OReciboCombustible.Placa, OReciboCombustible.Documento, OReciboCombustible.lstConfiguracionRecibo[i].Tanque, 0, idProducto, EsLeyFrontera);
                    //Para la impresión del ticket
                    decimal saldo = oHelper.RecuperarSaldoTanque(OReciboCombustible.lstConfiguracionRecibo[i].Tanque, Convert.ToInt16(OReciboCombustible.lstConfiguracionRecibo[i].CodProducto));
                    Inventario.ManagementKardex.ActualizarDistribucionCombustible(OReciboCombustible.Documento, OReciboCombustible.lstConfiguracionRecibo[i].Tanque, OReciboCombustible.lstConfiguracionRecibo[i].CodProducto, OReciboCombustible.lstConfiguracionRecibo[i].Cantidad, 0, OReciboCombustible.lstConfiguracionRecibo[i].Cantidad, 0);


                }
                double CantidadVentas = 0;
                string documento = OReciboCombustible.Documento;
                if (ImprimirDocumentoReciboCombustible != null)
                {
                    ImprimirDocumentoReciboCombustible(documento, CantidadVentas, Puerto);
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }


        }

        private string ObtenerTanque()
        {
            string trama = "";

            try
            {
                IDataReader lector = null;
                lector = oHelper.RecuperarTanques();
                trama = "RT";
                while (lector.Read())
                {
                    trama += "*" + lector["Codigo"].ToString() + "*" + Convert.ToInt32(Utilidades.ModificarFormatoDecimal(lector["Capacidad"].ToString().Replace(",", ".")).ToString()) + "*" + lector["Existencia"];

                }
                trama = trama + "|";
                lector.Close();
                lector.Dispose();
            }
            catch (Exception ex)
            {

                /********************************************************************************************************/
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ObtenerTanque", LogPropiedades, LogCategorias);
                /********************************************************************************************************/

                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;
        }

        private string RecibirCombustible()
        {
            return InsertarDetalleReciboCombustible();
        }

        private string AjustarInventario()
        {
            return "M1*Opcion" + (char)(0x0D) + "No Disponible|";
        }

        private string Calibrar()
        {
            string trama = "";
            bool Autorizado = false;
            try
            {
                //Datos del Empleado
                IdEmpleado = TramaCampos[1];
                Password = TramaCampos[2];
                int Manguera = 0;
                Manguera = Convert.ToInt32(TramaCampos[3]);
                byte cara = 0;
                bool EsMotivo = false;
                System.Text.StringBuilder sbStr;
                sbStr = new System.Text.StringBuilder();
                Autorizado = oHelper.ValidarCredenciales(IdEmpleado, Password);
                sbStr.Append("T"); // Datos correctos
                short idMotivo = -1;
                if (Autorizado)
                {
                    IDataReader oDatos;

                    oHelper = new Helper();

                    oDatos = oHelper.ValidarDatosCalibracion(Manguera);

                    if (oDatos.Read())
                    {
                        if (!String.IsNullOrEmpty(oDatos.GetString(oDatos.GetOrdinal("Mensaje"))))
                        {
                            trama = "M1*" + oDatos.GetString(oDatos.GetOrdinal("Mensaje")) + "|";
                        }
                        else
                        {
                            if (idMotivo == -1)
                                EsMotivo = false;
                            else
                                EsMotivo = true;

                            cara = Convert.ToByte(oDatos.GetInt16(oDatos.GetOrdinal("IdCara")));
                            trama = "M1*Peticion en proceso|";
                            //Lanzamos el evento
                            if (EnvioCalibracionCombustible != null)
                            {
                                EnvioCalibracionCombustible(cara, Manguera, idMotivo, EsMotivo, Puerto);
                            }
                        }
                    }

                }
                else
                    trama = "M1*Credenciales invalidas|";


            }
            catch (Exception ex)
            {
                /********************************************************************************************************/
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en Inicia Calibracion", LogPropiedades, LogCategorias);
                /********************************************************************************************************/

                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;

        }

        //private string EmisionDocumentoCombustible()
        //{
        //    string Cara = TramaCampos[1];
        //    string RUC = string.Empty;
        //    string TipoDocumento = "No Asignado";
        //    string CodigoFranquicia = string.Empty;
        //    string NumeroVoucher = string.Empty;
        //    string NumeroIdentificacion = string.Empty;
        //    string CodigoAutorizacion = string.Empty;
        //    string Placa = string.Empty;
        //    string FormadePago = string.Empty;
        //    string trama = string.Empty;
        //    string TipoIdentificacionCredito = string.Empty;

        //    Helper oDataAccess = new Helper();
        //    string EsContado = "";
        //    try
        //    {
        //        Cara = TramaCampos[1];

        //        if (TramaCampos.Length > 5)
        //        {
        //            FormadePago = TramaCampos[5];
        //        }

        //        EsContado = TramaCampos[2];
        //        TipoDocumento = "No Asignado";

        //        switch (TramaCampos[2])
        //        {
        //            //Ventas de contado
        //            case "1":
        //                RUC = TramaCampos[4];
        //                //Discrminación por medio de pago
        //                switch (TramaCampos[5])
        //                {
        //                    #region Impresión de venta en Efectivo
        //                    case "0":
        //                        //Valida tipo de documento a imprimirse
        //                        switch (TramaCampos[3])
        //                        {
        //                            //Impresión de Ticket Boleta
        //                            case "1":
        //                                TipoDocumento = "01";
        //                                break;

        //                            //Impresión de Ticket Factura
        //                            case "2":
        //                                TipoDocumento = "02";
        //                                break;

        //                            //Impresión de Factura Grande
        //                            case "3":
        //                                TipoDocumento = "05";
        //                                break;
        //                        }
        //                        break;
        //                    #endregion

        //                    #region Impresión de venta con Tarjeta de Crédito
        //                    case "1":
        //                        CodigoFranquicia = TramaCampos[6];
        //                        NumeroVoucher = TramaCampos[7];
        //                        //Valida tipo de documento a imprimirse
        //                        switch (TramaCampos[3])
        //                        {
        //                            //Impresión de Ticket Boleta
        //                            case "1":
        //                                TipoDocumento = "01";
        //                                break;

        //                            //Impresión de Ticket Factura
        //                            case "2":
        //                                TipoDocumento = "02";
        //                                break;

        //                            //Impresión de Factura Grande
        //                            case "3":
        //                                TipoDocumento = "05";
        //                                break;
        //                        }
        //                        break;
        //                    #endregion

        //                    #region Impresión de venta con Tarjeta Débito
        //                    case "2":
        //                        CodigoFranquicia = TramaCampos[6];

        //                        //Valida tipo de documento a imprimirse
        //                        switch (TramaCampos[3])
        //                        {
        //                            //Impresión de Ticket Boleta
        //                            case "1":
        //                                TipoDocumento = "01";
        //                                break;

        //                            //Impresión de Ticket Factura
        //                            case "2":
        //                                TipoDocumento = "02";
        //                                break;

        //                            //Impresión de Factura Grande
        //                            case "3":
        //                                TipoDocumento = "05";
        //                                break;
        //                        }
        //                        break;
        //                    #endregion

        //                    #region Impresión de venta con Tarjeta Fidelízate - Banda Magnética
        //                    case "3":
        //                        NumeroIdentificacion = TramaCampos[6];

        //                        //Valida tipo de documento a imprimirse
        //                        switch (TramaCampos[3])
        //                        {
        //                            //Impresión de Ticket Boleta
        //                            case "1":
        //                                TipoDocumento = "01";
        //                                break;

        //                            //Impresión de Ticket Factura
        //                            case "2":
        //                                TipoDocumento = "02";
        //                                break;

        //                            //Impresión de Factura Grande
        //                            case "3":
        //                                TipoDocumento = "05";
        //                                break;
        //                        }
        //                        break;
        //                    #endregion

        //                    #region Impresión de venta con Tarjeta Fidelízate - Código de Barras
        //                    case "4":
        //                        NumeroIdentificacion = TramaCampos[6];

        //                        //Valida tipo de documento a imprimirse
        //                        switch (TramaCampos[3])
        //                        {
        //                            //Impresión de Ticket Boleta
        //                            //Impresión de Ticket Boleta
        //                            case "1":
        //                                TipoDocumento = "01";
        //                                break;

        //                            //Impresión de Ticket Factura
        //                            case "2":
        //                                TipoDocumento = "02";
        //                                break;

        //                            //Impresión de Factura Grande
        //                            case "3":
        //                                TipoDocumento = "05";
        //                                break;
        //                        }
        //                        break;
        //                    #endregion

        //                    #region Impresión de venta con Tarjeta Fidelízate - Número Externo
        //                    case "5":
        //                        NumeroIdentificacion = TramaCampos[6];

        //                        //Valida tipo de documento a imprimirse
        //                        switch (TramaCampos[3])
        //                        {
        //                            //Impresión de Ticket Boleta
        //                            //Impresión de Ticket Boleta
        //                            case "1":
        //                                TipoDocumento = "01";
        //                                break;

        //                            //Impresión de Ticket Factura
        //                            case "2":
        //                                TipoDocumento = "02";
        //                                break;

        //                            //Impresión de Factura Grande
        //                            case "3":
        //                                TipoDocumento = "05";
        //                                break;
        //                        }
        //                        break;
        //                    #endregion

        //                    #region Transferencia Gratuita
        //                    case "B":


        //                        //Valida tipo de documento a imprimirse
        //                        switch (TramaCampos[3])
        //                        {
        //                            //Impresión de Ticket Boleta
        //                            //Impresión de Ticket Boleta
        //                            case "1":
        //                                TipoDocumento = "01";
        //                                break;

        //                            //Impresión de Ticket Factura
        //                            case "2":
        //                                TipoDocumento = "02";
        //                                break;

        //                            //Impresión de Factura Grande
        //                            case "3":
        //                                TipoDocumento = "05";
        //                                break;
        //                        }
        //                        break;
        //                    #endregion

        //                    #region Impresión de venta con Cheque - Placa
        //                    case "6":
        //                        CodigoAutorizacion = TramaCampos[6];
        //                        Placa = TramaCampos[7];

        //                        //Valida tipo de documento a imprimirse
        //                        switch (TramaCampos[3])
        //                        {
        //                            //Impresión de Ticket Boleta
        //                            case "1":
        //                                TipoDocumento = "Ticket Boleta";
        //                                break;

        //                            //Impresión de Ticket Factura
        //                            case "2":
        //                                TipoDocumento = "Ticket Factura";
        //                                break;

        //                            //Impresión de Factura Grande
        //                            case "3":
        //                                TipoDocumento = "Factura";
        //                                break;
        //                        }
        //                        break;
        //                    #endregion

        //                    #region Impresión de venta con Cheque - Chip
        //                    case "7":
        //                        CodigoAutorizacion = TramaCampos[6];

        //                        //Valida tipo de documento a imprimirse
        //                        switch (TramaCampos[3])
        //                        {
        //                            //Impresión de Ticket Boleta
        //                            case "1":
        //                                TipoDocumento = "Ticket Boleta";
        //                                break;

        //                            //Impresión de Ticket Factura
        //                            case "2":
        //                                TipoDocumento = "Ticket Factura";
        //                                break;

        //                            //Impresión de Factura Grande
        //                            case "3":
        //                                TipoDocumento = "Factura";
        //                                break;
        //                        }
        //                        break;
        //                    #endregion

        //                    #region Impresión de venta con Cheque - Banda Magnética
        //                    case "8":
        //                        CodigoAutorizacion = TramaCampos[6];
        //                        NumeroIdentificacion = TramaCampos[7];

        //                        //Valida tipo de documento a imprimirse
        //                        switch (TramaCampos[3])
        //                        {
        //                            //Impresión de Ticket Boleta
        //                            case "1":
        //                                TipoDocumento = "Ticket Boleta";
        //                                break;

        //                            //Impresión de Ticket Factura
        //                            case "2":
        //                                TipoDocumento = "Ticket Factura";
        //                                break;

        //                            //Impresión de Factura Grande
        //                            case "3":
        //                                TipoDocumento = "Factura";
        //                                break;
        //                        }
        //                        break;
        //                    #endregion

        //                    #region Impresión de venta con Cheque - Código de Barras
        //                    case "9":
        //                        CodigoAutorizacion = TramaCampos[6];
        //                        NumeroIdentificacion = TramaCampos[7];

        //                        //Valida tipo de documento a imprimirse
        //                        switch (TramaCampos[3])
        //                        {
        //                            //Impresión de Ticket Boleta
        //                            case "1":
        //                                TipoDocumento = "Ticket Boleta";
        //                                break;

        //                            //Impresión de Ticket Factura
        //                            case "2":
        //                                TipoDocumento = "Ticket Factura";
        //                                break;

        //                            //Impresión de Factura Grande
        //                            case "3":
        //                                TipoDocumento = "Factura";
        //                                break;
        //                        }
        //                        break;
        //                    #endregion

        //                    #region Impresión de venta con Cheque - Placa (Identificado)
        //                    case "A":
        //                        CodigoAutorizacion = TramaCampos[6];
        //                        Placa = TramaCampos[7];

        //                        //Valida tipo de documento a imprimirse
        //                        switch (TramaCampos[3])
        //                        {
        //                            //Impresión de Ticket Boleta
        //                            case "1":
        //                                TipoDocumento = "Ticket Boleta";
        //                                break;

        //                            //Impresión de Ticket Factura
        //                            case "2":
        //                                TipoDocumento = "Ticket Factura";
        //                                break;

        //                            //Impresión de Factura Grande
        //                            case "3":
        //                                TipoDocumento = "Factura";
        //                                break;
        //                        }
        //                        break;
        //                    #endregion
        //                }
        //                break;

        //            //Ventas a crédito
        //            case "2":
        //                TipoDocumento = "Vale Credito";
        //                switch (TramaCampos[3])
        //                {
        //                    #region Venta Crédito Autorización Manual
        //                    case "0":
        //                        CodigoAutorizacion = TramaCampos[4];
        //                        TipoIdentificacionCredito = "-1";
        //                        break;
        //                    #endregion

        //                    #region Venta Crédito Autorización con Chip
        //                    case "1":
        //                        TipoIdentificacionCredito = "1";
        //                        break;
        //                    #endregion

        //                    #region Venta Crédito Autorización con Banda Magnética
        //                    case "2":
        //                        NumeroIdentificacion = TramaCampos[4];
        //                        TipoIdentificacionCredito = "2";
        //                        break;
        //                    #endregion

        //                    #region Venta Crédito Autorización con Código de Barras
        //                    case "3":
        //                        NumeroIdentificacion = TramaCampos[4];
        //                        TipoIdentificacionCredito = "2";
        //                        break;
        //                    #endregion

        //                    #region Venta Crédito Autorización con Número de Tarjeta
        //                    case "4":
        //                        NumeroIdentificacion = TramaCampos[4];
        //                        TipoIdentificacionCredito = "2";
        //                        break;
        //                    #endregion

        //                    #region Venta Crédito Autorización con Vale
        //                    case "5":
        //                        NumeroIdentificacion = TramaCampos[4];
        //                        TipoIdentificacionCredito = "3";
        //                        break;
        //                    #endregion

        //                    #region Venta Crédito Autorización con Placa
        //                    case "6":
        //                        Placa = TramaCampos[4];
        //                        TipoIdentificacionCredito = "4";
        //                        break;
        //                    #endregion

        //                    #region Venta Crédito Autorización con Placa y Vale
        //                    case "7":
        //                        NumeroIdentificacion = TramaCampos[4];
        //                        Placa = TramaCampos[5];
        //                        TipoIdentificacionCredito = "5";
        //                        break;
        //                    #endregion

        //                    #region Venta Crédito Autorización con RUC
        //                    case "8":
        //                        RUC = TramaCampos[4];
        //                        TipoIdentificacionCredito = "6";
        //                        break;
        //                    #endregion

        //                    #region Venta Crédito Autorización con RUC y Banda Magnética
        //                    case "9":
        //                        RUC = TramaCampos[4];
        //                        NumeroIdentificacion = TramaCampos[5];
        //                        TipoIdentificacionCredito = "7";
        //                        break;
        //                    #endregion

        //                    #region Venta Crédito Autorización con RUC y Código de Barra
        //                    case "A":
        //                        RUC = TramaCampos[4];
        //                        NumeroIdentificacion = TramaCampos[5];
        //                        TipoIdentificacionCredito = "7";
        //                        break;
        //                    #endregion

        //                    #region Venta Crédito Autorización con RUC y Número de Tarjeta
        //                    case "B":
        //                        RUC = TramaCampos[4];
        //                        NumeroIdentificacion = TramaCampos[5];
        //                        TipoIdentificacionCredito = "7";
        //                        break;
        //                    #endregion

        //                    #region Venta Crédito Autorización con RUC y Placa
        //                    case "C":
        //                        RUC = TramaCampos[4];
        //                        Placa = TramaCampos[5];
        //                        TipoIdentificacionCredito = "8";
        //                        break;
        //                    #endregion

        //                    #region Venta Crédito Autorización con Placa y Número de Orden
        //                    case "D":
        //                        RUC = TramaCampos[4];
        //                        Placa = TramaCampos[5];
        //                        NumeroIdentificacion = TramaCampos[6];
        //                        TipoIdentificacionCredito = "9";
        //                        break;
        //                    #endregion

        //                }
        //                break;

        //            case "3":
        //                TipoDocumento = "Vale Prepago";
        //                switch (TramaCampos[3])
        //                {
        //                    #region Venta Prepago con Chip
        //                    case "1":

        //                        break;
        //                    #endregion

        //                    #region Venta Prepago con Banda Magnética
        //                    case "2":
        //                        NumeroIdentificacion = TramaCampos[4];
        //                        break;
        //                    #endregion

        //                    #region Venta Prepago con Código de Barras
        //                    case "3":
        //                        NumeroIdentificacion = TramaCampos[4];
        //                        break;
        //                    #endregion

        //                    #region Venta Prepago con Número de Tarjeta
        //                    case "4":
        //                        NumeroIdentificacion = TramaCampos[4];
        //                        break;
        //                    #endregion
        //                }
        //                break;
        //        }

        //        if ((EsContado.Equals("1")) && string.IsNullOrEmpty(NumeroIdentificacion))//Efectivo
        //        {
        //            short idformaPago = ObtenerFormaPago(FormadePago);
        //            int TipDocumento = Convert.ToInt32(TipoDocumento);


        //            if (string.IsNullOrEmpty(CodigoFranquicia.Trim()))
        //            {
        //                CodigoFranquicia = "-1";
        //                NumeroVoucher = null;
        //            }
        //            byte Caratemp = Convert.ToByte(Cara);
        //            if (PrepararTipoDocumento != null)
        //            {
        //                PrepararTipoDocumento(Caratemp, idformaPago, TipDocumento, RUC, CodigoFranquicia, NumeroVoucher);
        //            }
        //        }
        //        else if (EsContado.Equals("1") && string.IsNullOrEmpty(NumeroIdentificacion) != true)//Bono fidelizate
        //        {

        //            byte CaraTemp = Convert.ToByte(Cara);
        //            if (ValidarFormatoTarjeta(NumeroIdentificacion))
        //            {
        //                throw new Exception("La Tarjeta contiene caracteres no validos");
        //            }
        //            if (PredeterminarPagoVenta != null)
        //            {
        //                PredeterminarPagoVenta(CaraTemp, NumeroIdentificacion, Puerto);
        //            }
        //        }

        //        else if (EsContado.Equals("2"))
        //        {

        //            if (string.IsNullOrEmpty(CodigoFranquicia.Trim()))
        //            {
        //                CodigoFranquicia = "-1";
        //                NumeroVoucher = null;
        //            }

        //            byte CaraTemp = Convert.ToByte(Cara);
        //            if (TipoIdentificacionCredito.Equals("-1"))
        //            {
        //                if (AutorizarVentaManualCredito != null)
        //                {
        //                    AutorizarVentaManualCredito(CaraTemp, CodigoAutorizacion, Puerto);
        //                }
        //            }
        //            else
        //            {
        //                short TipIdentCredito = Convert.ToInt16(TipoIdentificacionCredito);
        //                if (VentaCreditoEstacion != null)
        //                {
        //                    VentaCreditoEstacion(CaraTemp, TipIdentCredito, NumeroIdentificacion, Puerto, Placa);
        //                }
        //            }


        //        }
        //        else
        //            return "M1*Opcion No" + (char)0x0D + "Disponible|";

        //    }
        //    catch (Exception ex)
        //    {

        //        LogCategorias.Clear();
        //        LogCategorias.Agregar("SeguimientoDTI");
        //        LogPropiedades.Clear();
        //        LogPropiedades.Agregar("Mensaje", ex.Message);
        //        LogIt.Loguear("Excepcion en ProcesoAnulacionDocumento", LogPropiedades, LogCategorias);
        //        Parrafo.Clear();
        //        Parrafo = Utilidades.SeccionarTexto(ex.Message);
        //        trama = "M1*";
        //        foreach (string linea in Parrafo)
        //        {
        //            trama += linea + (char)(0x0D);
        //        }
        //        trama += "|";
        //    }

        //    return "M1*Impresion" + (char)0x0D + "en proceso|";
        //}

        private string EmisionDocumentoCombustible()
        {
            byte Cara = 0;
            int TipoIdentificacionCredito = 0;
            string Identificador = string.Empty;
            string Kilometraje = "0";
            string Valor = "0";
            string trama = "";
            try
            {
                if (TramaCampos[3].Equals("1"))
                {
                    Cara = Convert.ToByte(TramaCampos[1]);
                    Valor = TramaCampos[5];
                    TipoIdentificacionCredito = Convert.ToByte(TramaCampos[4]);

                    if (TramaCampos.Length > 5)
                    {
                        Kilometraje = TramaCampos[6];
                        Identificador = "";
                    }
                    else
                    {

                        Kilometraje = TramaCampos[6];
                        Identificador = "";

                    }

                    if (VentaCreditoEstacion != null)
                    {
                        VentaCreditoEstacion(Cara, Kilometraje, Puerto, Identificador, TipoIdentificacionCredito, Valor);
                    }
                }
                else
                {
                    if (PagoEnEfectivo != null)
                    {
                        PagoEnEfectivo(Cara);
                    }
                }

                trama = "M1*Realice venta|";

            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ProcesoAnulacionDocumento", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }

            return "M1*Realice " + (char)0x0D + "la venta|";
        }

        private string ProcesoCanastilla()
        {
                 
            string CodigoFranquicia = string.Empty;
            string NumeroVoucher = string.Empty;
            string trama = "";            
            string Nit = "";
            string Placa = "";
            string codigo = "";
            double cantidad = 0;
            MedioCredito MCIdentificacion = new MedioCredito();
            ColCanastilla MCCanastilla = new ColCanastilla();
            int isla = 0;
            oFactura = new Factura();
            int j=5, y=6;
            bool band = false;

            try
            {

                if (TramaCampos[1].Equals("1"))//Ventas de canastilla
                {
                    isla = Convert.ToInt32(TramaCampos[4]);
                    if (isla == 0)
                    {
                        isla = -1;
                    }

                    switch (TramaCampos[2])
                    {
                        case "2"://Venta Efectivo
                            while (y <= TramaCampos.Length)
                            {
                                oFactura.AgregarProductoTerpel(Convert.ToInt32(TramaCampos[j]), Convert.ToInt32(TramaCampos[y]), isla);
                                y += 2;
                                j += 2;
                                band = true;
                            }

                            if (band)
                            {
                                if (Convert.ToBoolean(oHelper.RecuperarParametro("GenerarFacturaCanastillaAutomatica")))
                                {
                                    IdDocumento = oFactura.GuardarFacturaFullStation(IdEmpleado, Password, "", 0, "");
                                    Consecutivo = oHelper.RecuperarIdVentaCanastillaPorRecibo(oHelper.RecuperarReciboCanastillaPorDocumento(Convert.ToInt32(IdDocumento)));
                                }
                                else
                                {
                                    //Modificado por Medoza
                                    Consecutivo = oFactura.GuardarVentaFullstation(IdEmpleado, Password, "", 0, "", 4);

                                }


                                //Lanzamos el evento de la impresión de la factura siempre y cuando así se requiera
                                if (Convert.ToBoolean(oHelper.RecuperarParametro("GenerarFacturaCanastillaAutomatica")))
                                {
                                    string reciboCanastilla = Consecutivo.ToString();
                                    if (ImprimirFacturaCanastillaUnica != null)
                                    {
                                        ImprimirFacturaCanastillaUnica(reciboCanastilla, Puerto);
                                    }
                                }
                                else
                                {
                                    string reciboCanastilla = Consecutivo.ToString();
                                    //Lanzamos el evento de impresión del recibo
                                    if (ImprimirVentaCanastillaTerpel != null)
                                    {
                                        ImprimirVentaCanastillaTerpel(reciboCanastilla, Puerto);
                                    }
                                }
                            }
                            break;
                        case "1": //Venta Credito
                            if (TramaCampos[3].Equals("1")) //Chip
                            {
                                Cara = TramaCampos[4];
                                j = 6;
                                y = 7;

                                while (y <= TramaCampos.Length)
                                {
                                    codigo = TramaCampos[j];
                                    cantidad = Convert.ToDouble(TramaCampos[y]);
                                    y += 2;
                                    j += 2;
                                    MCCanastilla.Add(codigo, cantidad, -1, "");
                                }
                                MCIdentificacion.Cara = Convert.ToByte(Cara);
                                MCIdentificacion.NumeroIdentificacion = string.Empty;
                                MCIdentificacion.TipoIdentificacion = 1;
                                MCIdentificacion.NumeroIdentificacion = "0";
                                MCIdentificacion.NroAutorizacionManual = "0";


                            }
                            else if (TramaCampos[3].Equals("2"))//Nit Placa
                            {
                                Nit = TramaCampos[4];
                                Placa = TramaCampos[5];
                                Cara = "0";
                                j = 7;
                                y = 8;

                                while (y <= TramaCampos.Length)
                                {
                                    codigo = TramaCampos[j];
                                    cantidad = Convert.ToDouble(TramaCampos[y]);
                                    y += 2;
                                    j += 2;
                                    MCCanastilla.Add(codigo, cantidad, -1, "");
                                }
                                MCIdentificacion.Cara = Convert.ToByte(Cara);
                                MCIdentificacion.NumeroIdentificacion = Nit;
                                MCIdentificacion.TipoLectura = 1;
                                MCIdentificacion.NroSeguridad = "0";
                                MCIdentificacion.NroAutorizacionManual = Placa;
                                MCIdentificacion.TipoIdentificacion = 6;

                            }
                            else
                            { //Tarjeta


                                Cara = TramaCampos[4];
                                j = 7;
                                y = 8;

                                while (y <= TramaCampos.Length)
                                {
                                    codigo = TramaCampos[j];
                                    cantidad = Convert.ToDouble(TramaCampos[y]);
                                    y += 2;
                                    j += 2;
                                    MCCanastilla.Add(codigo, cantidad, -1, "");
                                }
                                MCIdentificacion.Cara = Convert.ToByte(Cara);
                                MCIdentificacion.NumeroIdentificacion = Nit;
                                MCIdentificacion.TipoLectura = 1;
                                MCIdentificacion.NroSeguridad = "0";
                                MCIdentificacion.NroAutorizacionManual = Placa;
                                MCIdentificacion.TipoIdentificacion = 6;

                            }

                            if (VentaCreditoCanastilla != null)
                            {
                                VentaCreditoCanastilla(MCIdentificacion, MCCanastilla, IdEmpleado, Password, Puerto);
                            }


                            break;

                        default:
                            break;

                    }


                }
                else if (TramaCampos[1].Equals("2"))//Anulacion Canastilla
                {
                    if (AnularFacturaCanastilla!=null)
                    {
                        AnularFacturaCanastilla(TramaCampos[6], TramaCampos[7], TramaCampos[4], TramaCampos[5], Puerto);
                        
                    }
                }
                trama = "M1* Peticion en proceso|";
            }
            catch (Exception ex)
            {

                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ProcesoCanastilla", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }


            return trama;
        }

        private string ProcesoAnulacionDocumento()
        {
            string trama;
            try
            {
                trama = AnulacionDocumento();
            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en ProcesoAnulacionDocumento", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }

            return trama;
        }

        private string AnulacionDocumento()
        {
            string Documento = TramaCampos[1];
            string RUC = string.Empty;
            string TipoDocumento = "No Asignado";
            string CodigoFranquicia = string.Empty;
            string NumeroVoucher = string.Empty;
            string NumeroIdentificacion = string.Empty;
            string CodigoAutorizacion = string.Empty;
            string Placa = string.Empty;
            string EsContado = string.Empty;
            string FormadePago = string.Empty;
            Helper oDataAccess = new Helper();
            string Prefijo = string.Empty;
            string Consecutivo = string.Empty;
            string recibo = string.Empty;
            EsContado = TramaCampos[2];
            FormadePago = TramaCampos[5];


            if (oDataAccess.EsPGN())
            {
                if (Tiquete.Length > 4)
                {
                    Prefijo = Tiquete.Substring(0, 4);
                    Consecutivo = Tiquete.Substring(4);
                }
                else
                    return "M1*Consecutivo" + (char)(0x0D) + "Invalido|";
            }
            else
            {
                if (Tiquete.Length > 3)
                {
                    Prefijo = Tiquete.Substring(0, 3);
                    Consecutivo = Tiquete.Substring(3);
                }
                else
                    return "M1*Consecutivo" + (char)(0x0D) + "Invalido|";

            }


            switch (TramaCampos[2])
            {
                //Ventas de contado
                case "1":
                    RUC = TramaCampos[4];
                    //Discrminación por medio de pago
                    switch (TramaCampos[5])
                    {
                        #region Impresión de venta en Efectivo
                        case "0":
                            //Valida tipo de documento a imprimirse
                            switch (TramaCampos[3])
                            {
                                //Impresión de Ticket Boleta
                                case "1":
                                    TipoDocumento = "01";
                                    break;

                                //Impresión de Ticket Factura
                                case "2":
                                    TipoDocumento = "02";
                                    break;

                                //Impresión de Factura Grande
                                case "3":
                                    TipoDocumento = "05";
                                    break;
                            }
                            break;
                        #endregion

                        #region Impresión de venta con Tarjeta de Crédito
                        case "1":
                            CodigoFranquicia = TramaCampos[6];
                            NumeroVoucher = TramaCampos[7];
                            //Valida tipo de documento a imprimirse
                            switch (TramaCampos[3])
                            {
                                //Impresión de Ticket Boleta
                                case "1":
                                    TipoDocumento = "01";
                                    break;

                                //Impresión de Ticket Factura
                                case "2":
                                    TipoDocumento = "02";
                                    break;

                                //Impresión de Factura Grande
                                case "3":
                                    TipoDocumento = "05";
                                    break;
                            }
                            break;
                        #endregion

                        #region Impresión de venta con Tarjeta Débito
                        case "2":
                            CodigoFranquicia = TramaCampos[6];

                            //Valida tipo de documento a imprimirse
                            switch (TramaCampos[3])
                            {
                                //Impresión de Ticket Boleta
                                case "1":
                                    TipoDocumento = "01";
                                    break;

                                //Impresión de Ticket Factura
                                case "2":
                                    TipoDocumento = "02";
                                    break;

                                //Impresión de Factura Grande
                                case "3":
                                    TipoDocumento = "05";
                                    break;
                            }
                            break;
                        #endregion
                        #region TransFerenciaGratuita
                        case "B":

                            //Valida tipo de documento a imprimirse
                            switch (TramaCampos[3])
                            {
                                //Impresión de Ticket Boleta
                                //Impresión de Ticket Boleta
                                case "1":
                                    TipoDocumento = "01";
                                    break;

                                //Impresión de Ticket Factura
                                case "2":
                                    TipoDocumento = "02";
                                    break;

                                //Impresión de Factura Grande
                                case "3":
                                    TipoDocumento = "05";
                                    break;
                            }
                            break;
                        #endregion

                        #region Impresión de venta con Tarjeta Fidelízate - Banda Magnética
                        case "3":
                            NumeroIdentificacion = TramaCampos[6];

                            //Valida tipo de documento a imprimirse
                            switch (TramaCampos[3])
                            {
                                //Impresión de Ticket Boleta
                                //Impresión de Ticket Boleta
                                case "1":
                                    TipoDocumento = "01";
                                    break;

                                //Impresión de Ticket Factura
                                case "2":
                                    TipoDocumento = "02";
                                    break;

                                //Impresión de Factura Grande
                                case "3":
                                    TipoDocumento = "05";
                                    break;
                            }
                            break;
                        #endregion

                        #region Impresión de venta con Tarjeta Fidelízate - Código de Barras
                        case "4":
                            NumeroIdentificacion = TramaCampos[6];

                            //Valida tipo de documento a imprimirse
                            switch (TramaCampos[3])
                            {
                                //Impresión de Ticket Boleta
                                case "1":
                                    TipoDocumento = "01";
                                    break;

                                //Impresión de Ticket Factura
                                case "2":
                                    TipoDocumento = "02";
                                    break;

                                //Impresión de Factura Grande
                                case "3":
                                    TipoDocumento = "05";
                                    break;
                            }
                            break;
                        #endregion

                        #region Impresión de venta con Tarjeta Fidelízate - Número Externo
                        case "5":
                            NumeroIdentificacion = TramaCampos[6];

                            //Valida tipo de documento a imprimirse
                            switch (TramaCampos[3])
                            {
                                //Impresión de Ticket Boleta
                                case "1":
                                    TipoDocumento = "01";
                                    break;

                                //Impresión de Ticket Factura
                                case "2":
                                    TipoDocumento = "02";
                                    break;

                                //Impresión de Factura Grande
                                case "3":
                                    TipoDocumento = "05";
                                    break;
                            }
                            break;
                        #endregion

                        #region Impresión de venta con Cheque - Placa
                        case "6":
                            CodigoAutorizacion = TramaCampos[6];
                            Placa = TramaCampos[7];

                            //Valida tipo de documento a imprimirse
                            switch (TramaCampos[3])
                            {
                                //Impresión de Ticket Boleta
                                case "1":
                                    TipoDocumento = "Ticket Boleta";
                                    break;

                                //Impresión de Ticket Factura
                                case "2":
                                    TipoDocumento = "Ticket Factura";
                                    break;

                                //Impresión de Factura Grande
                                case "3":
                                    TipoDocumento = "Factura";
                                    break;
                            }
                            break;
                        #endregion

                        #region Impresión de venta con Cheque - Chip
                        case "7":
                            CodigoAutorizacion = TramaCampos[6];

                            //Valida tipo de documento a imprimirse
                            switch (TramaCampos[3])
                            {
                                //Impresión de Ticket Boleta
                                case "1":
                                    TipoDocumento = "Ticket Boleta";
                                    break;

                                //Impresión de Ticket Factura
                                case "2":
                                    TipoDocumento = "Ticket Factura";
                                    break;

                                //Impresión de Factura Grande
                                case "3":
                                    TipoDocumento = "Factura";
                                    break;
                            }
                            break;
                        #endregion

                        #region Impresión de venta con Cheque - Banda Magnética
                        case "8":
                            CodigoAutorizacion = TramaCampos[6];
                            NumeroIdentificacion = TramaCampos[7];

                            //Valida tipo de documento a imprimirse
                            switch (TramaCampos[3])
                            {
                                //Impresión de Ticket Boleta
                                case "1":
                                    TipoDocumento = "01";
                                    break;

                                //Impresión de Ticket Factura
                                case "2":
                                    TipoDocumento = "02";
                                    break;

                                //Impresión de Factura Grande
                                case "3":
                                    TipoDocumento = "05";
                                    break;
                            }
                            break;
                        #endregion

                        #region Impresión de venta con Cheque - Código de Barras
                        case "9":
                            CodigoAutorizacion = TramaCampos[6];
                            NumeroIdentificacion = TramaCampos[7];

                            //Valida tipo de documento a imprimirse
                            switch (TramaCampos[3])
                            {
                                //Impresión de Ticket Boleta
                                case "1":
                                    TipoDocumento = "Ticket Boleta";
                                    break;

                                //Impresión de Ticket Factura
                                case "2":
                                    TipoDocumento = "Ticket Factura";
                                    break;

                                //Impresión de Factura Grande
                                case "3":
                                    TipoDocumento = "Factura";
                                    break;
                            }
                            break;
                        #endregion

                        #region Impresión de venta con Cheque - Placa (Identificado)
                        case "A":
                            CodigoAutorizacion = TramaCampos[6];
                            Placa = TramaCampos[7];

                            //Valida tipo de documento a imprimirse
                            switch (TramaCampos[3])
                            {
                                //Impresión de Ticket Boleta
                                case "1":
                                    TipoDocumento = "Ticket Boleta";
                                    break;

                                //Impresión de Ticket Factura
                                case "2":
                                    TipoDocumento = "Ticket Factura";
                                    break;

                                //Impresión de Factura Grande
                                case "3":
                                    TipoDocumento = "Factura";
                                    break;
                            }
                            break;
                        #endregion
                    }
                    break;

                //Ventas a crédito
                case "2":
                    TipoDocumento = "Vale Credito";
                    switch (TramaCampos[3])
                    {
                        #region Venta Crédito Autorización Manual
                        case "0":
                            CodigoAutorizacion = TramaCampos[4];
                            break;
                        #endregion

                        #region Venta Crédito Autorización con Chip
                        case "1":

                            break;
                        #endregion

                        #region Venta Crédito Autorización con Banda Magnética
                        case "2":
                            NumeroIdentificacion = TramaCampos[4];
                            break;
                        #endregion

                        #region Venta Crédito Autorización con Código de Barras
                        case "3":
                            NumeroIdentificacion = TramaCampos[4];
                            break;
                        #endregion

                        #region Venta Crédito Autorización con Número de Tarjeta
                        case "4":
                            NumeroIdentificacion = TramaCampos[4];
                            break;
                        #endregion

                        #region Venta Crédito Autorización con Vale
                        case "5":
                            NumeroIdentificacion = TramaCampos[4];
                            break;
                        #endregion

                        #region Venta Crédito Autorización con Placa
                        case "6":
                            Placa = TramaCampos[4];
                            break;
                        #endregion

                        #region Venta Crédito Autorización con Placa y Vale
                        case "7":
                            NumeroIdentificacion = TramaCampos[4];
                            Placa = TramaCampos[5];
                            break;
                        #endregion

                        #region Venta Crédito Autorización con RUC
                        case "8":
                            RUC = TramaCampos[4];
                            break;
                        #endregion

                        #region Venta Crédito Autorización con RUC y Banda Magnética
                        case "9":
                            RUC = TramaCampos[4];
                            NumeroIdentificacion = TramaCampos[5];
                            break;
                        #endregion

                        #region Venta Crédito Autorización con RUC y Código de Barra
                        case "A":
                            RUC = TramaCampos[4];
                            NumeroIdentificacion = TramaCampos[5];
                            break;
                        #endregion

                        #region Venta Crédito Autorización con RUC y Número de Tarjeta
                        case "B":
                            RUC = TramaCampos[4];
                            NumeroIdentificacion = TramaCampos[5];
                            break;
                        #endregion

                        #region Venta Crédito Autorización con RUC y Placa
                        case "C":
                            RUC = TramaCampos[4];
                            Placa = TramaCampos[5];
                            break;
                        #endregion

                        #region Venta Crédito Autorización con Placa y Número de Orden
                        case "D":
                            RUC = TramaCampos[4];
                            Placa = TramaCampos[5];
                            NumeroIdentificacion = TramaCampos[6];
                            break;
                        #endregion

                    }
                    break;

                case "3":
                    TipoDocumento = "Vale Prepago";
                    switch (TramaCampos[3])
                    {
                        #region Venta Prepago con Chip
                        case "1":

                            break;
                        #endregion

                        #region Venta Prepago con Banda Magnética
                        case "2":
                            NumeroIdentificacion = TramaCampos[4];
                            break;
                        #endregion

                        #region Venta Prepago con Código de Barras
                        case "3":
                            NumeroIdentificacion = TramaCampos[4];
                            break;
                        #endregion

                        #region Venta Prepago con Número de Tarjeta
                        case "4":
                            NumeroIdentificacion = TramaCampos[4];
                            break;
                        #endregion
                    }
                    break;
            }
            int TipoDocumentoanulacion = 0;
            if (EsContado.Equals("1") && string.IsNullOrEmpty(NumeroIdentificacion))//Efectivo
            {
                short idformaPago = ObtenerFormaPago(FormadePago);
                int TipDocumento = Convert.ToInt32(TipoDocumento);

                if (string.IsNullOrEmpty(CodigoFranquicia.Trim()))
                {
                    CodigoFranquicia = "-1";
                    NumeroVoucher = null;
                }

                recibo = Convert.ToString(oDataAccess.RecuperarReciboParaBonoFidelizacion(Consecutivo, Prefijo));
                TipoDocumentoanulacion = oHelper.RecuperarTipoDocumentoVenta(Convert.ToInt64(recibo));
                byte Caratemp = Convert.ToByte(oDataAccess.RecuperarCaraPorTiquete(Convert.ToInt64(recibo)));
                if (AnularDocumento != null)
                {
                    AnularDocumento(Tiquete, idformaPago, RUC, TipoDocumentoanulacion, Caratemp, CodigoFranquicia, NumeroVoucher, TipDocumento);
                }
            }
            else if (EsContado.Equals("1") && string.IsNullOrEmpty(NumeroIdentificacion) != true)//Bono fidelizate
            {

                recibo = Convert.ToString(oDataAccess.RecuperarReciboParaBonoFidelizacion(Consecutivo, Prefijo));
                if (ValidarFormatoTarjeta(NumeroIdentificacion))
                {
                    throw new Exception("La Tarjeta contiene caracteres no validos");
                }
                if (RedencionBonosFidelizacion != null)
                {
                    RedencionBonosFidelizacion(NumeroIdentificacion, recibo, Puerto);
                }
            }
            return "M1*Anulacion de Ticket " + (char)0x0D + "# " + Tiquete + (char)0x0D + "Impresion de nuevo" + (char)0x0D +
                (char)0x0D + TipoDocumento + (char)0x0D + "en proceso|";
        }


        short ObtenerFormaPago(string Valor)
        {
            short idformapago = 4;

            switch (Valor)
            {
                case "0":
                    idformapago = 4;
                    break;
                case "1":
                    idformapago = 3;
                    break;
                case "2":
                    idformapago = 5;
                    break;
                case "B":
                    idformapago = 16;
                    break;
                default:
                    break;
            }


            return idformapago;
        }

        private string ModificarVenta()
        {
            string trama = string.Empty;
            string Recibo = string.Empty;
            string[] Valores = new string[3];
            MediosPagos Pago = new MediosPagos();
            VentaModificada oModificarVenta = new VentaModificada();

            try
            {
                if (TramaCampos[1].Equals("2"))
                {
                    Valores[0] = TramaCampos[4];//Efectivo
                    Valores[1] = TramaCampos[5];//Debito
                    Valores[2] = TramaCampos[6];//Credito

                    Recibo = TramaCampos[3];
                    for (int i = 0; i < Valores.Length; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                Pago.IdFormaPago = 4;
                                Pago.NroConfirmacion = "0";
                                Pago.NroTarjeta = "";
                                Pago.Valor = Convert.ToDouble(TramaCampos[i]);
                                Pago.TipoLectura = 0;

                                if (Pago.Valor > 0)
                                {
                                    oModificarVenta.GuardarPagosGenerales(Pago);
                                }

                                break;
                            case 1:
                                Pago.IdFormaPago = 1;
                                Pago.NroConfirmacion = "0";
                                Pago.NroTarjeta = "";
                                Pago.Valor = Convert.ToDouble(TramaCampos[i]);
                                Pago.TipoLectura = 0;

                                if (Pago.Valor > 0)
                                {
                                    oModificarVenta.GuardarPagosGenerales(Pago);
                                }
                                break;
                            case 2:
                                Pago.IdFormaPago = 2;
                                Pago.NroConfirmacion = "0";
                                Pago.NroTarjeta = "";
                                Pago.Valor = Convert.ToDouble(TramaCampos[i]);
                                Pago.TipoLectura = 0;

                                if (Pago.Valor > 0)
                                {
                                    oModificarVenta.GuardarPagosGenerales(Pago);
                                }
                                break;
                            default:
                                break;
                        }
                    }

                    oHelper.EliminarMediosPago(Convert.ToInt64(Recibo));
                    oHelper.ModificarVenta(oModificarVenta);

                    if (ReimprimirDocumentoPorNumero != null)
                    {
                        ReimprimirDocumentoPorNumero(Recibo, Puerto);
                    }
                    trama = "M1*Peticion en proceso|";
                }
                else
                {


                    Valores[0] = TramaCampos[4];//Efectivo
                    Valores[1] = TramaCampos[5];//Debito
                    Valores[2] = TramaCampos[6];//Credito

                    byte caraTemp = Convert.ToByte(TramaCampos[1]);
                    if (oHelper.ExisteCara(caraTemp))
                    {
                        Recibo = oHelper.RecuperarUltimoReciboCara(Convert.ToByte(TramaCampos[1])).ToString();

                        for (int i = 0; i < Valores.Length; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    Pago.IdFormaPago = 4;
                                    Pago.NroConfirmacion = "0";
                                    Pago.NroTarjeta = "";
                                    Pago.Valor = Convert.ToDouble(TramaCampos[i]);
                                    Pago.TipoLectura = 0;

                                    if (Pago.Valor > 0)
                                    {
                                        oModificarVenta.GuardarPagosGenerales(Pago);
                                    }

                                    break;
                                case 1:
                                    Pago.IdFormaPago = 1;
                                    Pago.NroConfirmacion = "0";
                                    Pago.NroTarjeta = "";
                                    Pago.Valor = Convert.ToDouble(TramaCampos[i]);
                                    Pago.TipoLectura = 0;

                                    if (Pago.Valor > 0)
                                    {
                                        oModificarVenta.GuardarPagosGenerales(Pago);
                                    }
                                    break;
                                case 2:
                                    Pago.IdFormaPago = 2;
                                    Pago.NroConfirmacion = "0";
                                    Pago.NroTarjeta = "";
                                    Pago.Valor = Convert.ToDouble(TramaCampos[i]);
                                    Pago.TipoLectura = 0;

                                    if (Pago.Valor > 0)
                                    {
                                        oModificarVenta.GuardarPagosGenerales(Pago);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }

                        oHelper.EliminarMediosPago(Convert.ToInt64(Recibo));
                        oHelper.ModificarVenta(oModificarVenta);

                        if (ReimprimirDocumentoPorNumero != null)
                        {
                            ReimprimirDocumentoPorNumero(Recibo, Puerto);
                        }
                        trama = "M1*Peticion en proceso|";
                    }
                    else
                        throw new Exception("La cara no existe o esta inactiva");
                }

            }
            catch (Exception ex)
            {


                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en TipoTiquete", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;
        }

        public string CopiaVentas() 
        {
            string trama = "";
            string Recibo = "";
            try
            {
                if (TramaCampos[1].Equals("1"))//Efectivo
                {
                    if (TramaCampos[1].Equals("2"))//Ultima Venta
                    {
                       
                            byte caraTemp = Convert.ToByte(TramaCampos[4]);
                            if (!(oHelper.ExisteCara(caraTemp)))
                            {
                                throw new Exception("La cara no existe o esta inactiva");
                            }
                            Recibo = oHelper.RecuperarUltimoReciboCara(caraTemp).ToString();
                            if (ReimprimirDocumentoPorNumero != null)
                            {
                                ReimprimirDocumentoPorNumero(Recibo, Puerto);
                            }
                            trama = "M1*Peticion en proceso|";            
                    
                    }
                    else { //Recibo
                        Recibo = TramaCampos[4];
                        if (ReimprimirDocumentoPorNumero != null)
                        {
                            ReimprimirDocumentoPorNumero(Recibo, Puerto);
                        }
                        trama = "M1*Peticion en proceso|";
                    
                    }


                }
                else
                {
                    if (TramaCampos[1].Equals("2"))//Ultima Venta
                    {

                        byte caraTemp = Convert.ToByte(TramaCampos[4]);
                        if (!(oHelper.ExisteCara(caraTemp)))
                        {
                            throw new Exception("La cara no existe o esta inactiva");
                        }
                        Recibo = oHelper.RecuperarUltimoReciboCara(caraTemp).ToString();
                        if (ReimprimirDocumentoPorNumero != null)
                        {
                            ReimprimirDocumentoPorNumero(Recibo, Puerto);
                        }
                        trama = "M1*Peticion en proceso|";

                    }
                    else
                    { //Recibo
                        Recibo = TramaCampos[4];
                        if (ReimprimirDocumentoPorNumero != null)
                        {
                            ReimprimirDocumentoPorNumero(Recibo, Puerto);
                        }
                        trama = "M1*Peticion en proceso|";

                    }

                }

            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en CopiaVentas", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;
        }

        private string TipoTiquete()
        {
            string trama;
            bool PrefijoCuatro = false;
            Helper oDataAcces = new Helper();
            try
            {

                PrefijoCuatro = oDataAcces.EsPGN();
                if (PrefijoCuatro)
                    trama = "TT*4|";
                else
                    trama = "TT*3|";

            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en TipoTiquete", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }


            return trama;

        }

        private string ValidaExistenciaTiquete()
        {
            string Prefijo;
            string Consecutivo;
            string recibo;
            string trama = "";

            POSstation.AccesoDatos.Helper oDataAccess = new Helper();
            try
            {

                Tiquete = TramaCampos[2];
                if (TramaCampos[1] == "0")
                {
                    EsContado = false;
                    return "M1*Opcion" + (char)(0x0D) + "No Disponible|";

                    //Valida que el tiquete exista
                }
                else if (TramaCampos[1] == "1")
                {
                    EsContado = true;
                    //Valida que el vale exista
                    if (oDataAccess.EsPGN())
                    {
                        if (Tiquete.Length > 4)
                        {
                            Prefijo = Tiquete.Substring(0, 4);
                            Consecutivo = Tiquete.Substring(4);
                        }
                        else
                            return "M1*Consecutivo" + (char)(0x0D) + "Invalido|";
                    }
                    else
                    {
                        if (Tiquete.Length > 3)
                        {
                            Prefijo = Tiquete.Substring(0, 3);
                            Consecutivo = Tiquete.Substring(3);
                        }
                        else
                            return "M1*Consecutivo" + (char)(0x0D) + "Invalido|";

                    }

                    recibo = oDataAccess.RecuperarReciboParaBonoFidelizacion(Consecutivo, Prefijo).ToString();
                    trama = "VT|";
                }


            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en RecuperarReciboParaBonoFidelizacion", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }


            return trama;
        }

        private string RecuperarValorPorRecibo(string Cabecera)
        {
            string trama = "";
            try
            {
                if (Cabecera.Equals("VR"))
                {
                    long Recibo = Convert.ToInt64(TramaCampos[1]);
                    string Valor = "0";
                    Valor = oHelper.RecuperarValorPorRecibo(Recibo).ToString();
                    trama = "VR*" + Valor + "|";
                }
                else
                {

                    long Recibo = 0;
                    string Valor = "0";
                    if (!oHelper.ExisteCara(Convert.ToByte(TramaCampos[1])))
                    {
                        throw new Exception("La cara no existe o esta inactiva");
                    }
                    Recibo = oHelper.RecuperarUltimoReciboCara(Convert.ToByte(TramaCampos[1]));
                    Valor = oHelper.RecuperarValorPorRecibo(Recibo).ToString();
                    trama = "VC" + Valor + "|";
                }

            }
            catch (Exception ex)
            {
                LogCategorias.Clear();
                LogCategorias.Agregar("SeguimientoDTI");
                LogPropiedades.Clear();
                LogPropiedades.Agregar("Mensaje", ex.Message);
                LogIt.Loguear("Excepcion en RecuperarValorPorRecibo", LogPropiedades, LogCategorias);
                Parrafo.Clear();
                Parrafo = Utilidades.SeccionarTexto(ex.Message);
                trama = "M1*";
                foreach (string linea in Parrafo)
                {
                    trama += linea + (char)(0x0D);
                }
                trama += "|";
            }
            return trama;

        }

    }
}
