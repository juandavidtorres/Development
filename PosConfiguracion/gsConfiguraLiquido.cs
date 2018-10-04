using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using POSstation.Fabrica;

namespace PosConfiguracion
{
    public partial class gsConfiguraLiquido : UserControl
    {
        #region "       Declaracion de Variables        "
        Boolean EsGridDispositivosConstruido;
        Boolean EsGridTanquesConstruido;
        Boolean EsGridTanqueProductoConstruido;
        Boolean EsGridTanqueConectadoConstruido;
        Helper oHelper = new Helper();
        string NombreControl;
        #endregion

        #region "   Propiedades del Control "

        public string NameControl
        {
            get
            {
                return NombreControl;
            }
            set
            {
                NombreControl = value;
            }
        }

        #endregion

        public gsConfiguraLiquido()
        {
            InitializeComponent();
        }

        public void IniciarForma()
        {
            try
            {
                if (grdAforoTanque.IsCurrentCellInEditMode)
                {
                    grdAforoTanque.CancelEdit();
                }

                EsGridDispositivosConstruido = true;

                DataGridViewComboBoxColumn ComboPuerto = (DataGridViewComboBoxColumn)this.dgvDispositivos.Columns["IdPuerto"];
                ComboPuerto.DisplayMember = "Puerto";
                ComboPuerto.ValueMember = "IdPuerto";
                ComboPuerto.DataSource = oHelper.RecuperarPuertos().Tables[0];

                DataGridViewComboBoxColumn ComboTComunicacion = (DataGridViewComboBoxColumn)this.dgvDispositivos.Columns["IdTipoComunicacionDisp"];
                ComboTComunicacion.DisplayMember = "TipoComunicacion";
                ComboTComunicacion.ValueMember = "IdTipoComunicacionDisp";
                ComboTComunicacion.DataSource = oHelper.RecuperarTipoComunicacionDispositivo();

                dgvDispositivos.DataSource = oHelper.RecuperarDispositivosMedicion();
                EsGridDispositivosConstruido = true;

                DataGridViewComboBoxColumn ComboDispositivo = (DataGridViewComboBoxColumn)this.dgvTanques.Columns["Dispositivo"];
                ComboDispositivo.DisplayMember = "Nombre";
                ComboDispositivo.ValueMember = "IdDispositivo";
                ComboDispositivo.DataSource = oHelper.RecuperarDispositivosMedicion();

                dgvTanques.DataSource = oHelper.RecuperarTanquesDataTable();
                EsGridTanquesConstruido = true;

                DataGridViewComboBoxColumn ComboTanque = (DataGridViewComboBoxColumn)this.dgvTanqueProducto.Columns["IdTanque"];
                ComboTanque.DisplayMember = "Nombre";
                ComboTanque.ValueMember = "IdTanque";
                ComboTanque.DataSource = oHelper.RecuperarTanquesDataTable();

                DataGridViewComboBoxColumn ComboProd = (DataGridViewComboBoxColumn)this.dgvTanqueProducto.Columns["IdProducto"];
                ComboProd.DisplayMember = "Nombre";
                ComboProd.ValueMember = "IdProducto";
                ComboProd.DataSource = oHelper.RecuperarProductosDataset().Tables[0];

                dgvTanqueProducto.DataSource = oHelper.RecuperarTanqueProducto();
                EsGridTanqueProductoConstruido = true;

                RecuperarTanques();
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
                    if (!oHelper.ValidarPermisosPorAccion(frmMain.UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionDispositivosdemedicion))
                    {
                        this.dgvDispositivos.Enabled = false;
                    }

                    if (!oHelper.ValidarPermisosPorAccion(frmMain.UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionTanques))
                    {
                        this.dgvTanques.Enabled = false;
                    }

                    if (!oHelper.ValidarPermisosPorAccion(frmMain.UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionProductosatanques))
                    {
                        this.dgvTanqueProducto.Enabled = false;
                    }

                    if (!oHelper.ValidarPermisosPorAccion(frmMain.UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionAforo))
                    {
                        this.panelAforo.Enabled = false;
                    }

                    //if (!oHelper.ValidarPermisosPorAccion(frmMain.UserId.Value, (int)AccionesConfiguradorColombia.ConfiguracionTanquesConectados))
                    //{
                    //    this.dgvTanqueConectado.Enabled = false;
                    //}
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

        private void dgvTanques_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (EsGridTanquesConstruido)
                {
                    Int16 IdDispositivo;
                    Boolean EsActivo;
                    
                    if(string.IsNullOrEmpty(dgvTanques.Rows[e.RowIndex].Cells[6].Value.ToString()))
                    {
                        IdDispositivo = -1;
                     }
                     else
                     {
                         IdDispositivo = Int16.Parse(dgvTanques.Rows[e.RowIndex].Cells[6].Value.ToString());
                      }

                      if (string.IsNullOrEmpty(dgvTanques.Rows[e.RowIndex].Cells[7].Value.ToString()))
                      {
                          EsActivo = false;
                      }
                      else
                      {
                          EsActivo = Boolean.Parse(dgvTanques.Rows[e.RowIndex].Cells[7].Value.ToString());
                      }

                    if (!string.IsNullOrEmpty(dgvTanques.Rows[e.RowIndex].Cells[1].Value.ToString()) && !string.IsNullOrEmpty(dgvTanques.Rows[e.RowIndex].Cells[4].Value.ToString()))
                    {
                        if (string.IsNullOrEmpty(dgvTanques.Rows[e.RowIndex].Cells[0].Value.ToString()))
                        {
                            oHelper.InsertarTanque(dgvTanques.Rows[e.RowIndex].Cells[1].Value.ToString(), dgvTanques.Rows[e.RowIndex].Cells[2].Value.ToString(), null, Decimal.Parse(dgvTanques.Rows[e.RowIndex].Cells[4].Value.ToString()), 0 , IdDispositivo, EsActivo);
                            //EventArgs ev = new EventArgs();
                            //this.NotificarCambios(sender, ev);
                        }
                        else
                        {
                            oHelper.ModificarTanque(Int16.Parse(dgvTanques.Rows[e.RowIndex].Cells[0].Value.ToString()), dgvTanques.Rows[e.RowIndex].Cells[1].Value.ToString(), dgvTanques.Rows[e.RowIndex].Cells[2].Value.ToString(), null, Decimal.Parse(dgvTanques.Rows[e.RowIndex].Cells[4].Value.ToString()), 0, IdDispositivo, EsActivo);
                            //EventArgs ev = new EventArgs();
                            //this.NotificarCambios(sender, ev);

                        }

                        //dgvTanques.DataSource = oHelper.RecuperarTanquesDataTable();
                        this.IniciarForma();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dgvTanqueProducto_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (EsGridTanqueProductoConstruido)
                {
                    if (!string.IsNullOrEmpty(dgvTanqueProducto.Rows[e.RowIndex].Cells[0].Value.ToString()) && !string.IsNullOrEmpty(dgvTanqueProducto.Rows[e.RowIndex].Cells[1].Value.ToString()))
                    {
                        oHelper.InsertarTanqueProducto( Int16.Parse(dgvTanqueProducto.Rows[e.RowIndex].Cells[0].Value.ToString()), Int16.Parse(dgvTanqueProducto.Rows[e.RowIndex].Cells[1].Value.ToString()));
                        //dgvTanqueProducto.DataSource = oHelper.RecuperarTanqueProducto();
                        //EventArgs ev = new EventArgs();
                        //this.NotificarCambios(sender, ev);
                        this.IniciarForma();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dgvTanqueProducto_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(dgvTanqueProducto.Rows[e.Row.Index].Cells[0].Value.ToString()) && !string.IsNullOrEmpty(dgvTanqueProducto.Rows[e.Row.Index].Cells[1].Value.ToString()))
                {
                    if (MessageBox.Show("¿Desea eliminar este Producto que se encuentra en la posición #" + (e.Row.Index + 1) + "?", "FullStation®",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        Int16 IdTanque = Int16.Parse(dgvTanqueProducto.Rows[e.Row.Index].Cells[0].Value.ToString());
                        Int16 IdProducto = Int16.Parse(dgvTanqueProducto.Rows[e.Row.Index].Cells[1].Value.ToString());
                        oHelper.EliminarTanqueProducto(IdTanque, IdProducto);

                        //EventArgs ev = new EventArgs();
                        //this.NotificarCambios(sender, ev);

                        MessageBox.Show("El Producto fue eliminado satisfactoriamente");
                        //this.IniciarForma();
                        //Popup.Popup();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show(ex.Message);
            }
        }

        
        private void dgvDispositivos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{

            //    if (e.ColumnIndex == 2)
            //    {
            //        if (dgvDispositivos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "1")
            //        {
            //            dgvDispositivos.Rows[e.RowIndex].Cells["IdPuerto"].ReadOnly = true;
            //            dgvDispositivos.Rows[e.RowIndex].Cells["DireccionIP"].ReadOnly = false;
            //        }
            //        else
            //        {
            //            dgvDispositivos.Rows[e.RowIndex].Cells["IdPuerto"].ReadOnly = false;
            //            dgvDispositivos.Rows[e.RowIndex].Cells["DireccionIP"].ReadOnly = true;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        
        private void dgvTanqueConectado_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (EsGridTanqueConectadoConstruido)
                {
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dgvTanqueConectado_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
               
                
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show(ex.Message);
            }
        }

       
        private void cmbTanqueAforo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTanqueAforo.SelectedIndex != -1)
            {
                this.RecuperarAforoTanque(Int32.Parse(cmbTanqueAforo.SelectedValue.ToString()));
            }
        }

        private void RecuperarAforoTanque(Int32 idTanque)
        {
            try
            {
                this.grdAforoTanque.DataSource = oHelper.RecuperarAforoTanque(idTanque).Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecuperarTanques()
        {
            try
            {
                cmbTanqueAforo.DisplayMember = "Nombre";
                cmbTanqueAforo.ValueMember = "IdTanque";
                cmbTanqueAforo.DataSource = oHelper.RecuperarTanquesDataTable();

                if (cmbTanqueAforo.SelectedIndex != -1)
                {
                    this.RecuperarAforoTanque(Int32.Parse(cmbTanqueAforo.SelectedValue.ToString()));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTanqueAforo.SelectedIndex != -1)
                {
                    String valor = txtAltura.Text;
                    if (!String.IsNullOrEmpty(valor))
                    {
                        Decimal Temp = 0;
                        if (!Decimal.TryParse(valor, out Temp))
                        {
                            MessageBox.Show("La altura debe ser un número");
                            return;
                        }
                        else
                        {
                            if (Temp < 0)
                            {
                                MessageBox.Show("La altura debe ser un número mayor o igual que cero");
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("La altura no puede ser vacia");
                        return;
                    }

                    valor = txtCantidad.Text;

                    if (!String.IsNullOrEmpty(valor))
                    {
                        Decimal Temp = 0;
                        if (!Decimal.TryParse(valor, out Temp))
                        {
                            MessageBox.Show("La cantidad debe ser un número");
                            return;
                        }
                        else
                        {
                            if (Temp < 0)
                            {
                                MessageBox.Show("La cantidad debe ser un número mayor o igual que cero");
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cantidad no puede ser vacia");
                        return;
                    }

                    oHelper.ActualizarAforoTanque(Int32.Parse(cmbTanqueAforo.SelectedValue.ToString()), null, Decimal.Parse(txtAltura.Text), Decimal.Parse(txtCantidad.Text));
                    this.RecuperarAforoTanque(Int32.Parse(cmbTanqueAforo.SelectedValue.ToString()));
                    txtAltura.Text = "";
                    txtCantidad.Text = "";
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado un tanque");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdAforoTanque_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar el registro #" + (e.Row.Index + 1) + " del aforo?", "FullStation Config Desktop®",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    oHelper.EliminarAforoTanque(Int32.Parse(grdAforoTanque.Rows[e.Row.Index].Cells["grdAforoIdAforo"].Value.ToString()));
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

        private void grdAforoTanque_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (cmbTanqueAforo.SelectedIndex != -1)
                {
                    this.RecuperarAforoTanque(Int32.Parse(cmbTanqueAforo.SelectedValue.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDispositivos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (EsGridDispositivosConstruido)
                {
                    if (!string.IsNullOrEmpty(dgvDispositivos.Rows[e.RowIndex].Cells[1].Value.ToString()) && !string.IsNullOrEmpty(dgvDispositivos.Rows[e.RowIndex].Cells["IdTipoComunicacionDisp"].Value.ToString()))
                    {
                        if (string.IsNullOrEmpty(dgvDispositivos.Rows[e.RowIndex].Cells[0].Value.ToString()))
                        {
                            oHelper.InsertarDispositivoMedicion(dgvDispositivos.Rows[e.RowIndex].Cells[1].Value.ToString(), (dgvDispositivos.Rows[e.RowIndex].Cells[2].Value.ToString() == "True" || dgvDispositivos.Rows[e.RowIndex].Cells[2].Value.ToString() == "1" ? true : false),
                                (string.IsNullOrEmpty(dgvDispositivos.Rows[e.RowIndex].Cells[3].Value.ToString()) ? Int16.Parse("-1") : Int16.Parse(dgvDispositivos.Rows[e.RowIndex].Cells[3].Value.ToString())), Int16.Parse(dgvDispositivos.Rows[e.RowIndex].Cells["IdTipoComunicacionDisp"].Value.ToString()), dgvDispositivos.Rows[e.RowIndex].Cells["DireccionIP"].Value.ToString(), dgvDispositivos.Rows[e.RowIndex].Cells["PuertoIP"].Value.ToString());
                        }
                        else
                        {
                            oHelper.ModificarDispositivoMedicion(Int16.Parse(dgvDispositivos.Rows[e.RowIndex].Cells[0].Value.ToString()), dgvDispositivos.Rows[e.RowIndex].Cells[1].Value.ToString(), (dgvDispositivos.Rows[e.RowIndex].Cells[2].Value.ToString() == "True" || dgvDispositivos.Rows[e.RowIndex].Cells[2].Value.ToString() == "1" ? true : false),
                                (string.IsNullOrEmpty(dgvDispositivos.Rows[e.RowIndex].Cells[3].Value.ToString()) ? Int16.Parse("-1") : Int16.Parse(dgvDispositivos.Rows[e.RowIndex].Cells[3].Value.ToString())), Int16.Parse(dgvDispositivos.Rows[e.RowIndex].Cells["IdTipoComunicacionDisp"].Value.ToString()), dgvDispositivos.Rows[e.RowIndex].Cells["DireccionIP"].Value.ToString(), dgvDispositivos.Rows[e.RowIndex].Cells["PuertoIP"].Value.ToString());
                        }
                        BeginInvoke(new MethodInvoker(IniciarForma));
                        //this.IniciarForma();
                    }
                }
            }
            catch (InvalidOperationException ex)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dgvDispositivos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //
        }

        private void dgvDispositivos_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(dgvDispositivos.Rows[e.Row.Index].Cells[0].Value.ToString()))
                {
                    if (MessageBox.Show("¿Desea eliminar este Dispositivo que se encuentra en la posición #" + (e.Row.Index + 1) + "?", "FullStation®",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                         MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        Int16 IdDispositivo = Int16.Parse(dgvDispositivos.Rows[e.Row.Index].Cells[0].Value.ToString());
                        oHelper.EliminarDispositivoMedicion(IdDispositivo);

                        MessageBox.Show("El Dispositivo ha sido eliminado satisfactoriamente");
                        this.IniciarForma();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show(ex.Message);
            }
        }

        
       

    

       
    }
}