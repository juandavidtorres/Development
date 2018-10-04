using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
namespace gasolutions.UInterface
{
    public partial class FrmInsertarLecturas : Form
    {
        Helper oDatos = new Helper();
        private int _Turno;
        private decimal _Cantidad;
        private int _Manguera;
        private int _Producto;
        private int _IdBloqueo;
        private decimal _Precio;

        public int Turno
        {
            get
            {

                return _Turno;
            }

            set
            {
                _Turno = value;
            }
        }
        public decimal Cantidad
        {
            get
            {

                return _Cantidad;
            }

            set
            {
                _Cantidad = value;
            }
        }
        public int Manguera
        {
            get
            {

                return _Manguera;
            }

            set
            {
                _Manguera = value;
            }
        }
        public int IdBloqueo
        {
            get
            {

                return _IdBloqueo;
            }

            set
            {
                _IdBloqueo = value;
            }
        }
        public int Producto
        {
            get
            {

                return _Producto;
            }

            set
            {
                _Producto = value;
            }
        }
        private decimal _LInicial;
        private decimal _LFinal;

        public decimal LecturaInicial
        {
            get
            {

                return _LInicial;
            }

            set
            {
                _LInicial = value;
            }
        }
        public decimal LecturaFinal
        {
            get
            {

                return _LFinal;
            }

            set
            {
                _LFinal = value;
            }
        }

        public decimal Precio
        {
            get
            {

                return _Precio;
            }

            set
            {
                _Precio = value;
            }
        }


        public FrmInsertarLecturas()
        {
            InitializeComponent();
        }

        public void CargarDatos()
        {

            try
            {
               
                ctrInsertarLecturas.Cantidad = Cantidad;
                ctrInsertarLecturas.Turno = Turno;
                ctrInsertarLecturas.Producto = Producto;
                ctrInsertarLecturas.IdBloqueo = IdBloqueo;
                ctrInsertarLecturas.Precio = Precio;
                ctrInsertarLecturas.Manguera = Manguera;
                ctrInsertarLecturas.LecturaInicial = LecturaInicial;
                ctrInsertarLecturas.LecturaFinal = LecturaFinal;
                ctrInsertarLecturas.CargarDatos();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmInsertarLecturas_Load(object sender, EventArgs e)
        {
            try
            {
                ctrInsertarLecturas.oClosed += new EventHandler(ctrInsertarLecturas_oClosed);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);   	
            	
            }
        }

        private void ctrInsertarLecturas_oClosed(object sender, EventArgs e)
        {
           try
           {
               this.Close();
           }
           catch (System.Exception ex)
           {
               MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);   	
           	    
           }
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);   	
            }
        }
           
    }
}
