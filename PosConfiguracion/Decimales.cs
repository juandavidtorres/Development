using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;


namespace PosConfiguracion
{
    public partial class Decimales : Form
    {
        public Int32 Surtidor;

        Helper OHelper = new Helper();
        DataTable dtValores = new DataTable();
        Boolean EsConstruido;
        

        public Decimales()
        {
            InitializeComponent();
        }
        
        private void Decimales_Load(object sender, EventArgs e)
        {
            dtValores = OHelper.RecuperarComboFactores().Tables[0];
            DataGridViewComboBoxColumn ComboPrecio = (DataGridViewComboBoxColumn)this.dtgFactor.Columns["Precio"];
            ComboPrecio.DisplayMember = "DESCRIPCION";
            ComboPrecio.ValueMember = "ID";
            ComboPrecio.DataSource = dtValores;

            DataGridViewComboBoxColumn ComboVolumen = (DataGridViewComboBoxColumn)this.dtgFactor.Columns["Volumen"];
            ComboVolumen.DisplayMember = "DESCRIPCION";
            ComboVolumen.ValueMember = "ID";
            ComboVolumen.DataSource = dtValores;

            DataGridViewComboBoxColumn ComboValor = (DataGridViewComboBoxColumn)this.dtgFactor.Columns["Valor"];
            ComboValor.DisplayMember = "DESCRIPCION";
            ComboValor.ValueMember = "ID";
            ComboValor.DataSource = dtValores;

            DataGridViewComboBoxColumn ComboTotalizador = (DataGridViewComboBoxColumn)this.dtgFactor.Columns["Totalizador"];
            ComboTotalizador.DisplayMember = "DESCRIPCION";
            ComboTotalizador.ValueMember = "ID";
            ComboTotalizador.DataSource = dtValores;

            DataGridViewComboBoxColumn CmbPredeterminacionVolumen = (DataGridViewComboBoxColumn)this.dtgFactor.Columns["PredeterminacionVolumen"];
            CmbPredeterminacionVolumen.DisplayMember = "DESCRIPCION";
            CmbPredeterminacionVolumen.ValueMember = "ID";
            CmbPredeterminacionVolumen.DataSource = dtValores;

            DataGridViewComboBoxColumn CmbPredeterminacionImporte = (DataGridViewComboBoxColumn)this.dtgFactor.Columns["PredeterminacionImporte"];
            CmbPredeterminacionImporte.DisplayMember = "DESCRIPCION";
            CmbPredeterminacionImporte.ValueMember = "ID";
            CmbPredeterminacionImporte.DataSource = dtValores;


            dtgFactor.DataSource = OHelper.RecuperarFactoresdeConversion(Surtidor).Tables[0];
            EsConstruido = true;

        }

        private void dtgFactor_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message + " - " + e.RowIndex);
        }

        private void dtgFactor_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (EsConstruido)
                {
                    OHelper.ActualizaFactordeDivision(Surtidor, Int16.Parse(dtgFactor.Rows[0].Cells["Precio"].Value.ToString()), Int16.Parse(dtgFactor.Rows[0].Cells["Volumen"].Value.ToString()), Int16.Parse(dtgFactor.Rows[0].Cells["Valor"].Value.ToString()), Int16.Parse(dtgFactor.Rows[0].Cells["Totalizador"].Value.ToString()), Int16.Parse(dtgFactor.Rows[0].Cells["PredeterminacionVolumen"].Value.ToString()), Int16.Parse(dtgFactor.Rows[0].Cells["PredeterminacionImporte"].Value.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Credito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}