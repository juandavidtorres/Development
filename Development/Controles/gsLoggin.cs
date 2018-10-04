using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Controles
{
    public partial class gsLoggin :UserControl
    {

        #region "   Declaracion de Variables    "
            ContextMenuStrip oMenu = new ContextMenuStrip();
            MenuItem oItem = new MenuItem();
            MenuStrip ms = new MenuStrip();
            ToolStripMenuItem oMenuItem = new ToolStripMenuItem("", null, null, "");
            string oColumnas = "LogId,FechaHora,Message,Win32ThreadId,CategoryName,Propiedad1,Propiedad2,Propiedad3," +
                               "Propiedad4|Propiedad5;Propiedad6:Propiedad7,Propiedad8,Propiedad9,Propiedad10";
            DataTable oTable = new DataTable();
          
        #endregion

        #region "   Declaracion de Propiedades  "
            
            public string Columnas
            {
                set 
                {
                    oColumnas = value;
                }
            }

            public DataTable Informacion
        {
            set
            {
                oTable = value;
                this.IniciarGrid();
            }
        }

        #endregion

        public gsLoggin()
        {
            InitializeComponent();
            IniciarForma();
        }

        private void IniciarForma()
        {
            oMenu.Opening +=new CancelEventHandler(this.oMenu_Opening);
            oMenu.Click +=new EventHandler(this.oMenu_Click);
            oMenu.ItemClicked +=new ToolStripItemClickedEventHandler(this.oMenu_ItemClicked);
            ToolStrip ts = new ToolStrip();

            ms.Items.Add(oMenuItem);
            oMenuItem.DropDown = oMenu;
            this.ContextMenuStrip = oMenu;
            IniciarGrid();
            
        }

        private void oMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Acquire references to the owning control and item.
            Control c = oMenu.SourceControl as Control;
            ToolStripDropDownItem tsi = oMenu.OwnerItem as ToolStripDropDownItem;

            // Clear the ContextMenuStrip control's Items collection.
            oMenu.Items.Clear();
            oMenu.Items.Add("Exportar");
            oMenu.Items.Add("Definir Busqueda");
            oMenu.Items.Add("Refrescar");

            // Set Cancel to false. 
            // It is optimized to true based on empty entry.
            e.Cancel = false;
        }

        private void oMenu_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Ingreso por Menu");  
        }

        private void oMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            oMenu.Close();
            switch (e.ClickedItem.Text)
            {
                case "Exportar":
                    this.Exportar();
                break;
                case "Refrescar":
                    this.Refresh(sender, e);
                break;
            case "Definir Busqueda":
                this.CriterioBusqueda(sender, e);
                break;
            }
            
        }

        private void IniciarGrid()
        {
            try
            {
                if (oTable.Rows.Count > 0 || oTable != null)
                {
                    dtgResultado.DataSource = oTable;
                }
                else
                {
                    string Separador = ",;:.|";
                    char[] oDelimita = Separador.ToCharArray();
                    string[] oHeader = oColumnas.Split(oDelimita);

                    foreach (string oCol in oHeader)
                    {
                        DataGridViewColumn oDataCol = new DataGridViewColumn();
                        oDataCol.HeaderText = oCol;
                        oDataCol.Name = oCol;
                        dtgResultado.Columns.Add(oDataCol);
                        //MessageBox.Show(oCol);

                    }
                }

                cmbColumnas.Items.Clear();
                cmbColumnas.Items.Add("Todas");
                foreach (DataGridViewColumn oColumna in dtgResultado.Columns)
                {
                    cmbColumnas.Items.Add(oColumna.HeaderText);
                }
                cmbColumnas.SelectedIndex = 0;
            }
            catch
            {
                
                throw;
            }
        }

        private void Exportar()
        {
            try
            {
                string sPath;
                

                saveFileDialog1.Title = "Exportar Datos";
                saveFileDialog1.Filter = "csv (*.csv)|*.csv";
                saveFileDialog1.ShowDialog();
                if (!String.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    sPath = saveFileDialog1.FileName;
                }
                else
                {
                    sPath = Application.StartupPath + "\\Loging_" + DateTime.Now.ToString() + ".csv";
                }

                /*      CREACION DEL ARCHIVO    */

                StreamWriter sw = new StreamWriter(sPath);
                string oTexto = "";

                foreach (DataGridViewRow oFila in dtgResultado.Rows)
                {
                    
                    foreach (DataGridViewCell oCell in oFila.Cells)
                    {
                        oTexto += oCell.Value.ToString().ToUpper()  + ";" ;
                        
                    }
                    sw.WriteLine(oTexto);
                    oTexto = "";
                    
                }
                sw.Close();
                MessageBox.Show("Proceso Generado satisfactoriamente.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void Buscar(string TextoBuscado, string ColumnaBusqueda)
        {
            String oTexto;
            if (ColumnaBusqueda == "Todas")
            {
                //dtgResultado.Rows[0].Cells[ColumnaBusqueda].Value 
                foreach (DataGridViewRow oFila in dtgResultado.Rows)
                {
                    foreach (DataGridViewCell oCell in oFila.Cells)
                    {
                        oTexto = oCell.Value.ToString().ToUpper();

                        if (oTexto.Contains(TextoBuscado))
                            //this.dtgResultado.Rows[oFila.Index].Selected= true;
                            this.dtgResultado.Rows[oFila.Index].DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                }
            }
            else
            {
                //dtgResultado.Rows[0].Cells[ColumnaBusqueda].Value 
                foreach (DataGridViewRow oFila in dtgResultado.Rows)
                {
                    oTexto = oFila.Cells[ColumnaBusqueda].Value.ToString().ToUpper();   
                        if (oTexto.Contains(TextoBuscado))
                            this.dtgResultado.Rows[oFila.Index].DefaultCellStyle.BackColor = Color.LightBlue;
                    
                }
            }
        }

        public event EventHandler oClose;
        private void mnuSalir_Click(object sender, EventArgs e)
        {        
            this.Visible = false;
            this.Dispose();
            this.oClose(sender, e);
        }

        public event EventHandler oRefresh;
        private void Refresh(object sender, EventArgs e)
        {
            oRefresh(sender, e);
        }

        private void dtgResultado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mnuBuscar_Click(object sender, EventArgs e)
        {
            this.ColorearCeldasenBlanco();
            this.Buscar(txtBusqueda.Text.ToUpper(), cmbColumnas.Text);
        }

        public event EventHandler oSolicitaFechaFiltro;
        private void CriterioBusqueda(Object sender, EventArgs e)
        {
            this.ColorearCeldasenBlanco();
            this.oSolicitaFechaFiltro(sender, e);
        }

        private void ColorearCeldasenBlanco()
        {
            foreach (DataGridViewRow oFila in dtgResultado.Rows)
            {
                this.dtgResultado.Rows[oFila.Index].DefaultCellStyle.BackColor = Color.White;
            }
        }

    }

}
