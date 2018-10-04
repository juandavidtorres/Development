using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PosConfiguracion
{
    public partial class frmSearch : Form
    {
   
        private string ColumnNameValue { get; set; }

        public object Value { get; private set; }
        
        public frmSearch(string title, DataTable table, string columnNameValue)
        {
            InitializeComponent();
            this.lblMensaje.Text = title;
            this.dtvData.DataSource = table;
            this.ColumnNameValue = columnNameValue;
            this.Value = null;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtvData_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dtvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Value = dtvData.Rows[e.RowIndex].Cells[this.ColumnNameValue].Value;
                if (this.Value != null) this.Close();
            }
            catch { throw; }
        }

    }
}
