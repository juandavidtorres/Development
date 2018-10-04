using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using Controles;

namespace  PosStation.Generaciones
{
    public partial class Generacion : UserControl
    {
        #region "   Declaracion de Variables    "


        Helper oHelper = new Helper();
        DataTable oFacturar = new DataTable();

        #endregion

        public Generacion()
        {
            InitializeComponent();
        }

        public void IniciarForma()
        { 
            this.dtpFechaInicial.Value = DateTime.Now;

            cmbFacturacion.DisplayMember = "Tipo";
            cmbFacturacion.ValueMember = "Id";
            cmbFacturacion.DataSource = oHelper.RecuperarTipoFacturacion("*").Tables[0];

            dtgCreditos.Visible = false;
        }

        private void btnLoadCreditos_Click(object sender, EventArgs e)
        {
            try
            {
                oFacturar.Clear();
                oFacturar = oHelper.RecuperarEncabezadoCredito(cmbFacturacion.Text.Trim(), Helper.oAccion.EsFacturacion).Tables[0];
                if (oFacturar.Rows.Count > 0)
                {
                    
                    dtgCreditos.DataSource = oFacturar;
                }

                dtgCreditos.Visible = true;
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        public event EventHandler oClosed;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            oClosed(sender, e);
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            Boolean EstadoProceso = false;

            try
            {
               
                foreach (DataGridViewRow Row in dtgCreditos.Rows)
                {
                    if (Row.Cells["EsFacturable"].Value  != null)
                    {
                        if (string.IsNullOrEmpty(Row.Cells["EsFacturable"].Value.ToString()) == false)
                        {
                            if (oHelper.GeneraFacturacion(Int32.Parse(Row.Cells[1].Value.ToString()), dtpFechaInicial.Value.ToString("yyyyMMdd")) == false)
                            {
                                Popup.ContentText = "No se realizaron inserciones.";
                                Popup.Popup();
                                EstadoProceso = true;
                            }
                        }
                    }
                }

                if (EstadoProceso == false )
                {
                    oFacturar.Rows.Clear();
                    Popup.ContentText = "Proceso Generado Satisfactoriamente";
                    Popup.Popup();
                }
                else
                {
                    Popup.ContentText = "Se presentaron problemas durante el proceso de Facturacion";
                    Popup.Popup();
                }
                dtgCreditos.Refresh();

            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow oRow;
                DataRow oFila;      

                Controles.frmAyuda oAyuda = new frmAyuda();
                oAyuda.Informacion = oHelper.RecuperarEncabezadoCredito("*", Helper.oAccion.EsComodin).Tables[0];
                oAyuda.UbicacionFormulario = FormStartPosition.CenterScreen;
                oAyuda.ShowDialog();
                if (string.IsNullOrEmpty(oAyuda.ValorRegistroSeleccionado) == false)
                {
                    oRow = oAyuda.RowSelect;
                    foreach (DataGridViewRow oGRow in dtgCreditos.Rows)
                    {
                        if (oGRow.Cells[1].Value.ToString().Trim() == oRow.Cells[0].Value.ToString().Trim())
                        {
                            Popup.ContentText = "El Cliente que intenta ingresar ya existe";
                            Popup.Popup();
                            return;
                        }
                        
                    }


                    oFila = oFacturar.NewRow();
                    for (int i = 0; i<= oRow.Cells.Count-1; i ++)
                    {
                        oFila[i] = oRow.Cells[i].Value;
                    }
                    oFacturar.Rows.Add(oFila);
                    dtgCreditos.DataSource = oFacturar;
                }
                oAyuda.Dispose();
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }

        }

    }
}
