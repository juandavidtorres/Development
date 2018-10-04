using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Controles;
using POSstation.AccesoDatos;
using System.IO;

namespace gasolutions.UInterface
{
    public partial class gsOrdenPedido : ItemMenu
    {
        Controles.frmAyuda OHelpProducto = new frmAyuda();
        Helper oHelper = new Helper();
        Boolean EsNuevoRegistro = false;

        public gsOrdenPedido()
        {
            InitializeComponent();
        }

        public void IniciarForma()
        {
            try
            {
                this.txtNoOrden.Text = "";
                this.txtElaborado.Text = "";
                this.txtComentario.Text = "";
                this.txtCodigo.Text = "";
                this.txtCantidad.Text = "";
                this.lblProductoText.Text = "";
                dgvDetOrden.Rows.Clear();
                this.dtpFecha.Focus();
                mnuPrint.Enabled = false;
                mnuGuardar.Enabled = true;
                pnlAdicionProducto.Enabled = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnHelpProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.TextLength > 0)
                {
                    try
                    {
                        lblProductoText.Text = oHelper.RecuperarProductoCombustibleCodigo(Int16.Parse(txtCodigo.Text));
                        txtCantidad.Focus();
                    }
                    catch 
                    {
                        this.HelpProducto();
                    }
                }
                else
                {
                    this.HelpProducto();
                }
            }
            catch
            {
            }

        }

        private void HelpProducto()
        {
            DataTable dtProducto = new DataTable();
            dtProducto.Load(oHelper.RecuperarProductos(), LoadOption.Upsert);

            OHelpProducto.Informacion = dtProducto;
            OHelpProducto.ShowDialog();
            if (!String.IsNullOrEmpty(OHelpProducto.RowSelect.Cells[0].Value.ToString()))
            {
                lblProductoText.Text = OHelpProducto.RowSelect.Cells[1].Value.ToString();
                txtCodigo.Text = OHelpProducto.RowSelect.Cells[0].Value.ToString();
                txtCantidad.Focus();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado un producto", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodigo.Focus();
            }
        }

        public event EventHandler oClosed;
        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            EsNuevoRegistro = false;
            this.RiseEvent_OnClosed(sender, e);
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            this.IniciarForma();
        }

        private void mnuDeshacer_Click(object sender, EventArgs e)
        {
            this.IniciarForma();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!(e.KeyValue == 8 || e.KeyValue == 46 || e.KeyValue >= 48 && e.KeyValue <= 57 || e.KeyValue >= 96 && e.KeyValue <= 105))
                {
                    e.SuppressKeyPress = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Codigo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!(e.KeyValue == 8 || e.KeyValue == 46 || e.KeyValue >= 48 && e.KeyValue <= 57 || e.KeyValue >= 96 && e.KeyValue <= 105))
                {
                    e.SuppressKeyPress = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.TextLength > 0 && lblProductoText.Text.Length > 0 && txtCantidad.TextLength > 0)
                {
                    string[] Item = { txtCodigo.Text, lblProductoText.Text, txtCantidad.Text };
                    dgvDetOrden.Rows.Add(Item);
                    txtCodigo.Text = "";
                    lblProductoText.Text = "";
                    txtCantidad.Text = "";
                    txtCodigo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Adicionar Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtNoOrden_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!(e.KeyValue == 8 || e.KeyValue == 46 || e.KeyValue >= 48 && e.KeyValue <= 57 || e.KeyValue >= 96 && e.KeyValue <= 105))
                {
                    e.SuppressKeyPress = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NoOrden", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtElaborado_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!(e.KeyValue == 8 || e.KeyValue == 46 || e.KeyValue >= 48 && e.KeyValue <= 57 || e.KeyValue >= 96 && e.KeyValue <= 105))
                {
                    e.SuppressKeyPress = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Elaborado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mnuPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.ObtenerDocumentoImpresion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Guardando", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mnuGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean AdicionaFila = false;

                if (txtElaborado.TextLength < 1)
                    throw new Exception("Debe Ingresar el número de documento de quien elabora la orden");

                System.Collections.Generic.Dictionary<Int32, String> oItems = new Dictionary<int, string>();
                foreach (DataGridViewRow oFila in dgvDetOrden.Rows)
                {
                    oItems.Add(Int32.Parse(oFila.Cells["Codigo"].Value.ToString()), oFila.Cells["Codigo"].Value.ToString() + '|' + oFila.Cells["Cantidad"].Value.ToString());
                    AdicionaFila = true;
                }

                if (AdicionaFila)
                {
                    txtNoOrden.Text = oHelper.InsertarOrdenPedido(txtElaborado.Text, txtComentario.Text, dtpFecha.Value.ToString("yyyyMMdd"), oItems).ToString();
                    mnuPrint.Enabled = true;
                    mnuGuardar.Enabled = false;
                    pnlAdicionProducto.Enabled = false;
                }
                else
                {
                    throw new Exception("No se han adicionado productos a la orden que intenta realizar");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Guardando", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ObtenerDocumentoImpresion()
        {
            try
            {
                TextWriter oImpresion = new StreamWriter(Application.StartupPath + "\\Pedido.txt");

                //StringBuilder oImpresion = new StringBuilder();

                InformacionEstacion oEstacion = oHelper.RecuperarDatosEstacion();

                oImpresion.WriteLine(CentrarTexto(80, oEstacion.Nombre));
                oImpresion.WriteLine(CentrarTexto(80, oEstacion.Nit));
                oImpresion.WriteLine(CentrarTexto(80, oEstacion.Direccion));
                oImpresion.WriteLine(CentrarTexto(80, oEstacion.Telefono));
                oImpresion.WriteLine(CentrarTexto(80, oEstacion.Ciudad));
                oImpresion.WriteLine(CentrarTexto(80, "Orden de Pedido Numero: " + txtNoOrden.Text));

                oImpresion.WriteLine("");
                oImpresion.WriteLine("");

                oImpresion.WriteLine(new String(char.Parse("-"), 80));

                oImpresion.WriteLine(TripleColumna("CODIGO", "DESCRIPCION", "CANTIDAD"));
                oImpresion.WriteLine(new String(char.Parse("-"), 80));


                foreach (DataGridViewRow oFila in dgvDetOrden.Rows)
                {
                    string NombreP = oFila.Cells["Producto"].Value.ToString();
                    string CantidadP = oFila.Cells["Cantidad"].Value.ToString();
                    string CodigoP = oFila.Cells["Codigo"].Value.ToString();

                    oImpresion.WriteLine(TripleColumna(CodigoP, NombreP, CantidadP));

                }

                oImpresion.WriteLine("");
                oImpresion.WriteLine("");
                oImpresion.WriteLine("");
                oImpresion.WriteLine(CentrarTexto(80, "Impreso por Sistema " + DateTime.Now.ToString()));
                oImpresion.WriteLine("$$$");
                oImpresion.Close();

                AsciiToPrinter(Application.StartupPath + "\\Pedido.txt");
                System.IO.File.Delete(Application.StartupPath + "\\Pedido.txt");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string CentrarTexto(Int32 ancho, string texto)
        {
            if (texto.Length > ancho)
                texto = texto.Substring(0, ancho);

            string Retorno = new String(char.Parse(" "), ((ancho - texto.Length) / 2));
            Retorno = Retorno + texto;
            return Retorno;
        }

        public string TripleColumna(string Ptexto, string Stexto, string Ttexto)
        {
            if (Ptexto.Length > 10)
                Ptexto = Ptexto.Substring(0, 10);
            else
                Ptexto = Ptexto.PadRight(10, char.Parse(" "));

            if (Stexto.Length > 60)
                Stexto = Stexto.Substring(0, 60);
            else
                Stexto = Stexto.PadRight(60, char.Parse(" "));

            if (Ttexto.Length > 10)
                Ttexto = Ttexto.Substring(0, 10);
            else
                Ttexto = Ttexto.PadRight(10, char.Parse(" "));

            return (Ptexto + Stexto + Ttexto);
        }

        public void AsciiToPrinter(string Archivo)
        {
            StreamReader streamToPrint;
            try
            {
                if (!System.IO.File.Exists(Archivo))
                {
                    throw new Exception("No existe el archivo:" + Archivo);
                }

                streamToPrint = new StreamReader(Archivo);
                TextPrint pd = new TextPrint(streamToPrint);

                try
                {
                    PrintDialog oPreview = new PrintDialog();
                    oPreview.Document = pd;

                    if (oPreview.ShowDialog() == DialogResult.OK)
                    {
                        pd.PrinterSettings = oPreview.PrinterSettings;
                        pd.Print();
                    }


                }
                catch 
                {
                }
                streamToPrint.Close();

            }
            catch (Exception ex)
            {
                throw ex;
                streamToPrint.Close();
            }
        }
    }
}
