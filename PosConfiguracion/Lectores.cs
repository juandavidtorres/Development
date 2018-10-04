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
    public partial class Lectores : UserControl
    {
        public Lectores()
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

        Helper oHelper = new Helper();
        Boolean EsGridDTICaraContruido;

        Color[] Colores = { Color.LightCyan, Color.LightGoldenrodYellow, Color.LightGray, Color.LightGreen, Color.LightPink, Color.LightSalmon, Color.LightSeaGreen, Color.LightSkyBlue, Color.LightSlateGray, Color.LightSteelBlue, Color.LightYellow, Color.LemonChiffon, Color.LightBlue, Color.LightCoral };


        #region Event Handlers

        public void CargaDatosLectores()
        {
            this.IniciarForma();
        }



        private void IniciarForma()
        {
            try
            {
                RecuperarOneWire();
                RecuperarDispositivosDTI();
                RecuperarDispositivosCara();
                RecuperarTiposComunicacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void RecuperarOneWire()
        {
            this.cmbPuertoOneWire.DisplayMember = "Puerto";
            this.cmbPuertoOneWire.ValueMember = "IdOneWire";
            this.cmbPuertoOneWire.DataSource = oHelper.RecuperarRedLectores().Tables[0];

            if (cmbPuertoOneWire.SelectedValue != null)
            {
                RecuperarLectoresPorPuerto(Int32.Parse(cmbPuertoOneWire.SelectedValue.ToString()));
            }

        }


        #region "DispositivosLSIB4"

        private void RecuperarDispositivosDTI()
        {
            try
            {
                DataGridView d = dtgDispositivosDTI;
                d.DataSource = oHelper.RecuperarDispositivosDTIGrilla().Tables[0];
                RecuperarPuertosDTI();
            }
            catch (Exception ex)
            {   MessageBox.Show(ex.Message); }
        }


        private void RecuperarPuertosDTI()
        {
            try
            {
                DataGridView d = dtgDispositivosDTI;

                if (d.CurrentRow != null)
                {    DataGridViewComboBoxColumn Combo = (DataGridViewComboBoxColumn)d.Columns["PuertoDTI"];

                    Combo.DataPropertyName = "IdPuerto";
                    Combo.DisplayMember = "Puerto";
                    Combo.ValueMember = "IdPuerto";
                    Combo.DataSource = oHelper.RecuperarPuertos().Tables[0];                  
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }


        private void RecuperarTiposComunicacion()
        {
            DataGridView d = dtgDispositivosDTI;

            try
            {
                DataGridViewComboBoxColumn Combo = (DataGridViewComboBoxColumn) d.Columns["TipoComunicacion"];
                Combo.DisplayMember = "TipoComunicacion";
                Combo.ValueMember = "IdTipoComunicacionDisp";
                Combo.DataSource = oHelper.RecuperarTipoComunicacionDispositivo();
            }
            catch (Exception ex)
            {  MessageBox.Show(ex.Message); }
        }

        private object ISNULL(object data, object dataReplace)
        {
             if (String.IsNullOrEmpty(Convert.ToString(data)))
                 return dataReplace;
             else
                 return data;
        }

        private bool ISNULL(object data)
        {
            if (String.IsNullOrEmpty(Convert.ToString(data)))
                return true;
            else
                return false;
        }

        private void dtgDispositivosDTI_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView d = dtgDispositivosDTI;
                DataGridViewRow row;
                int id;

                
                if (d != null && e.RowIndex >= 0)
                {
                    row = d.Rows[e.RowIndex];

                    if (!ISNULL(row.Cells["Descripcion"].Value))
                    {
                        if ((!ISNULL(row.Cells["PuertoDTI"].Value) &&
                             Convert.ToString(row.Cells["TipoComunicacion"].Value) == "1") ||
                             (!ISNULL(row.Cells["PuertoIP"].Value) &&
                              Convert.ToString(row.Cells["TipoComunicacion"].Value) == "2")
                          )
                        {

                            id = (!ISNULL(row.Cells["IdLectorDTI"].Value)) ?
                                   Convert.ToInt32(row.Cells["IdLectorDTI"].Value) : -1;

                            oHelper.InsertarDispositivoDTI(id,
                                                            Convert.ToString(row.Cells["Descripcion"].Value),
                                                            Convert.ToInt32(ISNULL(row.Cells["PuertoDTI"].Value, "-1")),
                                                            Convert.ToString(ISNULL(row.Cells["PuertoIP"].Value, "")),
                                                            Convert.ToString(row.Cells["TipoComunicacion"].Value)
                                                           );

                            RecuperarDispositivosDTI();
                            RecuperarDispositivosCara();
                            RecuperarTiposComunicacion();
                        }               
                    }
                    else
                        if (d.ContainsFocus == false)
                        {
                            RecuperarDispositivosDTI();
                            RecuperarDispositivosCara();
                            RecuperarTiposComunicacion();
                        }
                }        
            }
            catch (Exception ex)
            {
                RecuperarDispositivosDTI();
                RecuperarDispositivosCara();
                RecuperarTiposComunicacion();
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgDispositivosDTI_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
           // MessageBox.Show("Dispositivos DTI (" + e.RowIndex.ToString() + ")");
        }

        private void dtgDispositivosDTI_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                RecuperarDispositivosDTI();
                RecuperarDispositivosCara();
                RecuperarTiposComunicacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgDispositivosDTI_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar el registro #" + (e.Row.Index + 1) + "?", "Gas Station Config Desktop®",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                  MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    oHelper.EliminarDispositivoDTI(Int32.Parse(dtgDispositivosDTI.Rows[e.Row.Index].Cells["IdLectorDTI"].Value.ToString()));
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



        #endregion


        #region "Dispositivos DTI Caras"

        private void RecuperarDispositivosCara()
        {

            try
            {

                DataGridViewComboBoxColumn ComboCaraDTI = (DataGridViewComboBoxColumn)this.dtgConfigurarCarasDTI.Columns["CaraDTIGrilla"];
                ComboCaraDTI.DisplayMember = "Descripcion";
                ComboCaraDTI.ValueMember = "IdCara";
                ComboCaraDTI.DataSource = oHelper.RecuperarCaras().Tables[0];

                DataGridViewComboBoxColumn ComboDTI = (DataGridViewComboBoxColumn)this.dtgConfigurarCarasDTI.Columns["DispositivoDTIGrilla"];
                ComboDTI.DisplayMember = "Dispositivo";
                ComboDTI.ValueMember = "IdDTI";
                ComboDTI.DataSource = oHelper.RecuperarDescripcionDTI().Tables[0];

                DataGridViewComboBoxColumn ComboDireccion = (DataGridViewComboBoxColumn)this.dtgConfigurarCarasDTI.Columns["DireccionGrilla"];
                ComboDireccion.DisplayMember = "Direccion";
                ComboDireccion.ValueMember = "Direccion";
                ComboDireccion.DataSource = oHelper.RecuperarConfiguraCaraDTI().Tables[0];

                this.dtgConfigurarCarasDTI.DataSource = oHelper.RecuperarDispositivosDTICara().Tables[0];

                EsGridDTICaraContruido = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dtgConfigurarCarasDTI_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 4)
                {
                    DataGridViewComboBoxColumn ComboDireccion = (DataGridViewComboBoxColumn)this.dtgConfigurarCarasDTI.Columns["DireccionGrilla"];
                    ComboDireccion.DisplayMember = "Direccion";
                    ComboDireccion.ValueMember = "Direccion";
                    ComboDireccion.DataSource = oHelper.RecuperarConfiguraCaraDTI(Convert.ToInt32(dtgConfigurarCarasDTI.Rows[e.RowIndex].Cells["DispositivoDTIGrilla"].Value.ToString())).Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgConfigurarCarasDTI_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (EsGridDTICaraContruido)
                {
                    if ((!String.IsNullOrEmpty(dtgConfigurarCarasDTI.Rows[e.RowIndex].Cells["DispositivoDTIGrilla"].Value.ToString())) && (!String.IsNullOrEmpty(dtgConfigurarCarasDTI.Rows[e.RowIndex].Cells["DireccionGrilla"].Value.ToString())))
                    {
                        if (!String.IsNullOrEmpty(dtgConfigurarCarasDTI.Rows[e.RowIndex].Cells["IdDispositivoCara"].Value.ToString()))
                        {
                            //Actualiza
                            oHelper.ActualizarDispositivoDTICara(Int32.Parse(dtgConfigurarCarasDTI.Rows[e.RowIndex].Cells["IdDispositivoCara"].Value.ToString()), Int32.Parse(dtgConfigurarCarasDTI.Rows[e.RowIndex].Cells["DispositivoDTIGrilla"].Value.ToString()), Int32.Parse(dtgConfigurarCarasDTI.Rows[e.RowIndex].Cells["CaraDTIGrilla"].Value.ToString()), dtgConfigurarCarasDTI.Rows[e.RowIndex].Cells["DireccionGrilla"].Value.ToString());
                        }
                        else
                        {
                            //Inserta Nuevo Registro
                            oHelper.InsertarDispositivoDTICara(Int32.Parse(dtgConfigurarCarasDTI.Rows[e.RowIndex].Cells["DispositivoDTIGrilla"].Value.ToString()), Int32.Parse(dtgConfigurarCarasDTI.Rows[e.RowIndex].Cells["CaraDTIGrilla"].Value.ToString()), dtgConfigurarCarasDTI.Rows[e.RowIndex].Cells["DireccionGrilla"].Value.ToString());
                        }
                        RecuperarDispositivosCara();
                    }
                    else
                    {
                        if (dtgConfigurarCarasDTI.ContainsFocus == false)
                        {
                            RecuperarDispositivosCara();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RecuperarDispositivosCara();
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgConfigurarCarasDTI_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                RecuperarDispositivosCara();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgConfigurarCarasDTI_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar el registro #" + (e.Row.Index + 1) + "?", "Gas Station Config Desktop®",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    oHelper.EliminarDispositivoDTICara(Int32.Parse(dtgConfigurarCarasDTI.Rows[e.Row.Index].Cells["IdDispositivoCara"].Value.ToString()));
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

        #endregion


        private void txtLector_Validating(object sender, CancelEventArgs e)
        {
            Boolean Incorrecto = false;
            try
            {
                if (txtLector.Text.Length != 16)
                {
                    errorProvider1.SetError(txtLector, "Longitud ROM incorrecta");
                    txtLector.Focus();
                }
                else
                {
                    for (Int32 I = 0; I < 16; I++)
                    {
                        if (!"0123456789ABCDEF".Contains(txtLector.Text.Substring(I, 1)))
                        {
                            Incorrecto = true;
                            errorProvider1.SetError(txtLector, "Formato ROM incorrecto");
                            txtLector.Focus();
                        }
                    }
                    if (!Incorrecto)
                    {
                        errorProvider1.SetError(txtLector, "");
                    }
                }
            }
            catch
            {
                errorProvider1.SetError(txtLector, "Formato ROM incorrecto");
            }
        }



        private void cmbPuertoOneWire_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPuertoOneWire.SelectedIndex != -1)
                {
                    RecuperarLectoresPorPuerto(Int32.Parse(cmbPuertoOneWire.SelectedValue.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecuperarLectoresPorPuerto(Int32 Puerto)
        {
            try
            {
                lstLectores.DisplayMember = "ROM";
                lstLectores.ValueMember = "IdLector";
                lstLectores.DataSource = oHelper.RecuperarLectoresPorPuerto(Puerto).Tables[0];

            }
            catch
            {
                throw;
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbPuertoOneWire.SelectedValue != null)
                {
                    oHelper.InsertarLector(txtLector.Text, Int32.Parse(this.cmbPuertoOneWire.SelectedValue.ToString()));
                    RecuperarLectoresPorPuerto(Int32.Parse(cmbPuertoOneWire.SelectedValue.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                for (Int32 I = 0; I < chkLectores.CheckedItems.Count; I++)
                {
                    oHelper.InsertarLector(chkLectores.CheckedItems[I].ToString(), Int32.Parse(this.cmbPuertoOneWire.SelectedValue.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (this.cmbPuertoOneWire.SelectedValue != null)
                {
                    RecuperarLectoresPorPuerto(Int32.Parse(cmbPuertoOneWire.SelectedValue.ToString()));
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lstLectores.SelectedIndex != -1)
                {
                    oHelper.EliminarLector(Int32.Parse(this.lstLectores.SelectedValue.ToString()));
                    RecuperarLectoresPorPuerto(Int32.Parse(cmbPuertoOneWire.SelectedValue.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (cmbPuertoOneWire.SelectedIndex != -1)
                {
                    MessageBox.Show("Asegurese que la Red Dallas 1-Wire no esté en uso");

                    ArrayList ListaLectores = null;
                    ListaLectores = oHelper.RecuperarLectoresRedOneWire(this.cmbPuertoOneWire.Text);
                    chkLectores.Items.Clear();
                    for (Int32 I = 0; I <= ListaLectores.Count - 1; I++)
                    {
                        if (ListaLectores[I].ToString().Substring(14, 2) == "1F")
                            chkLectores.Items.Add(ListaLectores[I]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private void dtgDispositivosDTI_RowEnter(object sender, DataGridViewCellEventArgs e)
        {  VerTipoComunicacion(e.RowIndex);  }       


        public void VerTipoComunicacion(int index)
        {
           try
           {    DataGridView d = dtgDispositivosDTI;
                DataGridViewCell cell;
                DataGridViewRow row;

                row = d.Rows[index];
                cell = row.Cells["TipoComunicacion"];

                if (!ISNULL(cell.Value))
                    switch (Convert.ToInt16(cell.Value))
                    {
                        case 1:
                            d.Columns["PuertoDTI"].ReadOnly = false;
                            d.Columns["PuertoIP"].ReadOnly = true;
                            break;
                        default:
                            d.Columns["PuertoDTI"].ReadOnly = true;
                            d.Columns["PuertoIP"].ReadOnly = false;
                            break;
                    }
            }
           catch (Exception ex)
           { }
        }

        private void dtgDispositivosDTI_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {   RecuperarPuertosDTI();
                VerTipoComunicacion(e.RowIndex);
            }
            catch (Exception ex)
            { }
        }






  





        //private void grdImpresoras_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (EsGridImpresoraContruido)
        //        {
        //            if (!String.IsNullOrEmpty(grdImpresoras.Rows[e.RowIndex].Cells["IdImpresoraGrillaImpresora"].Value.ToString()))
        //            {
        //                oHelper.ActualizarImpresora(Int32.Parse(grdImpresoras.Rows[e.RowIndex].Cells["IdImpresoraGrillaImpresora"].Value.ToString()), grdImpresoras.Rows[e.RowIndex].Cells["NombreGrillaImpresora"].Value.ToString());
        //            }
        //            else
        //            {
        //                oHelper.InsertarImpresora(grdImpresoras.Rows[e.RowIndex].Cells["NombreGrillaImpresora"].Value.ToString());
        //            }
        //            RecuperarImpresoras();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RecuperarImpresoras();
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void grdEstaciones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (EsGridEstacionContruido)
        //        {
        //            if ((!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["IdEstacionGrillaEstacion"].Value.ToString())) && (!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["CodigoGrillaEstacion"].Value.ToString())) && (!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["NombreGrillaEstacion"].Value.ToString())) && (!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["NitGrillaEstacion"].Value.ToString())) && (!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["DireccionGrillaEstacion"].Value.ToString())) && (!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["TelefonoGrillaEstacion"].Value.ToString())) && (!String.IsNullOrEmpty(grdEstaciones.Rows[e.RowIndex].Cells["IdCiudadGrillaEstacion"].Value.ToString())))                            
        //            {

        //                oHelper.ActualizarEstacion(Int16.Parse(grdEstaciones.Rows[0].Cells["IdEstacionGrillaEstacion"].Value.ToString()), grdEstaciones.Rows[0].Cells["CodigoGrillaEstacion"].Value.ToString(), grdEstaciones.Rows[0].Cells["NombreGrillaEstacion"].Value.ToString(), grdEstaciones.Rows[0].Cells["NitGrillaEstacion"].Value.ToString(), grdEstaciones.Rows[0].Cells["DireccionGrillaEstacion"].Value.ToString(), grdEstaciones.Rows[0].Cells["TelefonoGrillaEstacion"].Value.ToString(), Int32.Parse(grdEstaciones.Rows[0].Cells["IdCiudadGrillaEstacion"].Value.ToString()));                                      
        //                RecuperarEstaciones();
        //                RecuperarDatosBasicos(oHelper);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RecuperarEstaciones();
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void txtConsecutivoVentas_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Int32.Parse(txtConsecutivoVentas.Text);
        //        errorProvider1.SetError(txtConsecutivoVentas, "");

        //        if (txtConsecutivoVentas.Text != txtConsecutivoVentas.Tag.ToString())
        //        {
        //            try
        //            {
        //                Int32 ConsecutivoVentas = Convert.ToInt32(txtConsecutivoVentas.Text);
        //                oHelper.ActualizarConsecutivo("Vehiculo", ConsecutivoVentas);
        //                txtConsecutivoVentas.Tag = txtConsecutivoVentas.Text;
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);
        //            }
        //        }
        //    }
        //    catch 
        //    {
        //        errorProvider1.SetError(txtConsecutivoVentas, "El valor debe ser un número");
        //    }
        //}

        //private void btnAbrir_Click(object sender, EventArgs e)
        //{
        //    bfAbrir.Description = "Seleccione la carpeta donde se creará el archivo de Backup";
        //    bfAbrir.RootFolder = Environment.SpecialFolder.MyComputer;
        //    bfAbrir.ShowNewFolderButton = true;
        //    bfAbrir.SelectedPath = txtRutaBackup.Text;
        //    bfAbrir.ShowDialog();

        //    txtRutaBackup.Text = bfAbrir.SelectedPath;
        //}

        //private void btnAbrir_Leave(object sender, EventArgs e)
        //{
        //    if (txtRutaBackup.Text != txtRutaBackup.Tag.ToString())
        //    {
        //        try
        //        {
        //            oHelper.ActualizarParametro("RutaBackup", txtRutaBackup.Text);
        //            txtRutaBackup.Tag = txtRutaBackup.Text;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}

        //private void txtVentas_Leave(object sender, EventArgs e)
        //{
        //    if (txtVentas.Text != txtVentas.Tag.ToString())
        //    {
        //        try
        //        {
        //            Int32 Ventas = Convert.ToInt32(txtVentas.Text);
        //            oHelper.ActualizarSincronizacion("Ventas", Ventas.ToString());
        //            txtVentas.Tag = txtVentas.Text;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}

        //private void txtLecturas_Leave(object sender, EventArgs e)
        //{
        //    if (txtLecturas.Text != txtLecturas.Tag.ToString())
        //    {
        //        try
        //        {
        //            Int32 Lecturas = Convert.ToInt32(txtLecturas.Text);
        //            oHelper.ActualizarSincronizacion("Lecturas", Lecturas.ToString());
        //            txtLecturas.Tag = txtLecturas.Text;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}

        //private void txtPagos_Leave(object sender, EventArgs e)
        //{
        //    if (txtPagos.Text != txtPagos.Tag.ToString())
        //    {
        //        try
        //        {
        //            Int32 Pagos = Convert.ToInt32(txtPagos.Text);
        //            oHelper.ActualizarSincronizacion("Pagos", Pagos.ToString());
        //            txtPagos.Tag = txtPagos.Text;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}

        //private void txtTransacciones_Leave(object sender, EventArgs e)
        //{
        //    if (txtTransacciones.Text != txtTransacciones.Tag.ToString())
        //    {
        //        try
        //        {
        //            Int32 Transacciones = Convert.ToInt32(txtTransacciones.Text);
        //            oHelper.ActualizarSincronizacion("Transacciones", Transacciones.ToString());
        //            txtTransacciones.Tag = txtTransacciones.Text;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}

        //private void txtReversiones_Leave(object sender, EventArgs e)
        //{
        //    if (txtReversiones.Text != txtReversiones.Tag.ToString())
        //    {
        //        try
        //        {
        //            Int32 Reversiones = Convert.ToInt32(txtReversiones.Text);
        //            oHelper.ActualizarSincronizacion("Reversiones", Reversiones.ToString());
        //            txtReversiones.Tag = txtReversiones.Text;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}

        //private void grdPuertos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (EsGridPuertoContruido)
        //        {
        //            if (!String.IsNullOrEmpty(grdPuertos.Rows[e.RowIndex].Cells["IdPuertoGrillaPuerto"].Value.ToString()))
        //            {
        //                oHelper.ActualizarPuerto(Int32.Parse(grdPuertos.Rows[e.RowIndex].Cells["IdPuertoGrillaPuerto"].Value.ToString()), grdPuertos.Rows[e.RowIndex].Cells["PuertoGrillaPuerto"].Value.ToString());
        //            }
        //            else
        //            {
        //                oHelper.InsertarPuerto(grdPuertos.Rows[e.RowIndex].Cells["PuertoGrillaPuerto"].Value.ToString());
        //            }
        //            RecuperarPuertos();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RecuperarPuertos();
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void cmbEncriptacion_Leave(object sender, EventArgs e)
        //{
        //    if (cmbEncriptacion.Text != cmbEncriptacion.Tag.ToString())
        //    {
        //        try
        //        {
        //            if (cmbEncriptacion.Text == "Todas")
        //            {
        //                oHelper.ActualizarParametro("TwoFish", "True");
        //                oHelper.ActualizarParametro("Suic", "True");
        //            }
        //            else if (cmbEncriptacion.Text == "TwoFish")
        //            {
        //                oHelper.ActualizarParametro("TwoFish", "True");
        //                oHelper.ActualizarParametro("Suic", "False");
        //            }
        //            else
        //            {
        //                oHelper.ActualizarParametro("TwoFish", "False");
        //                oHelper.ActualizarParametro("Suic", "True");
        //            }
        //            cmbEncriptacion.Tag = cmbEncriptacion.Text;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}

        //private void grdImpresoras_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    //Dejarlo para evitar mensajes de error si no existen las impresoras
        //}

        //private void grdPuertos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    //Dejarlo para evitar mensajes de error si no existen los puertos
        //}

        //private void grdImpresoras_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    try
        //    {
        //        if (MessageBox.Show("¿Desea eliminar la impresora que se encuentra en la posición #" + (e.Row.Index + 1) + "?", "Gas Station Config Desktop®",
        //             MessageBoxButtons.YesNo, MessageBoxIcon.Question,
        //             MessageBoxDefaultButton.Button1) == DialogResult.Yes)
        //        {
        //            oHelper.EliminarImpresora(Int32.Parse(grdImpresoras.Rows[e.Row.Index].Cells["IdImpresoraGrillaImpresora"].Value.ToString()));
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

        //private void grdPuertos_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    try
        //    {
        //        if (MessageBox.Show("¿Desea eliminar el puerto que se encuentra en la posición #" + (e.Row.Index + 1) + "?", "Gas Station Config Desktop®",
        //             MessageBoxButtons.YesNo, MessageBoxIcon.Question,
        //             MessageBoxDefaultButton.Button1) == DialogResult.Yes)
        //        {
        //            oHelper.EliminarPuerto(Int32.Parse(grdPuertos.Rows[e.Row.Index].Cells["IdPuertoGrillaPuerto"].Value.ToString()));
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


        //private void grdRedSurtidor_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    try
        //    {
        //        if (MessageBox.Show("¿Desea eliminar el registro #" + (e.Row.Index + 1) + " de la Red de Surtidores?", "Gas Station Config Desktop®",
        //             MessageBoxButtons.YesNo, MessageBoxIcon.Question,
        //             MessageBoxDefaultButton.Button1) == DialogResult.Yes)
        //        {
        //            oHelper.EliminarRedSurtidor(Int32.Parse(grdRedSurtidor.Rows[e.Row.Index].Cells["ProtocoloGrillaRedSurtidor"].Value.ToString()), Int32.Parse(grdRedSurtidor.Rows[e.Row.Index].Cells["PuertoGrillaRedSurtidor"].Value.ToString()));
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

        //private void grdRedLector_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    try
        //    {
        //        if (MessageBox.Show("¿Desea eliminar el puerto en la posición #" + (e.Row.Index + 1) + " de la Red 1-Wire?", "Gas Station Config Desktop®",
        //                 MessageBoxButtons.YesNo, MessageBoxIcon.Question,
        //                 MessageBoxDefaultButton.Button1) == DialogResult.Yes)
        //        {
        //            oHelper.EliminarRedLector(Int32.Parse(grdRedLector.Rows[e.Row.Index].Cells["IdGrillaIbutton"].Value.ToString()));
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

        //private void grdRedCapturador_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    try
        //    {

        //        if (MessageBox.Show("¿Desea eliminar el registro #" + (e.Row.Index + 1) + " de la Red de Capturadores?", "Gas Station Config Desktop®",
        //             MessageBoxButtons.YesNo, MessageBoxIcon.Question,
        //             MessageBoxDefaultButton.Button1) == DialogResult.Yes)
        //        {
        //            oHelper.EliminarCapturador(Int32.Parse(grdRedCapturador.Rows[e.Row.Index].Cells["IdCapturador"].Value.ToString()));
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
        //private void grdHorarios_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    try
        //    {

        //        if (MessageBox.Show("¿Desea eliminar el último registro de los Horarios?", "Gas Station Config Desktop®",
        //             MessageBoxButtons.YesNo, MessageBoxIcon.Question,
        //             MessageBoxDefaultButton.Button1) == DialogResult.Yes)
        //        {
        //            oHelper.EliminarTurnoHorario(Int32.Parse(grdHorarios.Rows[grdHorarios.NewRowIndex - 1].Cells["IdTurnoHorario"].Value.ToString()));
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

        //private void grdHorarios_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        //{

        //    try
        //    {
        //        RecuperarHorarios();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //private void grdImpresoras_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        RecuperarImpresoras();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void grdPuertos_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        //{
        //        try
        //    {
        //        RecuperarPuertos();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void grdRedLector_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        RecuperarRedIbutton();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void grdRedCapturador_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        RecuperarCapturadores();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void grdRedSurtidor_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        RecuperarRedSurtidores();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

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

        //private void grdHorarios_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    MessageBox.Show("Horarios (" + e.RowIndex.ToString() + ")");
        //}

        //private void grdCara_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    MessageBox.Show("Caras (" + e.RowIndex.ToString() + ")");
        //}

        //private void grdConfiguracion_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    MessageBox.Show("Configuracion (" + e.RowIndex.ToString() + ")");
        //}

        //private void grdEstaciones_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    MessageBox.Show("Estaciones (" + e.RowIndex.ToString() + ")");
        //}

        //private void grdIslas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    MessageBox.Show("Islas (" + e.RowIndex.ToString() + ")");
        //}

        //private void grdProtocolos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    MessageBox.Show("Protocolos (" + e.RowIndex.ToString() + ")");
        //}

        //private void grdRedCapturador_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    MessageBox.Show("Red Capturador (" + e.RowIndex.ToString() + ")");
        //}

        //private void grdRedLector_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    MessageBox.Show("Red Lector (" + e.RowIndex.ToString() + ")");
        //}

        //private void grdRedSurtidor_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    MessageBox.Show("Red Surtidores (" + e.RowIndex.ToString() + ")");
        //}

        //private void grdSurtidores_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    MessageBox.Show("Surtidores (" + e.RowIndex.ToString() + ")");
        //}

        //private void mnuRefrescar_Click(object sender, EventArgs e)
        //{
        //    IniciarForma();
        //}

        //private void MainForm_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F5)
        //    {
        //        IniciarForma();
        //    }

        //}

        //private void chkLecturaChip_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (chkLecturaChip.Checked == true)
        //        {
        //            oHelper.ActualizarParametro("ConfirmarLecturaChip", "True");
        //        }
        //        else
        //        {
        //            oHelper.ActualizarParametro("ConfirmarLecturaChip", "False");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void chkRecaudo_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (chkRecaudo.Checked == true)
        //        {
        //            oHelper.ActualizarParametro("Recaudar", "True");
        //            chkOpcional.Enabled = true;
        //        }
        //        else
        //        {
        //            oHelper.ActualizarParametro("Recaudar", "False");
        //            chkOpcional.Enabled = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void grdHistoricoPrecio_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (EsGridHistoricoPrecioContruido)
        //        {
        //            if ((!String.IsNullOrEmpty((String)grdHistoricoPrecio.Rows[e.RowIndex].Cells["FechaHora"].Value.ToString())) && (!String.IsNullOrEmpty((String)grdHistoricoPrecio.Rows[e.RowIndex].Cells["Precio"].Value.ToString())))
        //            {
        //                DateTime Fecha;
        //                DateTime? FechaOld = null;
        //                Int32 IdProducto = Int32.Parse(cmbProducto.SelectedValue.ToString());
        //                Double Precio;

        //                Fecha = DateTime.Parse(grdHistoricoPrecio.Rows[e.RowIndex].Cells["FechaHora"].Value.ToString());
        //                Precio = Double.Parse(grdHistoricoPrecio.Rows[e.RowIndex].Cells["Precio"].Value.ToString());

        //                if (FechaActual == null)
        //                {
        //                    FechaOld = null;
        //                }
        //                else
        //                {
        //                    FechaOld = DateTime.Parse(FechaActual);
        //                }

        //                oHelper.ActualizarHistoricoPrecio(IdProducto, FechaOld, Fecha, Precio);

        //                Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nEl historico del precio ha sido actualizado satisfactoriamente";
        //                Popup.Popup();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Popup.ContentText = "\t\t\tGas Station Config Desktop\n\n" + ex.Message;
        //        Popup.Popup();
        //    }
        //}

        //private void grdHistoricoPrecio_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    MessageBox.Show("Historico Precio (" + e.RowIndex.ToString() + ")");
        //}

        //private void grdHistoricoPrecio_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    try
        //    {
        //        if (MessageBox.Show("¿Desea eliminar este precio que se encuentra en la posición #" + (e.Row.Index + 1) + "?", "Gas Station Config Desktop®",
        //             MessageBoxButtons.YesNo, MessageBoxIcon.Question,
        //             MessageBoxDefaultButton.Button1) == DialogResult.Yes)
        //        {
        //            Int32 IdProducto = Int32.Parse(cmbProducto.SelectedValue.ToString());
        //            DateTime Fecha = DateTime.Parse(grdHistoricoPrecio.Rows[e.Row.Index].Cells["FechaHora"].Value.ToString());
        //            oHelper.EliminarHistoricoPrecio(IdProducto, Fecha);

        //            Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nEl historico del precio ha sido eliminado satisfactoriamente";
        //            Popup.Popup();
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

        //private void cmbProducto_Leave(object sender, EventArgs e)
        //{
        //    if (cmbProducto.SelectedIndex != -1)
        //    {
        //        this.RecuperarHistoricoPrecio(Int32.Parse(cmbProducto.SelectedValue.ToString()));
        //    }
        //}

        //String FechaActual, PrecioActual;

        //private void grdHistoricoPrecio_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    try
        //    {
        //        if (grdHistoricoPrecio.IsCurrentCellInEditMode)
        //        {
        //            if (String.IsNullOrEmpty(grdHistoricoPrecio.Rows[e.RowIndex].Cells["FechaHora"].Value.ToString()))
        //            {
        //                FechaActual = null;
        //            }
        //            else
        //            {
        //                FechaActual = grdHistoricoPrecio.Rows[e.RowIndex].Cells["FechaHora"].Value.ToString();
        //            }

        //            if (String.IsNullOrEmpty(grdHistoricoPrecio.Rows[e.RowIndex].Cells["Precio"].Value.ToString()))
        //            {
        //                PrecioActual = null;
        //            }
        //            else
        //            {
        //                PrecioActual = grdHistoricoPrecio.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
        //            }

        //            if (grdHistoricoPrecio.Columns[e.ColumnIndex].Name == "FechaHora")
        //            {
        //                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
        //                {
        //                    Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nLa fecha no puede ser vacía";
        //                    Popup.Popup();
        //                    e.Cancel = true;
        //                }
        //                else
        //                {
        //                    DateTime Fecha;
        //                    if (!DateTime.TryParse(e.FormattedValue.ToString(), out Fecha))
        //                    {
        //                        Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nLa fecha no tiene el formato correcto";
        //                        Popup.Popup();
        //                        e.Cancel = true;
        //                    }
        //                }

        //                if (!e.Cancel)
        //                {
        //                    DateTime Fecha, FechaTemp;
        //                    Boolean Existe = false;

        //                    Fecha = DateTime.Parse(e.FormattedValue.ToString());

        //                    for (Int32 I = 0; I < grdHistoricoPrecio.Rows.Count - 1; I++)
        //                    {
        //                        if (!String.IsNullOrEmpty(grdHistoricoPrecio.Rows[I].Cells["FechaHora"].Value.ToString()))
        //                        {
        //                            FechaTemp = DateTime.Parse(grdHistoricoPrecio.Rows[I].Cells["FechaHora"].Value.ToString());
        //                            if (Fecha == FechaTemp)
        //                            {
        //                                Existe = true;
        //                            }
        //                        }
        //                    }

        //                    if (Existe)
        //                    {
        //                        e.Cancel = true;
        //                        throw new GasolutionsException("La fecha ya ha sido ingresada al historico de precio de este producto");
        //                    }
        //                }
        //            }

        //            if (grdHistoricoPrecio.Columns[e.ColumnIndex].Name == "Precio")
        //            {
        //                if (!String.IsNullOrEmpty(e.FormattedValue.ToString()))
        //                {
        //                    Double Temp = 0;
        //                    if (!Double.TryParse(e.FormattedValue.ToString(), out Temp))
        //                    {
        //                        Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nEl precio debe ser un número";
        //                        Popup.Popup();
        //                        e.Cancel = true;
        //                    }
        //                    else
        //                    {
        //                        if (Temp <= 0)
        //                        {
        //                            Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nEl precio debe ser un número mayor que cero";
        //                            Popup.Popup();
        //                            e.Cancel = true;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nEl precio no puede ser vacio";
        //                    Popup.Popup();
        //                    e.Cancel = true;
        //                }
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Popup.ContentText = "\t\t\tGas Station Config Desktop\n\n" + ex.Message;
        //        Popup.Popup();
        //    }
        //}

        //private void grdRedSurtidor_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    try
        //    {
        //        if (this.grdRedSurtidor.IsCurrentCellInEditMode)
        //        {
        //            if (grdRedSurtidor.Columns[e.ColumnIndex].Name == "CaraInicial")
        //            {
        //                if (!String.IsNullOrEmpty(e.FormattedValue.ToString()))
        //                {
        //                    Double Temp = 0;
        //                    if (!Double.TryParse(e.FormattedValue.ToString(), out Temp))
        //                    {
        //                        Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nLa cara inicial debe ser un número";
        //                        Popup.Popup();
        //                        e.Cancel = true;
        //                    }
        //                    else
        //                    {
        //                        if (Temp <= 0)
        //                        {
        //                            Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nLa cara inicial debe ser un número mayor que cero";
        //                            Popup.Popup();
        //                            e.Cancel = true;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nLa cara inicial no puede ser vacia";
        //                    Popup.Popup();
        //                    e.Cancel = true;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Popup.ContentText = "\t\t\tGas Station Config Desktop\n\n" + ex.Message;
        //        Popup.Popup();
        //    }
        //}

        //private void txtFacturas_Leave(object sender, EventArgs e)
        //{
        //    if (txtFacturas.Text != txtFacturas.Tag.ToString())
        //    {
        //        try
        //        {
        //            if (!String.IsNullOrEmpty(txtFacturas.Text))
        //            {
        //                Int32 Facturas = 0;
        //                if (!Int32.TryParse(txtFacturas.Text, out Facturas))
        //                {
        //                    Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nEl contador de las facturas debe ser un número";
        //                    Popup.Popup();
        //                }
        //                else
        //                {
        //                    if (Facturas < 0)
        //                    {
        //                        Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nEl contador de las facturas debe ser un número mayor o igual que cero";
        //                        Popup.Popup();
        //                    }
        //                    else
        //                    {
        //                        oHelper.ActualizarSincronizacion("VentasCanastilla", Facturas.ToString());
        //                        txtFacturas.Tag = txtFacturas.Text;

        //                        Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nEl contador de las facturas se actualizó satisfactoriamente";
        //                        Popup.Popup();
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nEl contador de las facturas no puede ser vacio";
        //                Popup.Popup();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Popup.ContentText = "\t\t\tGas Station Config Desktop\n\n" + ex.Message;
        //            Popup.Popup();
        //        }
        //    }
        //}

        //private void txtUltimoCierre_Leave(object sender, EventArgs e)
        //{
        //    if (txtUltimoCierre.Text != txtUltimoCierre.Tag.ToString())
        //    {
        //        try
        //        {
        //            if (String.IsNullOrEmpty(txtUltimoCierre.Text))
        //            {
        //                Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nLa fecha del ultimo cierre no puede ser vacía";
        //                Popup.Popup();
        //            }
        //            else
        //            {
        //                DateTime UltimoCierre;
        //                if (!DateTime.TryParse(txtUltimoCierre.Text, out UltimoCierre))
        //                {
        //                    Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nLa fecha del ultimo cierre no tiene el formato correcto";
        //                    Popup.Popup();
        //                }
        //                else
        //                {
        //                    oHelper.ActualizarSincronizacion("UltimoCierre", UltimoCierre.ToString("yyyyMMdd HH:mm"));
        //                    txtUltimoCierre.Tag = txtUltimoCierre.Text;

        //                    Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nLa fecha de ultimo cierre se actualizó satisfactoriamente";
        //                    Popup.Popup();
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Popup.ContentText = "\t\t\tGas Station Config Desktop\n\n" + ex.Message;
        //            Popup.Popup();
        //        }
        //    }
        //}

        //private void btnAbrirRutaSincronizacion_Click(object sender, EventArgs e)
        //{
        //    bfAbrir.Description = "Seleccione la carpeta donde se creará el archivo de Sincronización";
        //    bfAbrir.RootFolder = Environment.SpecialFolder.MyComputer;
        //    bfAbrir.ShowNewFolderButton = true;
        //    bfAbrir.SelectedPath = txtRutaSincronizacion.Text;
        //    bfAbrir.ShowDialog();

        //    txtRutaSincronizacion.Text = bfAbrir.SelectedPath;
        //}

        //private void txtNotasCredito_Leave(object sender, EventArgs e)
        //{
        //    if (txtNotasCredito.Text != txtNotasCredito.Tag.ToString())
        //    {
        //        try
        //        {
        //            if (!String.IsNullOrEmpty(txtNotasCredito.Text))
        //            {
        //                Int32 NotasCredito = 0;
        //                if (!Int32.TryParse(txtNotasCredito.Text, out NotasCredito))
        //                {
        //                    Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nEl contador de las notas crédito debe ser un número";
        //                    Popup.Popup();
        //                }
        //                else
        //                {
        //                    if (NotasCredito < 0)
        //                    {
        //                        Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nEl contador de las notas crédito debe ser un número mayor o igual que cero";
        //                        Popup.Popup();
        //                    }
        //                    else
        //                    {
        //                        oHelper.ActualizarSincronizacion("NotasCredito", NotasCredito.ToString());
        //                        txtNotasCredito.Tag = txtNotasCredito.Text;

        //                        Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nEl contador de las notas crédito se actualizó satisfactoriamente";
        //                        Popup.Popup();
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nEl contador de las notas crédito no puede ser vacio";
        //                Popup.Popup();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Popup.ContentText = "\t\t\tGas Station Config Desktop\n\n" + ex.Message;
        //            Popup.Popup();
        //        }
        //    }
        //}

        //private void btnAbrirRutaSincronizacion_Leave(object sender, EventArgs e)
        //{
        //    if (txtRutaSincronizacion.Text != txtRutaSincronizacion.Tag.ToString())
        //    {
        //        try
        //        {
        //            oHelper.ActualizarParametro("CarpetaSincronizacion", txtRutaSincronizacion.Text);
        //            txtRutaSincronizacion.Tag = txtRutaSincronizacion.Text;
        //        }
        //        catch (Exception ex)
        //        {
        //            Popup.ContentText = "\t\t\tGas Station Config Desktop\n\n" + ex.Message;
        //            Popup.Popup();
        //        }
        //    }
        //}

        //private void chkOpcional_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (chkOpcional.Checked == true)
        //        {
        //            oHelper.ActualizarParametro("RecaudarOpcional", "True");
        //        }
        //        else
        //        {
        //            oHelper.ActualizarParametro("RecaudarOpcional", "False");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void cmbFormaPagoDeshabilitada_Leave(object sender, EventArgs e)
        //{
        //    if (cmbFormaPagoDeshabilitada.Text != cmbFormaPagoDeshabilitada.Tag.ToString())
        //    {
        //        try
        //        {
        //            oHelper.ActualizarParametro("FormaPagoDeshabilitada", cmbFormaPagoDeshabilitada.SelectedValue.ToString());
        //            cmbFormaPagoDeshabilitada.Tag = cmbFormaPagoDeshabilitada.Text;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}

        //private void txtGanaMillones_Leave(object sender, EventArgs e)
        //{
        //    if (txtGanaMillones.Text != txtGanaMillones.Tag.ToString())
        //    {
        //        try
        //        {
        //            if (!String.IsNullOrEmpty(txtGanaMillones.Text))
        //            {
        //                Int32 GanaMillones = 0;
        //                if (!Int32.TryParse(txtGanaMillones.Text, out GanaMillones))
        //                {
        //                    Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nEl contador de las ventas con gana millones debe ser un número";
        //                    Popup.Popup();
        //                }
        //                else
        //                {
        //                    if (GanaMillones < 0)
        //                    {
        //                        Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nEl contador de las ventas con gana millones debe ser un número mayor o igual que cero";
        //                        Popup.Popup();
        //                    }
        //                    else
        //                    {
        //                        oHelper.ActualizarSincronizacion("VentasNumero", GanaMillones.ToString());
        //                        txtGanaMillones.Tag = txtGanaMillones.Text;

        //                        Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nEl contador de las ventas con gana millones se actualizó satisfactoriamente";
        //                        Popup.Popup();
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                Popup.ContentText = "\t\t\tGas Station Config Desktop\n\nEl contador de las ventas con gana millones no puede ser vacio";
        //                Popup.Popup();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Popup.ContentText = "\t\t\tGas Station Config Desktop\n\n" + ex.Message;
        //            Popup.Popup();
        //        }
        //    }
        //}


    }
}
