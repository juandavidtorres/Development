using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Controles
{
    public partial class frmAyuda : Form
    {
        Int16 ValorReturn;
        DataTable oInformacion;
        string ValorSeleccionado;
        string titulo;
        DataGridViewRow oRow = new DataGridViewRow();

        //public delegate void EventHandlerCerrarFormularioAyuda();
        //public event EventHandlerCerrarFormularioAyuda Cerrar;

        public frmAyuda()
        {
            InitializeComponent();
        }

        public string TituloVentana
        {
            set
            {
                titulo= value;
            }
        }

        public Int16 ColumnReturn
        {
            set
            {
                ValorReturn = value;
            }
        }

        public DataTable Informacion
        {
            set 
            {
                oInformacion = value;
            }
        }

        public string ValorRegistroSeleccionado
        {
            get
            {
                return ValorSeleccionado;
            }
        }

        public FormStartPosition UbicacionFormulario
        {
            set
            {
                this.StartPosition = value;
            }
        }

        public DataGridViewRow RowSelect
        {
            get
            {
                return oRow;
            }
        }

        private void frmAyuda_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = titulo;
                if (oInformacion != null)
                {
                    dtgInformacion.DataSource = oInformacion;
                    foreach (DataGridViewColumn dCol in dtgInformacion.Columns)
                    {
                        dCol.ReadOnly = true;
                    }
                }
                else
                    MessageBox.Show("La Consulta no devuelve resultados", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                throw;
            }
        }

        private void dtgInformacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    ValorSeleccionado = dtgInformacion.Rows[e.RowIndex].Cells[ValorReturn].Value.ToString();
                    oRow = dtgInformacion.Rows[e.RowIndex];
                   this.Close();
                   
                }

            }
            catch
            {
                throw;
            }
        }

        private void dtgInformacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dtgInformacion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && dtgInformacion.CurrentRow != null && dtgInformacion.CurrentRow.Index >= 0)
                {
                    ValorSeleccionado = dtgInformacion.CurrentRow.Cells[ValorReturn].Value.ToString();
                    oRow = dtgInformacion.CurrentRow;
                    this.Close();

                }

            }
            catch
            {
                throw;
            }
        }

        //private void frmAyuda_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    try
        //    {
        //        Cerrar();
        //    }
        //    catch (Exception es)
        //    {

        //        MessageBox.Show(es.Message);
        //    }

        //}

    }
}