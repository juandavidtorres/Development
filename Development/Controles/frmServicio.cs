using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace gasolutions.Configurador
{
    public partial class frmServicio : Form
    {
        Boolean EsCancelado = false;
        string Servicio;

        public frmServicio()
        {
            InitializeComponent();
        }

        public string ServiceName
        { 
          set
          { 
              Servicio = value;
          }
        }
        
        private void btnReintentar_Click(object sender, EventArgs e)
        {
            tmrRetardo.Enabled = false;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EsCancelado = true;
        }

        private void tmrRetardo_Tick(object sender, EventArgs e)
        {
            if (IsRunning())
            {
                //tmrRetardo.Enabled = false;
                //EsCancelado = false;
                //this.Hide();

                //MainForm F = new MainForm();
                //F.ShowDialog();

                //this.Close();
            }
            else
            {
                if (EsCancelado)
                {
                    btnReintentar.Enabled = true;
                    btnCancelar.Enabled = false;
                }
            }
        }

        private Boolean IsRunning()
        {
            Controlador.Refresh();
            if (Controlador.Status == System.ServiceProcess.ServiceControllerStatus.Running)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void frmServicio_Load(object sender, EventArgs e)
        {
            //try
            //{
                

                
            //    //Properties.Settings s = new Properties.Settings();
            //    //Servicio = s.NombreServicio;

            //    try
            //    {

            //        //Verifico que esté conectada la llave HASP
            //        //gasolutions.Factory.gasolutionsHasp.IsHasp();

            //        Controlador.ServiceName = Servicio;
            //        //Hago esta instruccin para saber si el nombre es correcto
            //        Int32 a = (Int32)Controlador.Status;

            //        tmrRetardo.Enabled = true;
            //    }
            //    catch (gasolutions.Factory.GasolutionsHaspException)
            //    {
            //        MessageBox.Show("LLAVE HASP NO ENCONTRADA" + (char)10 + "Por favor conecte en el puerto USB la llave Gasolutions de verificación de licencia" + (char)10 + "e intente abrir de nuevo el aplicativo", Application.ExecutablePath, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        this.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception("Problema asignando el servicio " + Servicio + ":" + ex.Message);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    Application.Exit();
            //}
        }
    }
}