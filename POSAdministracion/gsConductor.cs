using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using System.Collections;
using Controles;

namespace  PosStation.gsConductores
{
    public partial class gsConductor: UserControl
    {
        Helper OHelper = new Helper();
        bool cambiarPrecio;
        public Int64 IdentificacionCliente;

        public gsConductor()
        {
            InitializeComponent();
        }

        public void IniciarForma()
        {
            this.Cursor = Cursors.WaitCursor;
            txtDocumento.Tag = "";
            FormatoFormularioInicial();
            txtIdentificacionCliente.Text = Convert.ToString(IdentificacionCliente);
            //txtIdentificacionCliente.Enabled = false;
            this.Cursor = Cursors.Default;
        }

      
        private void FormatoFormularioInicial()
        {
            txtDocumento.Tag = "";
            txtNombre.Text = "";
            txtDocumento.Text = "";
            ChkActivo.Checked = false;
           // txtIdentificacionCliente.Text = "";
            HabilitarControles(true);
            txtDocumento.Focus();
           
        }

        private void LimpiarFormularioSecundario()
        {
            txtDocumento.Tag = "";
            txtNombre.Text = "";
            txtNombre.Focus();
            ChkActivo.Checked = false;
        }

        private void HabilitarControles(Boolean Valor)
        {
            this.mnuGuardar.Enabled = Valor;
        }

        private void CargarDatosConductor(String documento)
        {
            try
            {
                IDataReader DrConductor;
                if (OHelper.ExisteConductor(documento))
                {
                    DrConductor = OHelper.RecuperarConductor(documento);
                    EstablecerDatosConductor(DrConductor);
                }
                else
                {
                    DrConductor = OHelper.RecuperarConductor(documento);
                    EstablecerDatosConductor(DrConductor);
                    Popup.ContentText = "\t\t\tData Administrator\n\nSe recuperaron los datos del cliente del CDC";
                    Popup.Popup();
                }
            }
            catch (Exception ex)
            {
                LimpiarFormularioSecundario();
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void EstablecerDatosConductor(IDataReader DrConductor)
        {
            try
            {
                if (DrConductor.Read())
                {
                    txtNombre.Text = DrConductor.GetString(1);
                    ChkActivo.Checked = Convert.ToBoolean(DrConductor.GetBoolean(7));
                    txtNombre.Focus();
                }
                else
                {
                    Popup.ContentText = "No hay un Conductor creado para el doc" + txtDocumento.Text + ". Puede crearlo o intentar nuevamente la consulta";
                    Popup.Popup();
                    txtNombre.Focus();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DrConductor.Close();
            }
        }

        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            if (txtDocumento.Text != txtDocumento.Tag.ToString())
            {
                txtDocumento.Tag = txtDocumento.Text;
                CargarDatosConductor(txtDocumento.Text);
            }

        }

        private void mnuNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                FormatoFormularioInicial();
            }
            catch (ArgumentNullException)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nEl argumento hizo referencia a un objeto cuyo estado es nulo";
                Popup.Popup();
            }
            catch (FormatException)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nEl formato de la cadena a convertir no es válido";
                Popup.Popup();
            }
            catch (OverflowException)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nLa cadena a convertir representa un número menor que MinValue o mayor que MaxValue.";
                Popup.Popup();
            }
            catch (ArgumentOutOfRangeException)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nRowIndex está fuera del intervalo válido, que va desde 0 hasta el número de filas del control menos 1.";
                Popup.Popup();
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }
        


        private void mnuGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txtNombre.Text.Trim().Length > 0 && txtDocumento.Text.Trim().Length > 0)
                {

                    //Factory.Validacion.ValidarNumeroEntero(txtDocumento.Text.Trim(), "El Nuip");

                   
                        if (OHelper.ExisteConductor(txtDocumento.Text.Trim()))
                        {
                            OHelper.ActualizarConductor(txtDocumento.Text.Trim(), txtNombre.Text.Trim(),"","","",0, ChkActivo.Checked);
                            OHelper.InsertarClienteConductor(txtIdentificacionCliente.Text.Trim(),txtDocumento.Text.Trim());
                            Popup.ContentText = "\t\t\tData Administrator\n\nEl Conductor fue asociado al cliente satisfactoriamente";
                            Popup.Popup();
                        }
                        else
                        {
                            OHelper.InsertarConductor(txtDocumento.Text.Trim(), txtNombre.Text.Trim(), "", "", "", 0, ChkActivo.Checked);
                            OHelper.InsertarClienteConductor(txtIdentificacionCliente.Text.Trim(), txtDocumento.Text.Trim());
                            Popup.ContentText = "\t\t\tData Administrator\n\nEl Conductor fue Creado y asociado al cliente satisfactoriamente";
                            Popup.Popup();                   
                        }
                    
                        LimpiarConductor();                        

                       
                    
                }
                else
                {
                    Popup.ContentText = "\t\t\tData Administrator\n\nHay campos obligatorios que no han sido llenados";
                    Popup.Popup();
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }


       
        private void LimpiarConductor() 
        {
            
            //txtIdentificacionCliente.Clear();
            txtDocumento.Clear();
            txtNombre.Clear();
            ChkActivo.Checked = false;
        }

        public event EventHandler oClosed;

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            oClosed(sender, e);
        }

       

        private void btnBuscarConductor_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarConductor();
                 DataSet oInformacion = new DataSet();
                oInformacion.Load(OHelper.RecuperarConductoresPorCliente(txtIdentificacionCliente.Text), LoadOption.Upsert, "Cliente");
                Controles.frmAyuda oAyuda = new frmAyuda();
                oAyuda.TituloVentana = "Conductores";
                oAyuda.UbicacionFormulario = FormStartPosition.CenterParent;
                oAyuda.Informacion = oInformacion.Tables[0];
                oAyuda.ColumnReturn = 0;
                oAyuda.ShowDialog();
                if (string.IsNullOrEmpty(oAyuda.ValorRegistroSeleccionado))
                {
                    txtDocumento.Text = "";
                   // throw new Exception("No hay Conductores registrados para este cliente.");
                }
                else
                {
                    txtDocumento.Text = oAyuda.ValorRegistroSeleccionado.ToString();
                    //txtNombre.Text = oAyuda.RowSelect.Cells[1].ToString();     

                }
                oAyuda.Dispose();
            }
            catch (Exception ex )
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        //public event WorkerEndHandler MostrarVehiculo;

      

    }

 

   public class EventConductor : EventArgs
    {

        public readonly string iPlaca;
        public readonly Boolean iEstado;

        public EventConductor(string s, Boolean Estado)
        {
            iPlaca  = s;
            iEstado = Estado;
        }

    }

    public delegate void WorkerEndHandler(object o, EventConductor e);
}
