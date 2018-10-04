using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;

namespace PosConfiguracion
{
    public partial class gsProducto : UserControl
    {
        #region "   Declaracion de Variables    "
            Helper oHelper = new Helper();
            string NombreControl;
            Boolean esConstruido = false; 
        #endregion

        #region "   Declaracion de Propiedades    "
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

        public gsProducto()
        {
            InitializeComponent();
        }

        public void iniciarForma()
        {
            DataGridViewComboBoxColumn Combo = (DataGridViewComboBoxColumn)this.dtgProductos.Columns["Unidad"];
            Combo.DisplayMember = "Descripcion";
            Combo.ValueMember = "IdUnidad";
            Combo.DataSource = oHelper.RecuperarUnidadMedida();

            dtgProductos.DataSource = oHelper.RecuperarProductosMedida();
            esConstruido = true;
        }

        public event EventHandler oClosed;
        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.oClosed(sender, e);
        }

        private void dtgProductos_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dtgProductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Boolean estado;
                String codigoContable, CodigoTerpel ;
                if (esConstruido)
                {
                    if (!String.IsNullOrEmpty(dtgProductos.Rows[e.RowIndex].Cells["Producto"].Value.ToString()) &&
                        !String.IsNullOrEmpty(dtgProductos.Rows[e.RowIndex].Cells["Unidad"].Value.ToString()) )
                        
                    {
                        if (!String.IsNullOrEmpty(dtgProductos.Rows[e.RowIndex].Cells["IdProducto"].Value.ToString()))
                        {
                            if (String.IsNullOrEmpty(dtgProductos.Rows[e.RowIndex].Cells["CodigoContable"].Value.ToString()))
                            {
                                codigoContable = null;
                            }
                            else
                            {
                                codigoContable = dtgProductos.Rows[e.RowIndex].Cells["CodigoContable"].Value.ToString();
                            }
                            CodigoTerpel = dtgProductos.Rows[e.RowIndex].Cells["CodigoTerpel"].Value.ToString();
                            if (String.IsNullOrEmpty(CodigoTerpel))
                            {
                                oHelper.InsertarProducto(Int16.Parse(dtgProductos.Rows[e.RowIndex].Cells["IdProducto"].Value.ToString()),
                                                     dtgProductos.Rows[e.RowIndex].Cells["Producto"].Value.ToString(),
                                                     Boolean.Parse(dtgProductos.Rows[e.RowIndex].Cells["Lectura"].Value.ToString()),
                                                     Int16.Parse(dtgProductos.Rows[e.RowIndex].Cells["Unidad"].Value.ToString()), codigoContable, null,
                                                     dtgProductos.Rows[e.RowIndex].Cells["CodigoMenoCash"].Value.ToString());

                            }
                            else
                            {
                                oHelper.InsertarProducto(Int16.Parse(dtgProductos.Rows[e.RowIndex].Cells["IdProducto"].Value.ToString()),
                                                     dtgProductos.Rows[e.RowIndex].Cells["Producto"].Value.ToString(),
                                                     Boolean.Parse(dtgProductos.Rows[e.RowIndex].Cells["Lectura"].Value.ToString()),
                                                     Int16.Parse(dtgProductos.Rows[e.RowIndex].Cells["Unidad"].Value.ToString()), codigoContable, Convert.ToInt64(CodigoTerpel),
                                                     dtgProductos.Rows[e.RowIndex].Cells["CodigoMenoCash"].Value.ToString());

                            }                            
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(dtgProductos.Rows[e.RowIndex].Cells["Lectura"].Value.ToString()))
                            {
                                estado = false;
                            }
                            else
                            {
                                estado = Boolean.Parse(dtgProductos.Rows[e.RowIndex].Cells["Lectura"].Value.ToString());
                            }

                            if (String.IsNullOrEmpty(dtgProductos.Rows[e.RowIndex].Cells["CodigoContable"].Value.ToString()))
                            {
                                codigoContable = null;
                            }
                            else
                            {
                                codigoContable = dtgProductos.Rows[e.RowIndex].Cells["CodigoContable"].Value.ToString();
                            }

                            CodigoTerpel = dtgProductos.Rows[e.RowIndex].Cells["CodigoTerpel"].Value.ToString();
                            if (String.IsNullOrEmpty(CodigoTerpel))
                            {
                                oHelper.InsertarProducto(0, dtgProductos.Rows[e.RowIndex].Cells["Producto"].Value.ToString(),
                                                     estado, Int16.Parse(dtgProductos.Rows[e.RowIndex].Cells["Unidad"].Value.ToString()), codigoContable, null,
                                                     dtgProductos.Rows[e.RowIndex].Cells["CodigoMenoCash"].Value.ToString());
                            }
                            else
                            {
                                oHelper.InsertarProducto(0, dtgProductos.Rows[e.RowIndex].Cells["Producto"].Value.ToString(),
                                                     estado, Int16.Parse(dtgProductos.Rows[e.RowIndex].Cells["Unidad"].Value.ToString()), codigoContable, Convert.ToInt64(CodigoTerpel),
                                                     dtgProductos.Rows[e.RowIndex].Cells["CodigoMenoCash"].Value.ToString());

                            }                            
                        }
                        dtgProductos.DataSource = oHelper.RecuperarProductosMedida();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
