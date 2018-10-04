using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using System.Collections;
using gasolutions.UInterface;
using System.IO.Ports;
using Controles;
using POSstation.Fabrica;
using POSstation.Protocolos;
using POSstation;
namespace gasolutions.UInterface
{
    public partial class IdentificadorPlaca : Form
    {
        Helper OHelper = new POSstation.AccesoDatos.Helper();
        //DataSet Identplaca = new DataSet();
            DataSet Identplaca ;
            DataGridViewCheckBoxColumn colBorrar = new DataGridViewCheckBoxColumn();
           


        public IdentificadorPlaca()
        {
            InitializeComponent();
            colBorrar.Name = "Borrar";
        }

        private void pnlDetalle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtIdentificador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                consultaIdentificadorPlaca();
            }

        }

        



        private void txtIdentificador_TextChanged(object sender, EventArgs e)
        {
            
        }

       
        private void btnInsertar_Click(object sender, EventArgs e)
        {

            insertarPlaca();
           
        }

        private void insertarPlaca() 
        {
   
            if (txtIdentificador.Text.Trim().Length > 0 && txtPlaca.Text.Trim().Length > 0)
            {
                DataSet Identplaca = new DataSet();
                Identplaca = OHelper.RecuperarIdentificadorLocalPorIdPlaca2(Convert.ToString(txtIdentificador.Text.Trim()), Convert.ToString(txtPlaca.Text.Trim()));

                if (Identplaca.Tables[0].Rows.Count > 0)
                {
                    Popup.ContentText = "\t\t\tData Administrator\n\nYa existe esa placa";
                    Popup.Popup();
                  
                } else
                {
                    LimipiarGrilla();
                    OHelper.InsertarIdentificadorLocalPorIdPlaca(Convert.ToString(txtIdentificador.Text.Trim()), txtPlaca.Text.Trim(), DateTime.Now);
                    RefrescarGrilla();

                    Popup.ContentText = "\t\t\tData Administrator\n\nLa Placa se guardo satisfactoriamente";
                    Popup.Popup();
              
                }
       



       
            }
            else
            {
               
                Popup.ContentText = "\t\t\tData Administrator\n\nHay campos obligatorios que no han sido llenados";
                Popup.Popup();
              
            }
        }


        private void consultaIdentificadorPlaca() 
        {
        
     
            try
            {
                if (txtIdentificador.Text.Trim().Length > 0)
                {

                    LimipiarGrilla();

                    DataSet Identplaca = new DataSet();
                    Identplaca = OHelper.RecuperarIdentificadorLocalPorIdPlaca(Convert.ToString(txtIdentificador.Text.Trim()));

            
                    if (Identplaca.Tables[0].Rows.Count > 0)
                    {

             
                        dgvPlacas.DataSource = Identplaca.Tables[0];

                        dgvPlacas.Columns["Identificador"].ReadOnly = true;
                        dgvPlacas.Columns["Placa"].ReadOnly = true;
                        dgvPlacas.Columns["FechaCrea"].ReadOnly = true;
                        dgvPlacas.Columns["EsActivo"].Visible = false;
                        dgvPlacas.Columns["TipoIdentificador"].Visible = false;
                        dgvPlacas.Columns["IdTipoIdentificador"].Visible = false;
                        dgvPlacas.Columns["Placa1"].Visible = false;

                        if (dgvPlacas.Columns.Contains("borrar") == false)
                        {
                            dgvPlacas.Columns.Insert(dgvPlacas.Columns.Count, colBorrar);

                        }


                        dgvPlacas.Refresh();

                    } else

                    {
                        LimipiarGrilla();
                        dgvPlacas.Refresh();
                        Popup.ContentText = "\t\t\tNo existe identificador, puede agregar uno nuevo";
                        Popup.Popup();
              
                                             
                    }

                          
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

        private void limpiarControles()
        {
            txtIdentificador.Text = "";
            txtPlaca.Text = "";

        }


        private void btnConsulta_Click(object sender, EventArgs e)
        {
            consultaIdentificadorPlaca();

        }

        private void brnsalir_Click(object sender, EventArgs e)
        {
            Close();

        }


        private void RefrescarGrilla() {


            DataSet Identplaca = new DataSet();
            Identplaca = OHelper.RecuperarIdentificadorLocalPorIdPlacaRefrescar(Convert.ToString(txtIdentificador.Text.Trim()));

            if (Identplaca.Tables[0].Rows.Count > 0)
            {
                LimipiarGrilla();

                dgvPlacas.DataSource = Identplaca.Tables[0];

                dgvPlacas.Columns["Identificador"].ReadOnly = true;
                dgvPlacas.Columns["Placa"].ReadOnly = true;
                dgvPlacas.Columns["FechaCrea"].ReadOnly = true;
                dgvPlacas.Columns["EsActivo"].Visible = false;
                dgvPlacas.Columns["TipoIdentificador"].Visible = false;
                dgvPlacas.Columns["IdTipoIdentificador"].Visible = false;
                dgvPlacas.Columns["Placa1"].Visible = false;

                if (dgvPlacas.Columns.Contains("borrar") == false)
                {
                    dgvPlacas.Columns.Insert(dgvPlacas.Columns.Count, colBorrar);
                }

          
                dgvPlacas.Refresh();
             
            }
       
     
        

        }

      

        private void dgvPlacas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if ( Convert.ToBoolean (dgvPlacas.CurrentRow.Cells["Borrar"].EditedFormattedValue ) == true)
            {
             

                DialogResult result = MessageBox.Show("Desea eliminar esta Placa?", "Informacion", MessageBoxButtons.OKCancel);

                switch (result)
                {
                    case DialogResult.OK:
                        {
                            OHelper.EliminarIdentificadorLocalPorIdPlaca(Convert.ToString(dgvPlacas.CurrentRow.Cells["Identificador"].Value), Convert.ToString(dgvPlacas.CurrentRow.Cells["Placa"].Value));
                            this.Text = "[OK]";

                            Popup.ContentText = "\t\t\tData Administrator\n\nPlaca eliminada";
                            Popup.Popup();

                            LimipiarGrilla();
                            RefrescarGrilla();
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            this.Text = "[Cancel]";
                            break;
                        }

                }
              
            }
          
           

         
         }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtIdentificador.Text = string.Empty;
            txtPlaca.Text = string.Empty;
            LimipiarGrilla();

        }


        private void LimipiarGrilla() {

            if (dgvPlacas.Columns.Count > 0)
            {
                dgvPlacas.Columns.Clear();
            }

            if (dgvPlacas.Rows.Count > 0)
            {
                dgvPlacas.Columns.Clear();
            }

        
        }

          
        }

    }

