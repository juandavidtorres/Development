using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PosConfiguracion;

namespace PosConfiguracion
{
    public partial class frmServicio : Form
    {
        Boolean EsCancelado = false;

        public frmServicio()
        {
            InitializeComponent();
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
            if (true)
            {
                tmrRetardo.Enabled = false;
                EsCancelado = false;
                this.Hide();

                frmMain F = new frmMain();
                ValidarUsuario validacion = new ValidarUsuario();
                validacion.ShowDialog();

                if (frmMain.UserId != null)
                {
                    F.ShowDialog();
                }
                else
                {
                    F.Dispose();
                }

                this.Close();
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
            try
            {
                // comprobando la cantidad de elementos del array
                if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    this.Close();
                }

               
                try
                {

                    //Verifico que esté conectada la llave HASP
                    //POSstation.Fabrica.gasolutionsHasp.IsHasp();

                  
                    tmrRetardo.Enabled = true;
                }
                catch (POSstation.Fabrica.GasolutionsHaspException)
                {
                    MessageBox.Show("LLAVE HASP NO ENCONTRADA" + (char)10 + "Por favor conecte en el puerto USB la llave Gasolutions de verificación de licencia" + (char)10 + "e intente abrir de nuevo el aplicativo", Application.ExecutablePath, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Problema asignando el servicio " + ":" + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }
    }

}