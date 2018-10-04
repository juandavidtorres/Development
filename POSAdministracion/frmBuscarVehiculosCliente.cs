using POSstation.AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Controles
{
    public partial class  frmBuscarVehiculosCliente : Form
    {
        DataTable oExcluir;
        string _IndentificacionCliente;
        DataTable Vehiculos;
        List<DataRow> _Resultado;


        public frmBuscarVehiculosCliente()
        {
            InitializeComponent();
        }

        public String IndentificacionCliente
        {
            set
            {
                _IndentificacionCliente = value;
            }
        }



        public List<DataRow> Resultado 
        {
            get
            {
               return  _Resultado;
            }
        }

      
        public DataTable Excluir
        {
            set 
            {
                oExcluir = value;
            }
        }

   

        public FormStartPosition UbicacionFormulario
        {
            set
            {
                this.StartPosition = value;
            }
        }



        private void frmBuscarVehiculosCliente_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Seleccionar Vehículos";
                Helper oHelper = new Helper();

                Vehiculos = oHelper.RecuperarVehiculosporClienteLocal(_IndentificacionCliente).Tables[0];
                Vehiculos.Columns.Remove("ControlKM");
                Vehiculos.Columns.Add(new DataColumn("Seleccionado", System.Type.GetType("System.Boolean")));
                foreach (DataRow fila in Vehiculos.Rows)
                {
                    fila["Seleccionado"] = false;
                    bool existe = false;
                    foreach (DataRow dr in oExcluir.Rows)
                    {
                            if (fila["Placa"].ToString() == dr["Placa"].ToString())
                            {
                                existe = true;
                            }
                    }
                    if (existe)
                        fila.Delete();
                }


                if (Vehiculos != null)
                {
                    dtgInformacion.DataSource = Vehiculos;
                    foreach (DataGridViewColumn dCol in dtgInformacion.Columns)
                    {
                        dCol.ReadOnly = true;
                    }
                    dtgInformacion.Columns["Seleccionado"].ReadOnly = false;
                }
                else
                    MessageBox.Show("La Consulta no devuelve resultados", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                throw;
            }
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _Resultado = new List<DataRow>();
            DataRow[] dt = Vehiculos.Select("Seleccionado=1");
            
            _Resultado.AddRange(dt);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _Resultado = new List<DataRow>();
            this.Close();
        }

        private void frmAyuda_FormClosed(object sender, FormClosedEventArgs e)
        {
           
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