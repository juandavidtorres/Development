using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using System.Collections;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;
using POSstation.Fabrica;

namespace PosConfiguracion
{
    public partial class OtrosConfig : UserControl
    {
        Boolean EsGridIbuttonContruido;
        Boolean EsGridCapturadorContruido;
        Boolean EsGridRedSurtidorConstruido;
        Boolean EsGridHorarioContruido;
        Boolean EsGridImpresoraContruido;
        Boolean EsGridPuertoContruido;
        Boolean EsGridHistoricoPrecioContruido;
        Boolean EsComboCDIConstruido;
        Boolean EsComboLeyendaConstruido;
        Boolean EsGridProtocoloConstruido;

        Helper oHelper = new Helper();
        Color[] Colores = { Color.LightCyan, Color.LightGoldenrodYellow, Color.LightGray, Color.LightGreen, Color.LightPink, Color.LightSalmon, Color.LightSeaGreen, Color.LightSkyBlue, Color.LightSlateGray, Color.LightSteelBlue, Color.LightYellow, Color.LemonChiffon, Color.LightBlue, Color.LightCoral };

        public OtrosConfig()
        {
            try
            {
                InitializeComponent();
            }
            catch
            {
                throw;
            }
        }


        #region Event Handlers

        public void CargarDatos()
        {
            this.IniciarForma();
        }

        private void IniciarForma()
        {
            try
            {
                //this.Cursor = Cursors.WaitCursor;
                RecuperarCentrosDeInformacion();
                RecuperarParametros();
                RecuperarProtocolos();
                RecuperarHorarios();
                RecuperarProductos();
                RecuperarPuertos();
                RecuperarRedSurtidores();
                RecuperarRedIbutton();
                RecuperarImpresoras();

                AplicarPermisosPorAcciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AplicarPermisosPorAcciones()
        {
            try
            {
                if (frmMain.UserId.HasValue)
                {
                    if (!oHelper.ValidarPermisosPorAccion(frmMain.UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionImpresoras))
                    {
                        this.panelImpresoras.Enabled = false;
                    }

                    if (!oHelper.ValidarPermisosPorAccion(frmMain.UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionSincronizacion))
                    {
                        this.panelSincronizacion.Enabled = false;
                    }

                   

                    if (!oHelper.ValidarPermisosPorAccion(frmMain.UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionRed1wire))
                    {
                        this.grdRedLector.Enabled = false;
                    }

                    if (!oHelper.ValidarPermisosPorAccion(frmMain.UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionPuertos))
                    {
                        this.grdPuertos.Enabled = false;
                    }

                    if (!oHelper.ValidarPermisosPorAccion(frmMain.UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionHorariosdeturno))
                    {
                        this.grdHorarios.Enabled = false;
                    }

                    if (!oHelper.ValidarPermisosPorAccion(frmMain.UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionHistoricodeprecios))
                    {
                        this.grdHistoricoPrecio.Enabled = false;
                    }

                    if (!oHelper.ValidarPermisosPorAccion(frmMain.UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionProductos))
                    {
                        this.btnAdicionarProducto.Enabled = false;
                    }

                    if (!oHelper.ValidarPermisosPorAccion(frmMain.UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionReddesurtidores))
                    {
                        this.grdRedSurtidor.Enabled = false;
                    }

                    if (!oHelper.ValidarPermisosPorAccion(frmMain.UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionAutorizacionylecturadeidentificador))
                    {
                        this.panelAutorizacionLectura.Enabled = false;
                    }

                    if (!oHelper.ValidarPermisosPorAccion(frmMain.UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionServiciosweb))
                    {
                        this.panelServiciosWeb.Enabled = false;
                    }

                    if (!oHelper.ValidarPermisosPorAccion(frmMain.UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionParametrosgenerales))
                    {
                        this.panelParametrosGenerales.Enabled = false;
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

        private void RecuperarProductos()
        {
            try
            {
                DataSet data = new DataSet();
                data.Load(oHelper.RecuperarProductos(), LoadOption.Upsert, "Productos");
                this.cmbProducto.DisplayMember = "Nombre";
                this.cmbProducto.ValueMember = "IdProducto";
                this.cmbProducto.DataSource = data.Tables[0];

                if (cmbProducto.SelectedIndex != -1)
                {
                    this.RecuperarHistoricoPrecio(Int32.Parse(cmbProducto.SelectedValue.ToString()));
                }
            }
            catch
            {
                throw;
            }
        }

        private void RecuperarHistoricoPrecio(Int32 idProducto)
        {
            try
            {
                DataSet data = new DataSet();
                data.Load(oHelper.RecuperarHistoricoPrecio(idProducto), LoadOption.Upsert, "HistoricoPrecio");
                this.grdHistoricoPrecio.DataSource = data.Tables[0];
                EsGridHistoricoPrecioContruido = true;
            }
            catch
            {
                throw;
            }
        }

        private void RecuperarHorarios()
        {
            try
            {
                //this.grdHorarios.DataSource = null;
                this.grdHorarios.DataSource = oHelper.RecuperarTurnosHorario().Tables[0];
                EsGridHorarioContruido = true;
            }
            catch
            {
                throw;
            }
        }

        //private void RecuperarProtocolos()
        //{
        //    try
        //    {
        //        //this.grdProtocolos.DataSource = null;
        //        this.grdProtocolos.DataSource = oHelper.RecuperarProtocolos().Tables[0];
        //        EsGridProtocoloContruido = true;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        private void RecuperarImpresoras()
        {
            string ImpresorasInstaladas;
            for (Int32 I = 0; I <= PrinterSettings.InstalledPrinters.Count - 1; I++)
            {
                ImpresorasInstaladas = PrinterSettings.InstalledPrinters[I];
                NombreGrillaImpresora.Items.Add(ImpresorasInstaladas);
            }

            this.grdImpresoras.DataSource = oHelper.RecuperarImpresoras().Tables[0];

            EsGridImpresoraContruido = true;
        }

        private void RecuperarPuertos()
        {
            try
            {
                foreach (string strPuertos in SerialPort.GetPortNames())
                {
                    PuertoGrillaPuerto.Items.Add(strPuertos);
                }
                this.grdPuertos.DataSource = oHelper.RecuperarPuertos().Tables[0];

                EsGridPuertoContruido = true;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        private static string ToInteger(string Valor)
        {
            return Valor.Substring(0, PosicionSeparadordecimal(Valor));
        }

        private static Int32 PosicionSeparadordecimal(string Valor)
        {
            int Pos = Valor.IndexOf('.');
            if (Pos == -1)
            {
                Pos = Valor.IndexOf(',');
            }

            if (Pos == -1)
            {
                Pos = Valor.Length;
            }
            return Pos;
        }

        private void RecuperarParametros()
        {
            try
            {
                EsComboLeyendaConstruido = false;

                IDataReader dt = oHelper.RecuperarConfiguracionParametros();

                if (dt.Read())
                {

                    this.TxtCodEstacionGasoNet.Text = dt.GetValue(dt.GetOrdinal("CodigoEstacionGasoNet")).ToString();
                    this.TxtCodEstacionGasoNet.Tag = this.TxtCodEstacionGasoNet.Text;

                    this.TxtCodigoSeguridadGasoNet.Text = dt.GetValue(dt.GetOrdinal("CodigoSeguridadGasoNet")).ToString();
                    this.TxtCodigoSeguridadGasoNet.Tag = this.TxtCodigoSeguridadGasoNet.Text;

                    this.TxtUrlMenoCash.Text = dt.GetValue(dt.GetOrdinal("UrlMenoCash")).ToString();
                    this.TxtUrlMenoCash.Tag = this.TxtUrlMenoCash.Text;

                    this.TxtLlavePrivada.Text = dt.GetValue(dt.GetOrdinal("LlavePrivada")).ToString();
                    this.TxtLlavePrivada.Tag = this.TxtLlavePrivada.Text;

                    this.TxtLlavePublica.Text = dt.GetValue(dt.GetOrdinal("LlavePublica")).ToString();
                    this.TxtLlavePublica.Tag = this.TxtLlavePublica.Text;

                    this.txtintervalo.Text = dt.GetValue(dt.GetOrdinal("IntervaloConsignacion")).ToString();

                    this.TxtPasswordDataTrack.Text = dt.GetValue(dt.GetOrdinal("PasswordDataTrack")).ToString();
                    this.TxtPasswordDataTrack.Tag = this.TxtPasswordDataTrack.Text;

                    this.TxtServicioTerpel.Text = dt.GetValue(dt.GetOrdinal("ServicioTerpel")).ToString();
                    this.TxtServicioTerpel.Tag = this.TxtServicioTerpel.Text;

                    this.TxtUsuarioDataTrack.Text = dt.GetValue(dt.GetOrdinal("UsuarioDataTrack")).ToString();
                    this.TxtUsuarioDataTrack.Tag = this.TxtUsuarioDataTrack.Text;

                    this.TxtUrlDataTrack.Text = dt.GetValue(dt.GetOrdinal("UrlDataTrack")).ToString();
                    this.TxtUrlDataTrack.Tag = this.TxtUrlDataTrack.Text;

                    this.TxtDelayLISB4.Text = ToInteger(dt.GetValue(dt.GetOrdinal("DelayLSIB4")).ToString());
                    this.TxtDelayLISB4.Tag = this.TxtDelayLISB4.Text;

                    this.txtAnticipacion.Text = ToInteger(dt.GetValue(0).ToString());
                    this.txtAnticipacion.Tag = this.txtAnticipacion.Text;

                    this.txtTiempoEsperaComunicacionSoyLeal.Text = dt.GetValue(dt.GetOrdinal("TiempoEsperaComunicacionSoyLeal")).ToString();
                    this.txtTiempoEsperaComunicacionSoyLeal.Tag = this.txtTiempoEsperaComunicacionSoyLeal.Text;

                    this.txtServicioEspecializado.Text = dt.GetValue(7).ToString();
                    this.txtServicioEspecializado.Tag = this.txtServicioEspecializado.Text;

                    this.TxtServicioGeneral.Text = dt.GetValue(6).ToString();
                    this.TxtServicioGeneral.Tag = this.TxtServicioGeneral.Text;

                    this.txtServicioGasStation.Text = dt.GetValue(dt.GetOrdinal("ServicioGasStation")).ToString();
                    this.txtServicioGasStation.Tag = this.txtServicioGasStation.Text;

                    this.txtinfotaxi.Text = dt.GetValue(dt.GetOrdinal("UrlInfoTaxi")).ToString();

                    this.txtUrl.Text = dt.GetValue(dt.GetOrdinal("UrlServicio")).ToString();
                    this.txtUrl.Tag = this.txtUrl.Text;

                    this.cmbImpresora.DisplayMember = "Descripcion";
                    this.cmbImpresora.ValueMember = "IdImpresora";
                    this.cmbImpresora.DataSource = oHelper.RecuperarImpresoras().Tables[0];

                    String DefaultPrinter = dt.GetString(1);
                    this.cmbImpresora.Text = DefaultPrinter;
                    this.cmbImpresora.Tag = this.cmbImpresora.Text;

                    Boolean existe = false;
                    for (int i = 0; i < this.cmbImpresora.Items.Count; i++)
                    {
                        if (DefaultPrinter.Equals(this.cmbImpresora.Text))
                        {
                            existe = true;
                        }
                    }

                    if (!existe)
                    {
                        oHelper.ActualizarParametro("NombreImpresora", this.cmbImpresora.Text);
                    }

                    this.txtReintentos.Text = ToInteger(dt.GetValue(4).ToString());
                    this.txtReintentos.Tag = this.txtReintentos.Text;

                    this.txtRetardo.Text = ToInteger(dt.GetValue(5).ToString());
                    this.txtRetardo.Tag = this.txtRetardo.Text;

                    this.cmbFormaAutorizacion.Text = dt.GetString(2);
                    this.cmbFormaAutorizacion.Tag = this.cmbFormaAutorizacion.Text;

                    this.txtRutaBackup.Text = dt.GetValue(8).ToString();
                    this.txtRutaBackup.Tag = this.txtRutaBackup.Text;

                    if (Boolean.Parse(dt.GetString(3)))
                    {
                        this.cmbPrioridad.Text = "Remota";
                    }
                    else
                    {
                        this.cmbPrioridad.Text = "Local";
                    }
                    this.cmbPrioridad.Tag = this.cmbPrioridad.Text;


                    if (Boolean.Parse(dt.GetString(9)) & Boolean.Parse(dt.GetString(10)))
                    {
                        this.cmbEncriptacion.Text = "Todas";
                    }
                    else if (Boolean.Parse(dt.GetString(9)))
                    {
                        this.cmbEncriptacion.Text = "TwoFish";
                    }
                    else
                    {
                        this.cmbEncriptacion.Text = "Suic";
                    }
                    this.cmbEncriptacion.Tag = this.cmbEncriptacion.Text;


                    if (Boolean.Parse(dt.GetString(12)))
                    {
                        this.chkLecturaChip.Checked = true;
                    }
                    else
                    {
                        this.chkLecturaChip.Checked = false;
                    }

                    if (Boolean.Parse(dt.GetString(dt.GetOrdinal("AutorizarVentaPorConductor"))))
                    {
                        this.ChkAutorizarVentaConductor.Checked = true;
                    }
                    else
                    {
                        this.ChkAutorizarVentaConductor.Checked = false;
                    }

                    if (Boolean.Parse(dt.GetString(dt.GetOrdinal("ImprimirTopeConsignacionSobre"))))
                    {
                        this.chkImprimirTopeConsignacionSobre.Checked = true;
                    }
                    else
                    {
                        this.chkImprimirTopeConsignacionSobre.Checked = false;
                    }


                    if (Boolean.Parse(dt.GetString(dt.GetOrdinal("AplicaPagoConBonoPorNumeroTarjeta"))))
                    {
                        this.chkAplicaPagoConBonoPorNumeroTarjeta.Checked = true;
                    }
                    else
                    {
                        this.chkAplicaPagoConBonoPorNumeroTarjeta.Checked = false;
                    }

                    this.txtRutaSincronizacion.Text = dt.GetValue(13).ToString();
                    this.txtRutaSincronizacion.Tag = this.txtRutaSincronizacion.Text;

                    if (Boolean.Parse(dt.GetString(17)))
                    {
                        this.chkCierres.Checked = true;
                    }
                    else
                    {
                        this.chkCierres.Checked = false;
                    }

                    if (Boolean.Parse(dt.GetString(dt.GetOrdinal("PermitirVentasReciboComb"))))
                    {
                        this.chkVentasReciboComb.Checked = true;
                    }
                    else
                    {
                        this.chkVentasReciboComb.Checked = false;
                    }



                    if (Boolean.Parse(dt.GetString(dt.GetOrdinal("ImprimirResolucionCanastilla"))))
                    {
                        this.chkResolucion.Checked = true;
                    }
                    else
                    {
                        this.chkResolucion.Checked = false;
                    }


                    this.txtValorSobreConsig.Text = dt.GetValue(dt.GetOrdinal("ValorSobre")).ToString();
                    this.txtValorSobreConsig.Tag = this.txtValorSobreConsig.Text;

                    if (Boolean.Parse(dt.GetString(dt.GetOrdinal("AplicaConsignacionesdeSobre"))))
                    {
                        this.chkAplicarConsignacionSobres.Checked = true;
                    }
                    else
                    {
                        this.chkAplicarConsignacionSobres.Checked = false;
                    }

                    if (Boolean.Parse(dt.GetString(dt.GetOrdinal("AplicarVentaCreditoConPlaca"))))
                    {
                        this.ChkAplicaVentaCreditoPlaca.Checked = true;
                    }
                    else
                    {
                        this.ChkAplicaVentaCreditoPlaca.Checked = false;
                    }

                    if (Boolean.Parse(dt.GetString(dt.GetOrdinal("IdentificarVentasEfectivoConChip"))))
                    {
                        this.ChkIdentificarVentaEfectivoChip.Checked = true;
                    }
                    else
                    {
                        this.ChkIdentificarVentaEfectivoChip.Checked = false;
                    }

                    if (Boolean.Parse(dt.GetString(dt.GetOrdinal("BloquearManguerasVentasFueraSistema"))))
                    {
                        this.ChkBloquearManguerasVentaDueraSistema.Checked = true;
                    }
                    else
                    {
                        this.ChkBloquearManguerasVentaDueraSistema.Checked = false;
                    }

                    if (Boolean.Parse(dt.GetString(dt.GetOrdinal("AutorizarVentaLiquidoConChip"))))
                    {
                        this.ChkAutorizarVentaLiquidoChip.Checked = true;
                    }
                    else
                    {
                        this.ChkAutorizarVentaLiquidoChip.Checked = false;
                    }

                    if (Boolean.Parse(dt.GetString(dt.GetOrdinal("GenerarFacturaCanastillaAutomatica"))))
                    {
                        this.ChkGenerarFacturaCanastilla.Checked = true;
                    }
                    else
                    {
                        this.ChkGenerarFacturaCanastilla.Checked = false;
                    }

                    if (Boolean.Parse(dt.GetString(dt.GetOrdinal("AplicaDecretoEnRecibo"))))
                    {
                        this.ChkAplicaDecretoEnRecibo.Checked = true;
                    }
                    else
                    {
                        this.ChkAplicaDecretoEnRecibo.Checked = false;
                    }

                    if (Boolean.Parse(dt.GetString(dt.GetOrdinal("EsLecturaChipAutomaticaCredito"))))
                    {
                        this.ChkEsLecturaChipAutomatica.Checked = true;
                    }
                    else
                    {
                        this.ChkEsLecturaChipAutomatica.Checked = false;
                    }
                    if (Boolean.Parse(dt.GetString(dt.GetOrdinal("AplicaCierreTurnoAutomatico"))))
                    {
                        this.ChkAplicaCierreTurnoAutomatico.Checked = true;
                    }
                    else
                    {
                        this.ChkAplicaCierreTurnoAutomatico.Checked = false;
                    }
                    //DataSet FormasPago = oHelper.RecuperarFormasPago();
                    //DataRow NoFormaPago = FormasPago.Tables[0].NewRow();
                    //NoFormaPago["IdFormaPago"] = "-1";
                    //NoFormaPago["Descripcion"] = "Ninguna";
                    //FormasPago.Tables[0].Rows.InsertAt(NoFormaPago, 0);

                    //this.cmbFormaPagoDeshabilitada.DisplayMember = "Descripcion";
                    //this.cmbFormaPagoDeshabilitada.ValueMember = "IdFormaPago";
                    //this.cmbFormaPagoDeshabilitada.DataSource = FormasPago.Tables[0];
                    //this.cmbFormaPagoDeshabilitada.SelectedValue = dt.GetValue(15).ToString();
                    //this.cmbFormaPagoDeshabilitada.Tag = this.cmbFormaPagoDeshabilitada.Text;

                    this.cmbLeyendaNombreEmpleadoCanastilla.Tag = dt.GetValue(dt.GetOrdinal("LeyendaNombreEmpleadoenVentaCanastilla")).ToString();
                    this.cmbLeyendaNombreEmpleadoCanastilla.DisplayMember = "Leyenda";
                    this.cmbLeyendaNombreEmpleadoCanastilla.ValueMember = "IdLeyenda";
                    this.cmbLeyendaNombreEmpleadoCanastilla.DataSource = oHelper.RecuperarLeyendasNombreEmpleadoCanastilla().Tables[0];
                    this.cmbLeyendaNombreEmpleadoCanastilla.Text = dt.GetValue(dt.GetOrdinal("LeyendaNombreEmpleadoenVentaCanastilla")).ToString();

                    EsComboLeyendaConstruido = true;

                    if (Boolean.Parse(dt.GetString(dt.GetOrdinal("ImprimirNombreEmpleadoenVentaCanastilla"))))
                    {
                        this.chkImprimirNombreEmpleadoCanastilla.Checked = true;
                    }
                    else
                    {
                        this.chkImprimirNombreEmpleadoCanastilla.Checked = false;
                    }
                }

                IDataReader dt2 = oHelper.RecuperarConsecutivo();

                if (dt2.Read())
                {
                    this.txtConsecutivoVentas.Text = ToInteger(dt2.GetValue(1).ToString());
                    this.txtConsecutivoVentas.Tag = this.txtConsecutivoVentas.Text;
                }

                IDataReader dt3 = oHelper.RecuperarSincronizaciones(Int32.Parse(this.cmbCentros.SelectedValue.ToString()));

                if (dt3.Read())
                {
                    this.txtVentas.Text = ToInteger(dt3.GetValue(0).ToString());
                    this.txtVentas.Tag = this.txtVentas.Text;

                    this.txtLecturas.Text = ToInteger(dt3.GetValue(1).ToString());
                    this.txtLecturas.Tag = this.txtLecturas.Text;

                    this.txtGerenciamiento.Text = ToInteger(dt3.GetValue(11).ToString());
                    this.txtGerenciamiento.Tag = this.txtGerenciamiento.Text;

                    this.txtMovCanastilla.Text = ToInteger(dt3.GetValue(12).ToString());
                    this.txtMovCanastilla.Tag = this.txtMovCanastilla.Text;

                    this.txtCanastilla.Text = ToInteger(dt3.GetValue(6).ToString());
                    this.txtCanastilla.Tag = this.txtCanastilla.Text;

                    this.txtUltimoCierre.Text = dt3.GetDateTime(5).ToString("dd/MM/yyyy HH:mm");
                    this.txtUltimoCierre.Tag = this.txtUltimoCierre.Text;

                    this.txtMovCombustible.Text = ToInteger(dt3.GetValue(13).ToString());
                    this.txtMovCombustible.Tag = this.txtMovCombustible.Text;

                    this.txtModificaciones.Text = ToInteger(dt3.GetValue(14).ToString());
                    this.txtModificaciones.Tag = this.txtModificaciones.Text;

                    this.txtGanaMillones.Text = ToInteger(dt3.GetValue(8).ToString());
                    this.txtGanaMillones.Tag = this.txtGanaMillones.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecuperarProtocolos(){
   

            this.GrdProtocolo.DataSource = oHelper.RecuperarProtocolos().Tables[0];

            EsGridProtocoloConstruido = true;
        }


        private void RecuperarRedSurtidores()
            {
            //this.grdRedSurtidor.DataSource = null;
            //Grilla Surtidor

            EsGridRedSurtidorConstruido = false;
            DataGridViewComboBoxColumn ComboS = (DataGridViewComboBoxColumn)this.grdRedSurtidor.Columns["PuertoGrillaRedSurtidor"];
            ComboS.DisplayMember = "Puerto";
            ComboS.ValueMember = "IdPuerto";

            DataRow filaVacia;
            DataTable tablePuertos = oHelper.RecuperarPuertos().Tables[0];
            filaVacia = tablePuertos.NewRow();
            filaVacia["IdPuerto"] = 0;
            filaVacia["Puerto"] = " ";
            tablePuertos.Rows.Add(filaVacia);
            ComboS.DataSource = tablePuertos;

            DataGridViewComboBoxColumn ComboP = (DataGridViewComboBoxColumn)this.grdRedSurtidor.Columns["ProtocoloGrillaRedSurtidor"];
            ComboP.DisplayMember = "Nombre";
            ComboP.ValueMember = "IdProtocolo";
            ComboP.DataSource = oHelper.RecuperarProtocolos().Tables[0];

            DataGridViewComboBoxColumn ComboTipoComunicacion = (DataGridViewComboBoxColumn)this.grdRedSurtidor.Columns["TipoComunicacionGrillaRedSurtidor"];
            ComboTipoComunicacion.DisplayMember = "TipoComunicacion";
            ComboTipoComunicacion.ValueMember = "IdTipoComunicacion";
            ComboTipoComunicacion.DataSource = oHelper.RecuperarTipoComunicacionProtocolos().Tables[0];

            this.grdRedSurtidor.DataSource = oHelper.RecuperarRedSurtidores().Tables[0];

            EsGridRedSurtidorConstruido = true;
        }

  
        private void RecuperarCentrosDeInformacion()
        {
            try
            {
                this.cmbCentros.ValueMember = "IdCDC";
                this.cmbCentros.DisplayMember = "Descripcion";
                this.cmbCentros.DataSource = oHelper.RecuperarCentrosInformacion().Tables[0];
                EsComboCDIConstruido = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         

            
        }


        private static void OcultarPanel(ref System.Windows.Forms.Panel oPanel)
        {
            oPanel.Visible = false;
        }

        private static void MostrarPanel(ref System.Windows.Forms.Panel oPanel)
        {
            oPanel.Visible = true;
        }

        private void mnuOtros_Click(object sender, EventArgs e)
        {
            try
            {
                //OcultarPaneles();
                MostrarPanel(ref pnlOtros);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDelay_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Int32.Parse(txtAnticipacion.Text);
                errorProvider1.SetError(txtAnticipacion, "");
            }
            catch
            {
                errorProvider1.SetError(txtAnticipacion, "El valor debe ser un número");
            }
        }

        private void txtAnticipacion_Leave(object sender, EventArgs e)
        {
            if (txtAnticipacion.Text != txtAnticipacion.Tag.ToString())
            {
                try
                {
                    oHelper.ActualizarParametro("DeltaTurno", txtAnticipacion.Text);
                    txtAnticipacion.Tag = txtAnticipacion.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cmbImpresora_Leave(object sender, EventArgs e)
        {
            if (cmbImpresora.Text != cmbImpresora.Tag.ToString())
            {
                try
                {
                    oHelper.ActualizarParametro("NombreImpresora", cmbImpresora.Text);
                    cmbImpresora.Tag = cmbImpresora.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cmbFormaAutorizacion_Leave(object sender, EventArgs e)
        {
            if (cmbFormaAutorizacion.Text != cmbFormaAutorizacion.Tag.ToString())
            {
                try
                {
                    if (cmbFormaAutorizacion.Text == "Identificador")
                    {
                        oHelper.ActualizarParametro("SoloValidarPorBaseDeDatos", "False");
                        oHelper.ActualizarParametro("SoloValidarChip", "True");
                    }
                    else
                    {
                        oHelper.ActualizarParametro("SoloValidarPorBaseDeDatos", "True");
                        oHelper.ActualizarParametro("SoloValidarChip", "False");
                    }
                    cmbFormaAutorizacion.Tag = cmbFormaAutorizacion.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cmbPrioridad_Leave(object sender, EventArgs e)
        {
            if (cmbPrioridad.Text != cmbPrioridad.Tag.ToString())
            {
                try
                {
                    if (cmbPrioridad.Text == "Remota")
                    {
                        oHelper.ActualizarParametro("AutorizacionRemota", "True");
                    }
                    else
                    {
                        oHelper.ActualizarParametro("AutorizacionRemota", "False");
                    }
                    cmbPrioridad.Tag = cmbPrioridad.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtReintentos_Leave(object sender, EventArgs e)
        {
            try
            {
                Int32.Parse(txtReintentos.Text);
                errorProvider1.SetError(txtReintentos, "");

                if (txtReintentos.Text != txtReintentos.Tag.ToString())
                {
                    try
                    {
                        oHelper.ActualizarParametro("LecturaChipReintentos", txtReintentos.Text);
                        txtReintentos.Tag = txtReintentos.Text;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch
            {
                errorProvider1.SetError(txtReintentos, "El valor debe ser un número");
            }
        }

        private void txtRetardo_Leave(object sender, EventArgs e)
        {
            try
            {
                Int32.Parse(txtRetardo.Text);
                errorProvider1.SetError(txtRetardo, "");

                if (txtRetardo.Text != txtRetardo.Tag.ToString())
                {
                    try
                    {
                        oHelper.ActualizarParametro("LecturaChipDelay", txtRetardo.Text);
                        txtRetardo.Tag = txtRetardo.Text;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch
            {
                errorProvider1.SetError(txtRetardo, "El valor debe ser un número");
            }
        }

        private void TxtServicioGeneral_Leave(object sender, EventArgs e)
        {
            if (TxtServicioGeneral.Text != TxtServicioGeneral.Tag.ToString())
            {
                try
                {
                    oHelper.ActualizarParametro("ServicioGeneral", TxtServicioGeneral.Text);
                    TxtServicioGeneral.Tag = TxtServicioGeneral.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtServicioEspecializado_Leave(object sender, EventArgs e)
        {
            if (txtServicioEspecializado.Text != txtServicioEspecializado.Tag.ToString())
            {
                try
                {
                    oHelper.ActualizarParametro("ServicioEspecializado", txtServicioEspecializado.Text);
                    txtServicioEspecializado.Tag = txtServicioEspecializado.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //private void grdProtocolos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (EsGridProtocoloContruido)
        //        {
        //            if ((!String.IsNullOrEmpty(grdProtocolos.Rows[e.RowIndex].Cells["NombreGrillaProtocolo"].Value.ToString())) && (!String.IsNullOrEmpty(grdProtocolos.Rows[e.RowIndex].Cells["Ruta"].Value.ToString())))
        //            {
        //                if (!String.IsNullOrEmpty(grdProtocolos.Rows[e.RowIndex].Cells["IdProtocoloGrillaProtocolo"].Value.ToString()))
        //                {
        //                    oHelper.ActualizarProtocolo(Int32.Parse(grdProtocolos.Rows[e.RowIndex].Cells["IdProtocoloGrillaProtocolo"].Value.ToString()), grdProtocolos.Rows[e.RowIndex].Cells["NombreGrillaProtocolo"].Value.ToString(), grdProtocolos.Rows[e.RowIndex].Cells["Ruta"].Value.ToString());
        //                }
        //                else
        //                {
        //                    oHelper.InsertarProtocolo(grdProtocolos.Rows[e.RowIndex].Cells["NombreGrillaProtocolo"].Value.ToString(), grdProtocolos.Rows[e.RowIndex].Cells["Ruta"].Value.ToString());
        //                }
        //                RecuperarProtocolos();
        //            }
        //            else
        //            {
        //                if (grdProtocolos.ContainsFocus == false)
        //                {
        //                    RecuperarProtocolos();
        //                }
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RecuperarProtocolos();
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void grdRedLector_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (EsGridIbuttonContruido)
                {
                    if (!String.IsNullOrEmpty(grdRedLector.Rows[e.RowIndex].Cells["IdGrillaIbutton"].Value.ToString()))
                    {
                        oHelper.ActualizarOneWire(Int32.Parse(grdRedLector.Rows[e.RowIndex].Cells["IdGrillaIbutton"].Value.ToString()), grdRedLector.Rows[e.RowIndex].Cells["PuertoGrillaIbutton"].Value.ToString());
                    }
                    else
                    {
                        oHelper.InsertarOneWire(grdRedLector.Rows[e.RowIndex].Cells["PuertoGrillaIbutton"].Value.ToString());
                    }
                    RecuperarRedIbutton();
                }
            }
            catch (Exception ex)
            {
                RecuperarRedIbutton();
                MessageBox.Show(ex.Message);
            }
        }


        private void grdRedSurtidor_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (EsGridRedSurtidorConstruido)
                {
                    int tipoComunicacion = 0;
                    bool Eco = false;

                    if ((!String.IsNullOrEmpty(grdRedSurtidor.Rows[e.RowIndex].Cells["TipoComunicacionGrillaRedSurtidor"].Value.ToString())))
                    {
                        tipoComunicacion = Int32.Parse(grdRedSurtidor.Rows[e.RowIndex].Cells["TipoComunicacionGrillaRedSurtidor"].Value.ToString());
                        Eco = (String.IsNullOrEmpty(grdRedSurtidor.Rows[e.RowIndex].Cells["Eco"].Value.ToString()) ? false : Boolean.Parse(grdRedSurtidor.Rows[e.RowIndex].Cells["Eco"].Value.ToString()));
                        if (tipoComunicacion == 1)//RS232
                        {
                            EsGridRedSurtidorConstruido = false;
                            grdRedSurtidor.Rows[e.RowIndex].Cells["IpGrillaRedSurtidor"].Value = "";
                            grdRedSurtidor.Rows[e.RowIndex].Cells["PuertoTcpGrillaRedSurtidor"].Value = "";
                            EsGridRedSurtidorConstruido = true;
                            if ((String.IsNullOrEmpty(grdRedSurtidor.Rows[e.RowIndex].Cells["ProtocoloGrillaRedSurtidor"].Value.ToString())) || (String.IsNullOrEmpty(grdRedSurtidor.Rows[e.RowIndex].Cells["PuertoGrillaRedSurtidor"].Value.ToString())) || Int32.Parse(grdRedSurtidor.Rows[e.RowIndex].Cells["PuertoGrillaRedSurtidor"].Value.ToString()) <= 0)
                                return;
                        }

                        if (tipoComunicacion == 2)//TCP-IP
                        {
                            EsGridRedSurtidorConstruido = false;
                            grdRedSurtidor.Rows[e.RowIndex].Cells["PuertoGrillaRedSurtidor"].Value = 0;
                            EsGridRedSurtidorConstruido = true;
                            if ((String.IsNullOrEmpty(grdRedSurtidor.Rows[e.RowIndex].Cells["ProtocoloGrillaRedSurtidor"].Value.ToString())) || (String.IsNullOrEmpty(grdRedSurtidor.Rows[e.RowIndex].Cells["IpGrillaRedSurtidor"].Value.ToString())) || (String.IsNullOrEmpty(grdRedSurtidor.Rows[e.RowIndex].Cells["PuertoTcpGrillaRedSurtidor"].Value.ToString())) || (String.IsNullOrEmpty(grdRedSurtidor.Rows[e.RowIndex].Cells["TipoComunicacionGrillaRedSurtidor"].Value.ToString())))
                                return;
                        }

                        if (!String.IsNullOrEmpty(grdRedSurtidor.Rows[e.RowIndex].Cells["IdRed"].Value.ToString()))
                        {
                            oHelper.ActualizarRedSurtidor(Int32.Parse(grdRedSurtidor.Rows[e.RowIndex].Cells["IdRed"].Value.ToString()), Int32.Parse(grdRedSurtidor.Rows[e.RowIndex].Cells["ProtocoloGrillaRedSurtidor"].Value.ToString()), Int32.Parse(grdRedSurtidor.Rows[e.RowIndex].Cells["PuertoGrillaRedSurtidor"].Value.ToString()), Eco, grdRedSurtidor.Rows[e.RowIndex].Cells["IpGrillaRedSurtidor"].Value.ToString(), grdRedSurtidor.Rows[e.RowIndex].Cells["PuertoTcpGrillaRedSurtidor"].Value.ToString(), Int32.Parse(grdRedSurtidor.Rows[e.RowIndex].Cells["TipoComunicacionGrillaRedSurtidor"].Value.ToString()));
                        }
                        else
                        {
                            oHelper.InsertarRedSurtidor(Int32.Parse(grdRedSurtidor.Rows[e.RowIndex].Cells["ProtocoloGrillaRedSurtidor"].Value.ToString()), Int32.Parse(grdRedSurtidor.Rows[e.RowIndex].Cells["PuertoGrillaRedSurtidor"].Value.ToString()), Eco, grdRedSurtidor.Rows[e.RowIndex].Cells["IpGrillaRedSurtidor"].Value.ToString(), grdRedSurtidor.Rows[e.RowIndex].Cells["PuertoTcpGrillaRedSurtidor"].Value.ToString(), Int32.Parse(grdRedSurtidor.Rows[e.RowIndex].Cells["TipoComunicacionGrillaRedSurtidor"].Value.ToString()));
                        }
                        RecuperarRedSurtidores();
                    }
                    else
                    {
                        if (!grdRedSurtidor.ContainsFocus)
                        {
                            RecuperarRedSurtidores();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RecuperarRedSurtidores();

                MessageBox.Show(ex.Message);
                //Popup.Popup();
            }
        }

        private void grdHorarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.grdHorarios.Columns[e.ColumnIndex].Name == "HoraInicio" || this.grdHorarios.Columns[e.ColumnIndex].Name == "HoraFin")
            {
                if (e.Value != null)
                {
                    ToTime(e);
                }
            }
        }

        private static void ToTime(DataGridViewCellFormattingEventArgs formatting)
        {
            if (formatting.Value != null)
            {
                try
                {
                    System.Text.StringBuilder dateString = new System.Text.StringBuilder();
                    DateTime theTime = DateTime.Parse(formatting.Value.ToString());

                    string Temp = "0" + theTime.Hour.ToString();
                    dateString.Append(Temp.Substring(Temp.Length - 2, 2));
                    dateString.Append(":");
                    Temp = "0" + theTime.Minute.ToString();
                    dateString.Append(Temp.Substring(Temp.Length - 2, 2));

                    formatting.Value = dateString.ToString();
                    formatting.FormattingApplied = true;
                }
                catch (FormatException)
                {
                    formatting.FormattingApplied = false;
                }
            }
        }

        private void grdHorarios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (EsGridHorarioContruido)
                {
                    if ((!String.IsNullOrEmpty(grdHorarios.Rows[e.RowIndex].Cells["HoraInicio"].Value.ToString())) && (!String.IsNullOrEmpty(grdHorarios.Rows[e.RowIndex].Cells["HoraFin"].Value.ToString()))
                        && (!String.IsNullOrEmpty(grdHorarios.Rows[e.RowIndex].Cells["NumeroTurno"].Value.ToString())))
                    {
                        DateTime HoraInicial;
                        DateTime HoraFinal;
                        Int32 id;
                        Int16 numeroTurno;
                        Boolean Ajustes;                        
                        //Almaceno los horarios
                        //Almaceno los horarios
                        HoraInicial = Convert.ToDateTime("2000/01/01 " + (Convert.ToDateTime(grdHorarios.Rows[e.RowIndex].Cells["HoraInicio"].Value).ToString("HH:mm")));
                        HoraFinal = Convert.ToDateTime("2000/01/01 " + (Convert.ToDateTime(grdHorarios.Rows[e.RowIndex].Cells["HoraFin"].Value).ToString("HH:mm")));
                        numeroTurno = Convert.ToInt16(grdHorarios.Rows[e.RowIndex].Cells["NumeroTurno"].Value.ToString());

                        if (!String.IsNullOrEmpty(grdHorarios.Rows[e.RowIndex].Cells["Ajustes"].Value.ToString()))
                        {
                            Ajustes = Convert.ToBoolean(grdHorarios.Rows[e.RowIndex].Cells["Ajustes"].Value.ToString());
                        }
                        else
                        {
                            Ajustes = false;
                        }

                        if (String.IsNullOrEmpty(grdHorarios.Rows[e.RowIndex].Cells["IdTurnoHorario"].Value.ToString()))
                        {
                            id = -1;
                        }
                        else
                        {
                            id = Convert.ToInt32(grdHorarios.Rows[e.RowIndex].Cells["IdTurnoHorario"].Value.ToString());
                        }

                        oHelper.InsertarTurnoHorario(id, HoraInicial, HoraFinal, numeroTurno, Ajustes);

                      
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdHorarios_Leave(object sender, EventArgs e)
        {
            if (EsGridHorarioContruido)
            {
                grdHorarios.Tag = 1;
            }
        }

        private void grdImpresoras_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (EsGridImpresoraContruido)
                {
                    if (!String.IsNullOrEmpty(grdImpresoras.Rows[e.RowIndex].Cells["IdImpresoraGrillaImpresora"].Value.ToString()))
                    {
                        oHelper.ActualizarImpresora(Int32.Parse(grdImpresoras.Rows[e.RowIndex].Cells["IdImpresoraGrillaImpresora"].Value.ToString()), grdImpresoras.Rows[e.RowIndex].Cells["NombreGrillaImpresora"].Value.ToString());
                    }
                    else
                    {
                        oHelper.InsertarImpresora(grdImpresoras.Rows[e.RowIndex].Cells["NombreGrillaImpresora"].Value.ToString());
                    }
                    RecuperarImpresoras();
                    RecuperarParametros();
                }
            }
            catch (Exception ex)
            {
                RecuperarImpresoras();
                MessageBox.Show(ex.Message);
            }
        }

        private void txtConsecutivoVentas_Leave(object sender, EventArgs e)
        {
            try
            {
                Int32.Parse(txtConsecutivoVentas.Text);
                errorProvider1.SetError(txtConsecutivoVentas, "");

                if (txtConsecutivoVentas.Text != txtConsecutivoVentas.Tag.ToString())
                {
                    try
                    {
                        Int32 ConsecutivoVentas = Convert.ToInt32(txtConsecutivoVentas.Text);
                        oHelper.ActualizarConsecutivo("Vehiculo", ConsecutivoVentas);
                        txtConsecutivoVentas.Tag = txtConsecutivoVentas.Text;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch
            {
                errorProvider1.SetError(txtConsecutivoVentas, "El valor debe ser un número");
            }
        }

        private void btnAbrir_Leave(object sender, EventArgs e)
        {
            if (txtRutaBackup.Text != txtRutaBackup.Tag.ToString())
            {
                try
                {
                    oHelper.ActualizarParametro("RutaBackup", txtRutaBackup.Text);
                    txtRutaBackup.Tag = txtRutaBackup.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtVentas_Leave(object sender, EventArgs e)
        {
            if (txtVentas.Text != txtVentas.Tag.ToString())
            {
                try
                {
                    Int32 Ventas = Convert.ToInt32(txtVentas.Text);
                    oHelper.ActualizarSincronizacion("Ventas", Ventas.ToString(), 1);
                    txtVentas.Tag = txtVentas.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtLecturas_Leave(object sender, EventArgs e)
        {
            if (txtLecturas.Text != txtLecturas.Tag.ToString())
            {
                try
                {
                    Int32 Lecturas = Convert.ToInt32(txtLecturas.Text);
                    oHelper.ActualizarSincronizacion("Lecturas", Lecturas.ToString(), 1);
                    txtLecturas.Tag = txtLecturas.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtGerenciamiento_Leave(object sender, EventArgs e)
        {
            if (txtGerenciamiento.Text != txtGerenciamiento.Tag.ToString())
            {
                try
                {
                    Int32 Gerenciamiento = Convert.ToInt32(txtGerenciamiento.Text);
                    oHelper.ActualizarSincronizacion("Gerenciamiento", Gerenciamiento.ToString(), 1);
                    txtGerenciamiento.Tag = txtGerenciamiento.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtMovCanastilla_Leave(object sender, EventArgs e)
        {
            if (txtMovCanastilla.Text != txtMovCanastilla.Tag.ToString())
            {
                try
                {
                    Int32 MovimientosCanastilla = Convert.ToInt32(txtMovCanastilla.Text);
                    oHelper.ActualizarSincronizacion("MovimientosCanastilla", MovimientosCanastilla.ToString(), 1);
                    txtMovCanastilla.Tag = txtMovCanastilla.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtCanastilla_Leave(object sender, EventArgs e)
        {
            if (txtCanastilla.Text != txtCanastilla.Tag.ToString())
            {
                try
                {
                    Int32 VentasCanastilla = Convert.ToInt32(txtCanastilla.Text);
                    oHelper.ActualizarSincronizacion("VentasCanastilla", VentasCanastilla.ToString(), 1);
                    txtCanastilla.Tag = txtCanastilla.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void grdPuertos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (EsGridPuertoContruido)
                {
                    if (!String.IsNullOrEmpty(grdPuertos.Rows[e.RowIndex].Cells["IdPuertoGrillaPuerto"].Value.ToString()))
                    {
                        oHelper.ActualizarPuerto(Int32.Parse(grdPuertos.Rows[e.RowIndex].Cells["IdPuertoGrillaPuerto"].Value.ToString()), grdPuertos.Rows[e.RowIndex].Cells["PuertoGrillaPuerto"].Value.ToString());
                    }
                    else
                    {
                        oHelper.InsertarPuerto(grdPuertos.Rows[e.RowIndex].Cells["PuertoGrillaPuerto"].Value.ToString());
                    }
                    //RecuperarPuertos();
                    IniciarForma();
                }
            }
            catch (Exception ex)
            {
                RecuperarPuertos();
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbEncriptacion_Leave(object sender, EventArgs e)
        {
            if (cmbEncriptacion.Text != cmbEncriptacion.Tag.ToString())
            {
                try
                {
                    if (cmbEncriptacion.Text == "Todas")
                    {
                        oHelper.ActualizarParametro("TwoFish", "True");
                        oHelper.ActualizarParametro("Suic", "True");
                    }
                    else if (cmbEncriptacion.Text == "TwoFish")
                    {
                        oHelper.ActualizarParametro("TwoFish", "True");
                        oHelper.ActualizarParametro("Suic", "False");
                    }
                    else
                    {
                        oHelper.ActualizarParametro("TwoFish", "False");
                        oHelper.ActualizarParametro("Suic", "True");
                    }
                    cmbEncriptacion.Tag = cmbEncriptacion.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void grdImpresoras_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //Dejarlo para evitar mensajes de error si no existen las impresoras
        }

        private void grdPuertos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //Dejarlo para evitar mensajes de error si no existen los puertos
        }

        private void grdImpresoras_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar la impresora que se encuentra en la posición #" + (e.Row.Index + 1) + "?", "Gas Station Config Desktop®",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    oHelper.EliminarImpresora(Int32.Parse(grdImpresoras.Rows[e.Row.Index].Cells["IdImpresoraGrillaImpresora"].Value.ToString()));
                    RecuperarParametros();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show(ex.Message);
            }
        }

        private void grdPuertos_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar el puerto que se encuentra en la posición #" + (e.Row.Index + 1) + "?", "Gas Station Config Desktop®",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    oHelper.EliminarPuerto(Int32.Parse(grdPuertos.Rows[e.Row.Index].Cells["IdPuertoGrillaPuerto"].Value.ToString()));
                    RecuperarRedSurtidores();
                    RecuperarRedIbutton();
                   
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show(ex.Message);
            }
        }


        private void grdRedSurtidor_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar el registro #" + (e.Row.Index + 1) + " de la Red de Surtidores?", "Gas Station Config Desktop®",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    oHelper.EliminarRedSurtidor(Int32.Parse(grdRedSurtidor.Rows[e.Row.Index].Cells["ProtocoloGrillaRedSurtidor"].Value.ToString()), Int32.Parse(grdRedSurtidor.Rows[e.Row.Index].Cells["PuertoGrillaRedSurtidor"].Value.ToString()));
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show(ex.Message);
            }
        }

        //private void grdProtocolos_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    try
        //    {
        //        if (MessageBox.Show("¿Desea eliminar el registro #" + (e.Row.Index + 1) + " de los Protocolos?", "Gas Station Config Desktop®",
        //             MessageBoxButtons.YesNo, MessageBoxIcon.Question,
        //             MessageBoxDefaultButton.Button1) == DialogResult.Yes)
        //        {
        //            oHelper.EliminarProtocolo(Int32.Parse(grdProtocolos.Rows[e.Row.Index].Cells["IdProtocoloGrillaProtocolo"].Value.ToString()));
        //        }
        //        else
        //        {
        //            e.Cancel = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        e.Cancel = true;
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void grdRedLector_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar el puerto en la posición #" + (e.Row.Index + 1) + " de la Red 1-Wire?", "Gas Station Config Desktop®",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    oHelper.EliminarRedLector(Int32.Parse(grdRedLector.Rows[e.Row.Index].Cells["IdGrillaIbutton"].Value.ToString()));
                }
                else
                    e.Cancel = true;

            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show(ex.Message);
            }
        }

       

        private void grdHorarios_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {

                if (MessageBox.Show("¿Desea eliminar el último registro de los Horarios?", "Gas Station Config Desktop®",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    oHelper.EliminarTurnoHorario(Int32.Parse(grdHorarios.Rows[grdHorarios.NewRowIndex - 1].Cells["IdTurnoHorario"].Value.ToString()));
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show(ex.Message);
            }

        }

        private void grdHorarios_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {

            try
            {
                RecuperarHorarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdImpresoras_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                RecuperarImpresoras();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdPuertos_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                RecuperarPuertos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdRedLector_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                RecuperarRedIbutton();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void grdRedSurtidor_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                RecuperarRedSurtidores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void grdProtocolos_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        RecuperarProtocolos();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void mnuSalir_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (MessageBox.Show("¿Desea cerrar la aplicación Gas Station Config Desktop®?", "Gas Station Config Desktop®",
        //             MessageBoxButtons.YesNo, MessageBoxIcon.Question,
        //             MessageBoxDefaultButton.Button1) == DialogResult.Yes)
        //        {
        //            this.Close();
        //            this.Dispose();
        //            Application.Exit();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void grdHorarios_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Horarios (" + e.RowIndex.ToString() + ")");
        }

        private void grdCara_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Caras (" + e.RowIndex.ToString() + ")");
        }

        private void grdConfiguracion_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Configuracion (" + e.RowIndex.ToString() + ")");
        }

        private void grdEstaciones_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Estaciones (" + e.RowIndex.ToString() + ")");
        }

        private void grdIslas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Islas (" + e.RowIndex.ToString() + ")");
        }

        //private void grdProtocolos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    MessageBox.Show("Protocolos (" + e.RowIndex.ToString() + ")");
        //}

        private void grdRedCapturador_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Red Capturador (" + e.RowIndex.ToString() + ")");
        }

        private void grdRedLector_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Red Lector (" + e.RowIndex.ToString() + ")   " + e.Exception.Message);
        }

        private void grdRedSurtidor_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //MessageBox.Show("Red Surtidores (" + e.RowIndex.ToString() + ")");
        }

        private void grdSurtidores_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Surtidores (" + e.RowIndex.ToString() + ")");
        }

        private void mnuRefrescar_Click(object sender, EventArgs e)
        {
            IniciarForma();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                IniciarForma();
            }

        }

        private void chkLecturaChip_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkLecturaChip.Checked == true)
                {
                    oHelper.ActualizarParametro("ConfirmarLecturaChip", "True");
                }
                else
                {
                    oHelper.ActualizarParametro("ConfirmarLecturaChip", "False");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdHistoricoPrecio_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (EsGridHistoricoPrecioContruido)
                {
                    if ((!String.IsNullOrEmpty((String)grdHistoricoPrecio.Rows[e.RowIndex].Cells["FechaHora"].Value.ToString())) && (!String.IsNullOrEmpty((String)grdHistoricoPrecio.Rows[e.RowIndex].Cells["Precio"].Value.ToString())) && (!String.IsNullOrEmpty((String)grdHistoricoPrecio.Rows[e.RowIndex].Cells["PrecioAuxiliar"].Value.ToString())))
                    {
                        DateTime Fecha;
                        DateTime? FechaOld = null;
                        Int32 IdProducto = Int32.Parse(cmbProducto.SelectedValue.ToString());
                        Double Precio;
                        Double PrecioAuxiliar;

                        Fecha = DateTime.Parse(grdHistoricoPrecio.Rows[e.RowIndex].Cells["FechaHora"].Value.ToString());
                        Precio = Double.Parse(grdHistoricoPrecio.Rows[e.RowIndex].Cells["Precio"].Value.ToString());
                        PrecioAuxiliar = Double.Parse(grdHistoricoPrecio.Rows[e.RowIndex].Cells["PrecioAuxiliar"].Value.ToString());

                        if (FechaActual == null)
                        {
                            FechaOld = null;
                        }
                        else
                        {
                            FechaOld = DateTime.Parse(FechaActual);
                        }

                        oHelper.ActualizarHistoricoPrecio(IdProducto, FechaOld, Fecha, Precio, PrecioAuxiliar);

                        MessageBox.Show("El historico del precio ha sido actualizado satisfactoriamente");
                        //Popup.Popup();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Popup.Popup();
            }
        }

        private void grdHistoricoPrecio_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Historico Precio (" + e.RowIndex.ToString() + ")");
        }

        private void grdHistoricoPrecio_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar este precio que se encuentra en la posición #" + (e.Row.Index + 1) + "?", "Gas Station Config Desktop®",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Int32 IdProducto = Int32.Parse(cmbProducto.SelectedValue.ToString());
                    DateTime Fecha = DateTime.Parse(grdHistoricoPrecio.Rows[e.Row.Index].Cells["FechaHora"].Value.ToString());
                    oHelper.EliminarHistoricoPrecio(IdProducto, Fecha);

                    MessageBox.Show("El historico del precio ha sido eliminado satisfactoriamente");
                    //Popup.Popup();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show(ex.Message);
            }
        }
   

        String FechaActual, PrecioActual;

        private void grdHistoricoPrecio_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (grdHistoricoPrecio.IsCurrentCellInEditMode)
                {
                    if (String.IsNullOrEmpty(grdHistoricoPrecio.Rows[e.RowIndex].Cells["FechaHora"].Value.ToString()))
                    {
                        FechaActual = null;
                    }
                    else
                    {
                        FechaActual = grdHistoricoPrecio.Rows[e.RowIndex].Cells["FechaHora"].Value.ToString();
                    }

                    if (String.IsNullOrEmpty(grdHistoricoPrecio.Rows[e.RowIndex].Cells["Precio"].Value.ToString()))
                    {
                        PrecioActual = null;
                    }
                    else
                    {
                        PrecioActual = grdHistoricoPrecio.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
                    }

                    if (grdHistoricoPrecio.Columns[e.ColumnIndex].Name == "FechaHora")
                    {
                        if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            MessageBox.Show("La fecha no puede ser vacía");
                            //Popup.Popup();
                            e.Cancel = true;
                        }
                        else
                        {
                            DateTime Fecha;
                            if (!DateTime.TryParse(e.FormattedValue.ToString(), out Fecha))
                            {
                                MessageBox.Show("La fecha no tiene el formato correcto");
                                //Popup.Popup();
                                e.Cancel = true;
                            }
                        }

                        if (!e.Cancel)
                        {
                            DateTime Fecha, FechaTemp;
                            Boolean Existe = false;

                            Fecha = DateTime.Parse(e.FormattedValue.ToString());

                            for (Int32 I = 0; I < grdHistoricoPrecio.Rows.Count - 1; I++)
                            {
                                if (!String.IsNullOrEmpty(grdHistoricoPrecio.Rows[I].Cells["FechaHora"].Value.ToString()))
                                {
                                    FechaTemp = DateTime.Parse(grdHistoricoPrecio.Rows[I].Cells["FechaHora"].Value.ToString());
                                    if (Fecha == FechaTemp)
                                    {
                                        Existe = true;
                                    }
                                }
                            }

                            if (Existe)
                            {
                                e.Cancel = true;
                                throw new GasolutionsException("La fecha ya ha sido ingresada al historico de precio de este producto");
                            }
                        }
                    }

                    if (grdHistoricoPrecio.Columns[e.ColumnIndex].Name == "Precio")
                    {
                        if (!String.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            Double Temp = 0;
                            if (!Double.TryParse(e.FormattedValue.ToString(), out Temp))
                            {
                                MessageBox.Show("El precio debe ser un número");
                                //Popup.Popup();
                                e.Cancel = true;
                            }
                            else
                            {
                                if (Temp <= 0)
                                {
                                    MessageBox.Show("El precio debe ser un número mayor que cero");
                                    //Popup.Popup();
                                    e.Cancel = true;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("El precio no puede ser vacio");
                            //Popup.Popup();
                            e.Cancel = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Popup.Popup();
            }
        }

        private void grdRedSurtidor_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (this.grdRedSurtidor.IsCurrentCellInEditMode)
                {
                    if (grdRedSurtidor.Columns[e.ColumnIndex].Name == "CaraInicial")
                    {
                        if (!String.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            Double Temp = 0;
                            if (!Double.TryParse(e.FormattedValue.ToString(), out Temp))
                            {
                                MessageBox.Show("La cara inicial debe ser un número");
                                //Popup.Popup();
                                e.Cancel = true;
                            }
                            else
                            {
                                if (Temp <= 0)
                                {
                                    MessageBox.Show("La cara inicial debe ser un número mayor que cero");
                                    //Popup.Popup();
                                    e.Cancel = true;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("La cara inicial no puede ser vacia");
                            //Popup.Popup();
                            e.Cancel = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Popup.Popup();
            }
        }

        private void txtMovCombustible_Leave(object sender, EventArgs e)
        {
            if (txtMovCombustible.Text != txtMovCombustible.Tag.ToString())
            {
                try
                {
                    if (!String.IsNullOrEmpty(txtMovCombustible.Text))
                    {
                        Int32 MovimientoKardex = 0;
                        if (Int32.TryParse(txtMovCombustible.Text, out MovimientoKardex))
                        {
                            oHelper.ActualizarSincronizacion("MovimientoKardex", MovimientoKardex.ToString(), 1);
                            txtMovCombustible.Tag = txtMovCombustible.Text;
                        }
                        else
                        {
                            MessageBox.Show("El numero debe ser un entero");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //Popup.Popup();
                }
            }
        }

        private void txtUltimoCierre_Leave(object sender, EventArgs e)
        {
            if (txtUltimoCierre.Text != txtUltimoCierre.Tag.ToString())
            {
                try
                {
                    if (String.IsNullOrEmpty(txtUltimoCierre.Text))
                    {
                        MessageBox.Show("La fecha del ultimo cierre no puede ser vacía");
                        //Popup.Popup();
                    }
                    else
                    {
                        DateTime UltimoCierre;
                        if (!DateTime.TryParse(txtUltimoCierre.Text, out UltimoCierre))
                        {
                            MessageBox.Show("La fecha del ultimo cierre no tiene el formato correcto");
                            //Popup.Popup();
                        }
                        else
                        {
                            oHelper.ActualizarSincronizacion("UltimoCierre", UltimoCierre.ToString("yyyyMMdd HH:mm"), 1);
                            txtUltimoCierre.Tag = txtUltimoCierre.Text;

                            MessageBox.Show("La fecha de ultimo cierre se actualizó satisfactoriamente");
                            //Popup.Popup();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //Popup.Popup();
                }
            }
        }


        private void txtModificaciones_Leave(object sender, EventArgs e)
        {
            if (txtModificaciones.Text != txtModificaciones.Tag.ToString())
            {
                try
                {
                    if (!String.IsNullOrEmpty(txtModificaciones.Text))
                    {
                        Int32 VentaModificada = 0;
                        if (Int32.TryParse(txtModificaciones.Text, out VentaModificada))
                        {
                            oHelper.ActualizarSincronizacion("VentaModificada", VentaModificada.ToString(), 1);
                            txtModificaciones.Tag = txtModificaciones.Text;
                        }
                        else
                        {
                            MessageBox.Show("El numero debe ser un entero");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //Popup.Popup();
                }
            }
        }

        private void btnAbrirRutaSincronizacion_Leave(object sender, EventArgs e)
        {
            if (txtRutaSincronizacion.Text != txtRutaSincronizacion.Tag.ToString())
            {
                try
                {
                    oHelper.ActualizarParametro("CarpetaSincronizacion", txtRutaSincronizacion.Text);
                    txtRutaSincronizacion.Tag = txtRutaSincronizacion.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //Popup.Popup();
                }
            }
        }

        private void txtGanaMillones_Leave(object sender, EventArgs e)
        {
            if (txtGanaMillones.Text != txtGanaMillones.Tag.ToString())
            {
                try
                {
                    if (!String.IsNullOrEmpty(txtGanaMillones.Text))
                    {
                        Int32 GanaMillones = 0;
                        if (!Int32.TryParse(txtGanaMillones.Text, out GanaMillones))
                        {
                            MessageBox.Show("El contador de las ventas con gana millones debe ser un número");
                            //Popup.Popup();
                        }
                        else
                        {
                            if (GanaMillones < 0)
                            {
                                MessageBox.Show("El contador de las ventas con gana millones debe ser un número mayor o igual que cero");
                                //Popup.Popup();
                            }
                            else
                            {
                                oHelper.ActualizarSincronizacion("VentasNumero", GanaMillones.ToString(), 1);
                                txtGanaMillones.Tag = txtGanaMillones.Text;

                                MessageBox.Show("El contador de las ventas con gana millones se actualizó satisfactoriamente");
                                //Popup.Popup();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El contador de las ventas con gana millones no puede ser vacio");
                        //Popup.Popup();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //Popup.Popup();
                }
            }
        }

        private void grdPuertos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            bfAbrir.Description = "Seleccione la carpeta donde se creará el archivo de Backup";
            bfAbrir.RootFolder = Environment.SpecialFolder.MyComputer;
            bfAbrir.ShowNewFolderButton = true;
            bfAbrir.SelectedPath = txtRutaBackup.Text;
            bfAbrir.ShowDialog();

            txtRutaBackup.Text = bfAbrir.SelectedPath;
        }

        private void btnAbrirRutaSincronizacion_Click(object sender, EventArgs e)
        {
            bfAbrir.Description = "Seleccione la carpeta donde se creará el archivo de Sincronización";
            bfAbrir.RootFolder = Environment.SpecialFolder.MyComputer;
            bfAbrir.ShowNewFolderButton = true;
            bfAbrir.SelectedPath = txtRutaSincronizacion.Text;
            bfAbrir.ShowDialog();

            txtRutaSincronizacion.Text = bfAbrir.SelectedPath;
        }

        private void chkCierres_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCierres.Checked == true)
                {
                    oHelper.ActualizarParametro("CierreDetallado", "True");
                }
                else
                {
                    oHelper.ActualizarParametro("CierreDetallado", "False");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public event EventHandler MostrarProductos;
        private void btnAdicionarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarProductos(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkVentasReciboComb_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkVentasReciboComb.Checked == true)
                {
                    oHelper.ActualizarParametro("PermitirVentasReciboComb", "True");
                }
                else
                {
                    oHelper.ActualizarParametro("PermitirVentasReciboComb", "False");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtValorSobreConsig_Leave(object sender, EventArgs e)
        {
            if (txtValorSobreConsig.Text != txtValorSobreConsig.Tag.ToString())
            {
                try
                {
                    if (!String.IsNullOrEmpty(txtValorSobreConsig.Text))
                    {
                        Int32 ValorSobreConsig = 0;
                        if (!Int32.TryParse(txtValorSobreConsig.Text, out ValorSobreConsig))
                        {
                            MessageBox.Show("El valor del sobre debe ser un número");
                        }
                        else
                        {
                            if (ValorSobreConsig <= 0)
                            {
                                MessageBox.Show("El valor del sobre debe ser un número mayor que cero");
                            }
                            else
                            {
                                oHelper.ActualizarParametro("ValorSobre", ValorSobreConsig.ToString());
                                txtValorSobreConsig.Tag = txtValorSobreConsig.Text;

                                MessageBox.Show("El valor del sobre se actualizó satisfactoriamente");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El valor del sobre no puede ser vacio");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } 
        }

        private void chkAplicarConsignacionSobres_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAplicarConsignacionSobres.Checked == true)
                {
                    oHelper.ActualizarParametro("AplicaConsignacionesdeSobre", "True");
                }
                else
                {
                    oHelper.ActualizarParametro("AplicaConsignacionesdeSobre", "False");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtServicioGasStation_Leave(object sender, EventArgs e)
        {
            if (txtServicioGasStation.Text != txtServicioGasStation.Tag.ToString())
            {
                try
                {
                    oHelper.ActualizarParametro("ServicioGasStation", txtServicioGasStation.Text);
                    txtServicioGasStation.Tag = txtServicioGasStation.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void chkResolucion_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkResolucion.Checked == true)
                {
                    oHelper.ActualizarParametro("ImprimirResolucionCanastilla", "True");
                }
                else
                {        
                    oHelper.ActualizarParametro("ImprimirResolucionCanastilla", "False");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtRutaBackup_Leave(object sender, EventArgs e)
        {
            if (txtRutaBackup.Text != txtRutaBackup.Tag.ToString())
            {
                try
                {
                    oHelper.ActualizarParametro("RutaBackup", txtRutaBackup.Text);
                    txtRutaBackup.Tag = txtRutaBackup.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtRutaSincronizacion_Leave(object sender, EventArgs e)
        {
            if (txtRutaSincronizacion.Text != txtRutaSincronizacion.Tag.ToString())
            {
                try
                {
                    oHelper.ActualizarParametro("CarpetaSincronizacion", txtRutaSincronizacion.Text);
                    txtRutaSincronizacion.Tag = txtRutaSincronizacion.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //Popup.Popup();
                }
            }
        }

        private void cmbCentros_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (EsComboCDIConstruido)
                {
                    IDataReader dt3 = oHelper.RecuperarSincronizaciones(Int32.Parse(this.cmbCentros.SelectedValue.ToString()));

                    if (dt3.Read())
                    {
                        this.txtVentas.Text = ToInteger(dt3.GetValue(0).ToString());
                        this.txtVentas.Tag = this.txtVentas.Text;

                        this.txtLecturas.Text = ToInteger(dt3.GetValue(1).ToString());
                        this.txtLecturas.Tag = this.txtLecturas.Text;

                        this.txtGerenciamiento.Text = ToInteger(dt3.GetValue(11).ToString());
                        this.txtGerenciamiento.Tag = this.txtGerenciamiento.Text;

                        this.txtMovCanastilla.Text = ToInteger(dt3.GetValue(12).ToString());
                        this.txtMovCanastilla.Tag = this.txtMovCanastilla.Text;

                        this.txtCanastilla.Text = ToInteger(dt3.GetValue(6).ToString());
                        this.txtCanastilla.Tag = this.txtCanastilla.Text;

                        this.txtUltimoCierre.Text = dt3.GetDateTime(5).ToString("dd/MM/yyyy HH:mm");
                        this.txtUltimoCierre.Tag = this.txtUltimoCierre.Text;

                        this.txtMovCombustible.Text = ToInteger(dt3.GetValue(13).ToString());
                        this.txtMovCombustible.Tag = this.txtMovCombustible.Text;

                        this.txtModificaciones.Text = ToInteger(dt3.GetValue(14).ToString());
                        this.txtModificaciones.Tag = this.txtModificaciones.Text;

                        this.txtGanaMillones.Text = ToInteger(dt3.GetValue(8).ToString());
                        this.txtGanaMillones.Tag = this.txtGanaMillones.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Popup.Popup();
            }
        }

        private void chkImprimirNombreEmpleadoCanastilla_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkImprimirNombreEmpleadoCanastilla.Checked)
                {
                    oHelper.ActualizarParametro("ImprimirNombreEmpleadoenVentaCanastilla", "True");
                }
                else
                {
                    oHelper.ActualizarParametro("ImprimirNombreEmpleadoenVentaCanastilla", "False");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbLeyendaNombreEmpleadoCanastilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbLeyendaNombreEmpleadoCanastilla.SelectedIndex != -1 && EsComboLeyendaConstruido)
                {
                    if (this.cmbLeyendaNombreEmpleadoCanastilla.Tag.ToString() != this.cmbLeyendaNombreEmpleadoCanastilla.Text)
                    {
                        oHelper.ActualizarParametro("LeyendaNombreEmpleadoenVentaCanastilla", cmbLeyendaNombreEmpleadoCanastilla.Text);
                        this.cmbLeyendaNombreEmpleadoCanastilla.Tag = this.cmbLeyendaNombreEmpleadoCanastilla.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OtrosConfig_Load(object sender, EventArgs e)
        {

        }


        private void txtUrl_Leave(object sender, EventArgs e)
        {
            if (txtUrl.Text != txtUrl.Tag.ToString())
            {
                try
                {
                    oHelper.ActualizarParametro("URLServicio", txtUrl.Text);
                    txtUrl.Tag = txtUrl.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ChkAutorizarVentaConductor_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkAutorizarVentaConductor.Checked)
                {
                    oHelper.ActualizarParametro("AutorizarVentaPorConductor", "True");
                }
                else
                {
                    oHelper.ActualizarParametro("AutorizarVentaPorConductor", "False");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkImprimirTopeConsignacionSobre_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkImprimirTopeConsignacionSobre.Checked)
                {
                    oHelper.ActualizarParametro("ImprimirTopeConsignacion", "True");
                }
                else
                {
                    oHelper.ActualizarParametro("ImprimirTopeConsignacion", "False");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecuperarPuertosOneWire()
        {
            if (this.grdRedLector != null)
            {
                DataGridViewComboBoxColumn ComboPL = (DataGridViewComboBoxColumn)this.grdRedLector.Columns["PuertoGrillaIbutton"];

                if (ComboPL != null)
                {
                    ComboPL.DisplayMember = "Puerto";
                    ComboPL.ValueMember = "Puerto";
                    ComboPL.DataSource = oHelper.RecuperarPuertos().Tables[0];
                }
            }
        }

        private void RecuperarRedIbutton()
        {
            if (this.grdRedLector != null)
            {
                RecuperarPuertosOneWire();
                this.grdRedLector.DataSource = oHelper.RecuperarRedLectores().Tables[0];
                EsGridIbuttonContruido = true;
            }

        }


        private void grdRedLector_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.grdRedLector != null && e.RowIndex >= 0)
                {
                    if (!String.IsNullOrEmpty(grdRedLector.Rows[e.RowIndex].Cells["IdGrillaIbutton"].Value.ToString()))
                    {
                        oHelper.ActualizarOneWire(Int32.Parse(grdRedLector.Rows[e.RowIndex].Cells["IdGrillaIbutton"].Value.ToString()), grdRedLector.Rows[e.RowIndex].Cells["PuertoGrillaIbutton"].Value.ToString());
                    }
                    else
                    {
                        oHelper.InsertarOneWire(grdRedLector.Rows[e.RowIndex].Cells["PuertoGrillaIbutton"].Value.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                RecuperarRedIbutton();
            }
        }

        private void grdImpresoras_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void grdRedLector_UserDeletedRow_1(object sender, DataGridViewRowEventArgs e)
        {
            RecuperarRedIbutton();
        }

        private void grdRedSurtidor_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void chkAplicaPagoConBonoPorNumeroTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAplicaPagoConBonoPorNumeroTarjeta.Checked)
                {
                    oHelper.ActualizarParametro("AplicaPagoConBonoPorNumeroTarjeta", "True");
                }
                else
                {
                    oHelper.ActualizarParametro("AplicaPagoConBonoPorNumeroTarjeta", "False");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTiempoEsperaComunicacionSoyLeal_Leave(object sender, EventArgs e)
        {
            if (txtTiempoEsperaComunicacionSoyLeal.Text != txtTiempoEsperaComunicacionSoyLeal.Tag.ToString())
            {
                try
                {
                    oHelper.ActualizarParametro("TiempoEsperaComunicacionSoyLeal", txtTiempoEsperaComunicacionSoyLeal.Text);
                    txtTiempoEsperaComunicacionSoyLeal.Tag = txtTiempoEsperaComunicacionSoyLeal.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ChkAplicaVentaCreditoPlaca_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkAplicaVentaCreditoPlaca.Checked == true)
                {
                    oHelper.ActualizarParametro("AplicarVentaCreditoConPlaca", "True");
                }
                else
                {
                    oHelper.ActualizarParametro("AplicarVentaCreditoConPlaca", "False");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChkIdentificarVentaEfectivoChip_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkIdentificarVentaEfectivoChip.Checked == true)
                {
                    oHelper.ActualizarParametro("IdentificarVentasEfectivoConChip", "True");
                }
                else
                {
                    oHelper.ActualizarParametro("IdentificarVentasEfectivoConChip", "False");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChkBloquearManguerasVentaDueraSistema_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkBloquearManguerasVentaDueraSistema.Checked == true)
                {
                    oHelper.ActualizarParametro("BloquearManguerasVentasFueraSistema", "True");
                }
                else
                {
                    oHelper.ActualizarParametro("BloquearManguerasVentasFueraSistema", "False");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChkAutorizarVentaLiquidoChip_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkAutorizarVentaLiquidoChip.Checked == true)
                {
                    oHelper.ActualizarParametro("AutorizarVentaLiquidoConChip", "True");
                }
                else
                {
                    oHelper.ActualizarParametro("AutorizarVentaLiquidoConChip", "False");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChkGenerarFacturaCanastilla_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkGenerarFacturaCanastilla.Checked == true)
                {
                    oHelper.ActualizarParametro("GenerarFacturaCanastillaAutomatica", "True");
                }
                else
                {
                    oHelper.ActualizarParametro("GenerarFacturaCanastillaAutomatica", "False");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChkAplicaDecretoEnRecibo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkAplicaDecretoEnRecibo.Checked == true)
                {
                    oHelper.ActualizarParametro("AplicaDecretoEnRecibo", "True");
                }
                else
                {
                    oHelper.ActualizarParametro("AplicaDecretoEnRecibo", "False");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChkEsLecturaChipAutomatica_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkEsLecturaChipAutomatica.Checked == true)
                {
                    oHelper.ActualizarParametro("EsLecturaChipAutomaticaCredito", "True");
                }
                else
                {
                    oHelper.ActualizarParametro("EsLecturaChipAutomaticaCredito", "False");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TxtDelayLISB4_Leave(object sender, EventArgs e)
        {
            if (TxtDelayLISB4.Text != TxtDelayLISB4.Tag.ToString())
            {
                try
                {
                    if (!String.IsNullOrEmpty(TxtDelayLISB4.Text))
                    {
                        Int32 ValorDelayLISB4 = 0;
                        if (!Int32.TryParse(TxtDelayLISB4.Text, out ValorDelayLISB4))
                        {
                            MessageBox.Show("El valor del sobre debe ser un número");
                        }
                        else
                        {
                            if (ValorDelayLISB4 <= 0)
                            {
                                MessageBox.Show("El valor del sobre debe ser un número mayor que cero");
                            }
                            else
                            {
                                oHelper.ActualizarParametro("DelayLSIB4", ValorDelayLISB4.ToString());
                                TxtDelayLISB4.Tag = TxtDelayLISB4.Text;

                                MessageBox.Show("El valor DelayLISB4 se actualizó satisfactoriamente");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El valor DelayLISB4 no puede ser vacio");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } 
        }

        private void GrdProtocolo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (EsGridProtocoloConstruido)
                {
                    if ((!String.IsNullOrEmpty((String)GrdProtocolo.Rows[e.RowIndex].Cells["Nombre"].Value.ToString())) && (!String.IsNullOrEmpty((String)GrdProtocolo.Rows[e.RowIndex].Cells["RutaLibreria"].Value.ToString())))
                    {
                        String Protocolo;
                        String Ruta;
                        Int32 IdProtocolo;

                        Protocolo = GrdProtocolo.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                        Ruta = GrdProtocolo.Rows[e.RowIndex].Cells["RutaLibreria"].Value.ToString();
                        IdProtocolo = Int32.Parse(GrdProtocolo.Rows[e.RowIndex].Cells["IdProtocolo"].Value.ToString());

                        oHelper.ActualizarProtocolo(IdProtocolo, Protocolo, Ruta);

                        MessageBox.Show("El protocolo ha sido actualizado satisfactoriamente");
                        //Popup.Popup();
                    }
                    else
                    {
                        oHelper.InsertarProtocolo(GrdProtocolo.Rows[e.RowIndex].Cells["Nombre"].Value.ToString(), GrdProtocolo.Rows[e.RowIndex].Cells["RutaLibreria"].Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Popup.Popup();
            }
        }

        private void GrdProtocolo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Protocolo (" + e.RowIndex.ToString() + ")   " + e.Exception.Message);
        }

        private void GrdProtocolo_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar el registro #" + (e.Row.Index + 1) + " de los protocolos?", "Gas Station Config Desktop®",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    oHelper.EliminarProtocolo(Int32.Parse(GrdProtocolo.Rows[e.Row.Index].Cells["IdProtocolo"].Value.ToString()));
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show(ex.Message);
            }
        }

        private void GrdProtocolo_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                RecuperarProtocolos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TxtUrlDataTrack_Leave(object sender, EventArgs e)
        {
            if (TxtUrlDataTrack.Text != TxtUrlDataTrack.Tag.ToString())
            {
                try
                {
                    oHelper.ActualizarParametro("UrlDataTrack", TxtUrlDataTrack.Text);
                    TxtUrlDataTrack.Tag = TxtUrlDataTrack.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void TxtUsuarioDataTrack_Leave(object sender, EventArgs e)
        {
            if (TxtUsuarioDataTrack.Text != TxtUsuarioDataTrack.Tag.ToString())
            {
                try
                {
                    oHelper.ActualizarParametro("UsuarioDataTrack", TxtUsuarioDataTrack.Text);
                    TxtUsuarioDataTrack.Tag = TxtUsuarioDataTrack.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void TxtPasswordDataTrack_Leave(object sender, EventArgs e)
        {
            if (TxtPasswordDataTrack.Text != TxtPasswordDataTrack.Tag.ToString())
            {
                try
                {
                    oHelper.ActualizarParametro("PasswordDataTrack", TxtPasswordDataTrack.Text);
                    TxtPasswordDataTrack.Tag = TxtPasswordDataTrack.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cmbCentros_Leave(object sender, EventArgs e)
        {

        }

        private void cmbProducto_TextChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex != -1)
            {
                this.RecuperarHistoricoPrecio(Int32.Parse(cmbProducto.SelectedValue.ToString()));
            }
        }

        private void TxtServicioTerpel_Leave(object sender, EventArgs e)
        {
            if (TxtServicioTerpel.Text != TxtServicioTerpel.Tag.ToString())
            {
                try
                {
                    oHelper.ActualizarParametro("ServicioTerpel", TxtServicioTerpel.Text);
                    TxtServicioTerpel.Tag = TxtServicioTerpel.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void TxtUrlMenoCash_Leave(object sender, EventArgs e)
        {
            if (TxtUrlMenoCash.Text != TxtUrlMenoCash.Tag.ToString())
            {
                try
                {
                    oHelper.ActualizarParametro("UrlMenoCash", TxtUrlMenoCash.Text);
                    TxtUrlMenoCash.Tag = TxtUrlMenoCash.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void TxtLlavePrivada_Leave(object sender, EventArgs e)
        {
            if (TxtLlavePrivada.Text != TxtLlavePrivada.Tag.ToString())
            {
                try
                {
                    GSTCriptografia1.Criptografia1 Gst1 = new GSTCriptografia1.Criptografia1();
                    String LlavePrivada = Gst1.GenerarClavePrivada(TxtLlavePrivada.Text).ToString();
                    oHelper.ActualizarParametro("LlavePrivada", LlavePrivada);
                    TxtLlavePrivada.Tag = TxtLlavePrivada.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void TxtLlavePublica_Leave(object sender, EventArgs e)
        {
            if (TxtLlavePublica.Text != TxtLlavePublica.Tag.ToString())
            {
                try
                {
                    oHelper.ActualizarParametro("LlavePublica", TxtLlavePublica.Text);
                    TxtLlavePublica.Tag = TxtLlavePublica.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void TxtCodigoSeguridadGasoNet_Leave(object sender, EventArgs e)
        {
            if (TxtCodigoSeguridadGasoNet.Text != TxtCodigoSeguridadGasoNet.Tag.ToString())
            {
                try
                {
                    oHelper.ActualizarParametro("CodigoSeguridadGasoNet", TxtCodigoSeguridadGasoNet.Text);
                    TxtCodigoSeguridadGasoNet.Tag = TxtCodigoSeguridadGasoNet.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ChkAplicaAjusteAutomaticoEnTurno_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkAplicaAjusteAutomaticoEnTurno.Checked == true)
                {
                    oHelper.ActualizarParametro("AplicaAjusteAutomaticoEnTurno", "True");
                }
                else
                {
                    oHelper.ActualizarParametro("AplicaAjusteAutomaticoEnTurno", "False");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panelParametrosGenerales_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtCodEstacionGasoNet_Leave(object sender, EventArgs e)
        {
            if (TxtCodEstacionGasoNet.Text != TxtCodEstacionGasoNet.Tag.ToString())
            {
                try
                {
                    oHelper.ActualizarParametro("CodigoEstacionGasoNet", TxtCodEstacionGasoNet.Text);
                    TxtCodEstacionGasoNet.Tag = TxtCodEstacionGasoNet.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtintervalo_Leave(object sender, EventArgs e)
        {
            try
            {
                int tiempo = 0;
                if (int.TryParse(txtintervalo.Text.Trim(), out tiempo))
                {
                    oHelper.ActualizarParametro("IntervaloConsignacion", txtintervalo.Text);
                    txtintervalo.Tag = txtintervalo.Text;
                }
                else
                    throw new Exception("El valor debe ser numerico y un numero entero");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void txtinfotaxi_Leave(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(txtinfotaxi.Text.Trim()))
                {
                    oHelper.ActualizarParametro("UrlInfoTaxi", txtinfotaxi.Text);
                    txtinfotaxi.Tag = txtinfotaxi.Text;
                }
                else
                    throw new Exception("El valor de la URL no debe ser vacio");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ChkAplicaCierreTurnoAutomatico_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChkAplicaCierreTurnoAutomatico.Checked == true)
                {
                    oHelper.ActualizarParametro("AplicaCierreTurnoAutomatico", "True");
                }
                else
                {
                    oHelper.ActualizarParametro("AplicaCierreTurnoAutomatico", "False");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


 
       
    }
}