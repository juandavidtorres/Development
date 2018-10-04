using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;

namespace gasolutions.UInterface
{
    public partial class gsConsigTransportadora : ItemMenu
    {
        #region "Declaracion de Variables"
        string Nombre;
        //Boolean EsConstruido =false;
        Decimal oDecimal = 0;
        public EventHandler oClosed;
        #endregion
        
        public gsConsigTransportadora()
        {
            InitializeComponent();
        }

        public void IniciarForma()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Helper oHelper = new Helper();
                dgvConsignar.DataSource = oHelper.RecuperarSobresParaConsignar();
                dgvConsignar.Enabled = true;
                mnuGuardar.Enabled = true;
                mnuImprimir.Enabled = false;
                tssMensaje.Text = "Consignación No. : ";
                tssValor1.Text = "0";
                lblNoConsignacion.Text = "0";

                cmbTransportadora.DisplayMember = "Descripcion";
                cmbTransportadora.ValueMember = "IdTransportadora";
                cmbTransportadora.DataSource = oHelper.RecuperarTransportadoras();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "IniciarControl", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } 
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.RiseEvent_OnClosed(sender, e);
        }

        private void mnuCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                oDecimal = 0;
                foreach (DataGridViewRow fila in dgvConsignar.Rows)
                {
                    if (fila.Cells["Marcar"].Value != null)
                    {
                        if (Boolean.Parse(fila.Cells["Marcar"].Value.ToString()) == true)
                        {
                            oDecimal += (Decimal)(System.Convert.ChangeType(fila.Cells["Valor"].Value.ToString(), typeof(System.Decimal))) * (Decimal)(System.Convert.ChangeType(fila.Cells["NoSobres"].Value.ToString(), typeof(System.Decimal)));
                        }
                    }

                    tssValor1.Text = oDecimal.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Calcular", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mnuGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Consignaciones = "";
                oDecimal = 0;
                Int32 NoPicos = 0;
                Int32 NoSobres = 0;
                Decimal ValorPicos = 0;
                Decimal ValorSobres = 0;

                if (cmbTransportadora.SelectedValue == null)
                {
                    throw new Exception("Debe seleccionar una Transportadora Valida");
                }

                foreach (DataGridViewRow fila in dgvConsignar.Rows)
                {
                    if (fila.Cells["Marcar"].Value != null)
                    {
                        if (Boolean.Parse(fila.Cells["Marcar"].Value.ToString()) == true)
                        {
                            Consignaciones = Consignaciones + fila.Cells["IdConsignacion"].Value.ToString() + '|';

                            if (fila.Cells["IdTipo"].Value.ToString() == "0")
                            {
                                NoPicos += (Int32)(System.Convert.ChangeType(fila.Cells["NoSobres"].Value.ToString(), typeof(System.Int32)));
                                ValorPicos += (Int32)(System.Convert.ChangeType(fila.Cells["NoSobres"].Value.ToString(), typeof(System.Int32))) * (Decimal)(System.Convert.ChangeType(fila.Cells["Valor"].Value.ToString(), typeof(System.Decimal)));
                            }
                            else
                            {
                                NoSobres += (Int32)(System.Convert.ChangeType(fila.Cells["NoSobres"].Value.ToString(), typeof(System.Int32)));
                                ValorSobres += (Int32)(System.Convert.ChangeType(fila.Cells["NoSobres"].Value.ToString(), typeof(System.Int32))) * (Decimal)(System.Convert.ChangeType(fila.Cells["Valor"].Value.ToString(), typeof(System.Decimal)));
                            }

                            oDecimal += (Int32)(System.Convert.ChangeType(fila.Cells["NoSobres"].Value.ToString(), typeof(System.Int32))) * (Decimal)(System.Convert.ChangeType(fila.Cells["Valor"].Value.ToString(), typeof(System.Decimal)));
                            tssValor1.Text = oDecimal.ToString("N2");
                        }
                    }
                }

                if (dgvConsignar.Rows.Count > 0 && Consignaciones == "")
                {
                    throw new Exception("Seleccione al menos un sobre");
                }

                if (oDecimal > 0)
                {
                    if (MessageBox.Show("El valor consignar es de : " + oDecimal.ToString("N2"), "Guardar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Helper oHelper = new Helper();
                        lblNoConsignacion.Text = oHelper.InsertarConsignacionTransportadora(dateTimePicker1.Value.ToString("yyyyMMdd"), NoPicos, ValorPicos, NoSobres, ValorSobres, Int32.Parse(cmbTransportadora.SelectedValue.ToString()), Consignaciones).ToString();
                        tssMensaje.Text = "Consignación No. : " + lblNoConsignacion.Text;
                        dgvConsignar.Enabled = false;
                        mnuGuardar.Enabled = false;
                        mnuImprimir.Enabled = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mnuNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForma();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mnuImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 NroConsignacion = 0;
                NroConsignacion = (Int32)(System.Convert.ChangeType(lblNoConsignacion.Text, typeof(System.Int32)));
                if (NroConsignacion > 0 && !String.IsNullOrEmpty(lblNoConsignacion.Text))
                {
                    Impresion oImpresion = new Impresion();
                    oImpresion.IdConsignacionTransp = Int32.Parse(lblNoConsignacion.Text);
                    oImpresion.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvConsignar_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (Convert.ToBoolean(dgvConsignar.Rows[e.RowIndex].Cells["Marcar"].Value) == true)
                    {
                        dgvConsignar.Rows[e.RowIndex].Cells["Marcar"].Value = false;
                    }
                    else
                    {
                        dgvConsignar.Rows[e.RowIndex].Cells["Marcar"].Value = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void gsConsigTransportadora_Load(object sender, EventArgs e)
        {

        }
    }
}
