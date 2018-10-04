using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using Microsoft.Office.Interop.Excel;
using System.Drawing.Printing;
//using excel = Microsoft.Office.Interop.Excel;




namespace gasolutions.UInterface
{
    public partial class VentasFueraSistemas : UserControl
    {
        string Nombre;
        public EventHandler oClosed;
        Helper oDataAccess = new Helper();
        FrmInsertarLecturas controlDatos;
        PrinterSettings prtSettings;
        private int i;
        public VentasFueraSistemas()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                
                grdTurnos.DataSource = oDataAccess.RecuperarTurnosConSaltodeLectura(dtpFechaTurnos.Value);
                //if (grdTurnos.RowCount > 0)
                //{                    
                //    this.ClientSize = new System.Drawing.Size(574,260);
                //}
                //else
                //{
                //    this.ClientSize = new System.Drawing.Size(574,230);
                //}
            }
            catch (System.Exception ex)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\n" + ex.Message;
                Popup.Popup();
            }
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                oClosed(sender, e);

            }
            catch (Exception Ex)
            {

                Popup.ContentText = "\t\t\tData Administrator\n\n" + Ex.Message;
                Popup.Popup();
            }
        }

        private void grdTurnos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if ((e.RowIndex>=0)&&(e.ColumnIndex>=0))
                {
                    controlDatos = new FrmInsertarLecturas();
                    controlDatos.Cantidad = Convert.ToDecimal(grdTurnos.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString());
                    controlDatos.Turno = Convert.ToInt32(grdTurnos.Rows[e.RowIndex].Cells["Turno"].Value.ToString());
                    controlDatos.Producto = Convert.ToInt32(grdTurnos.Rows[e.RowIndex].Cells["Producto"].Value.ToString());
                    controlDatos.IdBloqueo = Convert.ToInt32(grdTurnos.Rows[e.RowIndex].Cells["IdBloqueo"].Value.ToString());
                    controlDatos.Precio = Convert.ToDecimal(grdTurnos.Rows[e.RowIndex].Cells["Precio"].Value.ToString());
                    controlDatos.Manguera = Convert.ToInt32(grdTurnos.Rows[e.RowIndex].Cells["Manguera"].Value.ToString());
                    controlDatos.LecturaFinal = Convert.ToDecimal(grdTurnos.Rows[e.RowIndex].Cells["LecturaFinal"].Value.ToString());
                    controlDatos.LecturaInicial = Convert.ToDecimal(grdTurnos.Rows[e.RowIndex].Cells["LecturaInicial"].Value.ToString());                    
                    controlDatos.CargarDatos();
                    controlDatos.StartPosition = FormStartPosition.CenterScreen;
                    controlDatos.ShowDialog();
                    grdTurnos.DataSource = oDataAccess.RecuperarTurnosConSaltodeLectura(dtpFechaTurnos.Value);

                }

            }
            catch (System.Exception ex)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\n" + ex.Message;
                Popup.Popup();
            }
        }

        private void tsbSalir_Click_1(object sender, EventArgs e)
        {
           
        }

        private void LimpiarGrilla(){
            try
            {
                System.Data.DataTable dt, dt2;
                dt = (System.Data.DataTable)grdTurnos.DataSource;
                if (dt != null) { 
                    dt2 = dt.Clone();
                    grdTurnos.DataSource = dt2;
                }
            }
            catch (System.Exception ex)
            {
            	
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                LimpiarGrilla();
                oClosed(sender, e);
            }
            catch (System.Exception ex)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\n" + ex.Message;
                Popup.Popup();
            }
        }

     
        private void btnExportar_Click(object sender, EventArgs e)
        {

            exporta_a_excel();
        }

        public void exporta_a_excel()
        {

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);

            int ColumnIndex = 0;

            foreach (DataGridViewColumn col in grdTurnos.Columns)
            {

                ColumnIndex++;

                excel.Cells[1, ColumnIndex] = col.Name;

            }

            int rowIndex = 0;

            foreach (DataGridViewRow row in grdTurnos.Rows)
            {

                rowIndex++;

                ColumnIndex = 0;

                foreach (DataGridViewColumn col in grdTurnos.Columns)
                {
                    ColumnIndex++;
                    excel.Cells[rowIndex + 1, ColumnIndex] = row.Cells[col.Name].Value;
                }

            }

            excel.Visible = true;

            Worksheet worksheet = (Worksheet)excel.ActiveSheet;

            worksheet.Activate();

        }

        private void btnImpresora_Click(object sender, EventArgs e)
        {
            if (seleccionarImpresora())
            {
                ImpgrdTurnos.PrinterSettings = prtSettings;
                ImpgrdTurnos.Print();
            }
        }

        private bool seleccionarImpresora()
        {
            PrintDialog prtDialog = new PrintDialog();
            if (prtSettings == null)
            {
                prtSettings = new PrinterSettings();
            }


            
            prtDialog.AllowPrintToFile = false;
            prtDialog.AllowSelection = false;
            prtDialog.AllowSomePages = false;
            prtDialog.PrintToFile = false;
            prtDialog.ShowHelp = false;
            prtDialog.ShowNetwork = true;

            prtDialog.PrinterSettings = prtSettings;

            if (prtDialog.ShowDialog() == DialogResult.OK)
            {
                prtSettings = prtDialog.PrinterSettings;
            }
            else
            {
                return false;
            }


            return true;
        }


        private void ImpgrdTurnos_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //PaintEventArgs myPaintArgs = new PaintEventArgs(e.Graphics, new System.Drawing.Rectangle(new System.Drawing.Point(0, 0), this.Size));
            //this.InvokePaint(grdTurnos, myPaintArgs);
            System.Drawing.Font printFont = new System.Drawing.Font("Arial", 10);
            float topMargin = e.MarginBounds.Top; 
            float yPos = 0;
            float linesPerPage = 0;
            int count = 0;
            string texto = "";
            DataGridViewRow row;
            // Calculamos el número de líneas que caben en cada página.
            linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
            
            // Recorremos las filas del DataGridView hasta que llegemos// a las líneas que nos caben en cada página o al final del grid. 
             while (count < linesPerPage && i < this.grdTurnos.Rows.Count)
            {
                row = grdTurnos.Rows[i];
                texto = "";
                
                if (i==0){
                    //foreach(DataGridViewColumn col in grdTurnos.Columns)
                    //{
                        //texto += "\t" + col.Name.ToString();               
                        
                    //}
                    texto = "         IdBloqueo     Manguera        LecturaInicial             LecturaFinal          Producto           Turno          Precio      Cantidad";
                    System.Drawing.Font printFontEncabezado = new System.Drawing.Font("Arial", 8);
                    e.Graphics.DrawString(texto, printFontEncabezado, Brushes.Black, 10, e.MarginBounds.Top);
                    texto = "";
                }

                foreach (DataGridViewCell celda in row.Cells)
                {
                    
                    texto += "\t" + celda.Value.ToString().Trim();
                }

                // Calculamos la posición en la que se escribe la línea  

                yPos = topMargin + ((count+1) * printFont.GetHeight(e.Graphics));

                // Escribimos la línea con el objeto Graphics  

                e.Graphics.DrawString(texto, printFont, Brushes.Black, 10, yPos);

                count++;
                i++;
            }

            if (i < this.grdTurnos.Rows.Count)  
                e.HasMorePages = true; 
            else {
                // si llegamos al final, se establece                 HasMorePages a 
                // false para que se acabe la impresión  
                e.HasMorePages = false;               
                 
                i = 0; 
            }
        }
      
      

       





    }
}
