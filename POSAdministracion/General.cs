using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using POSstation.AccesoDatos;
using System.Data;

namespace gasolutions.UInterface
{
    public class Instancias
    {

        private Hashtable instancias = new Hashtable();
        

        public Form AbrirVentana(Type tipo)
        {
            try
            {
                return AbrirVentana(tipo.FullName);
            }
            catch
            {
                throw;
            }
        }

        public Form AbrirVentana(string tipo)
        {
            try
            {
                Form formulario = instancias[tipo] as Form;
                if (formulario == null || formulario.IsDisposed)
                {
                    formulario = (Form)Activator.CreateInstance(null, tipo).Unwrap();
                    instancias[tipo] = formulario;
                }

                formulario.Activate();
                formulario.StartPosition = FormStartPosition.CenterParent;
                formulario.ShowDialog();
                formulario.Owner = MainFormGlobal.InstanciaMain;          
                return formulario;

                //formulario.Dispose();
            }

            catch
            {
                throw;
            }
        }

        public DataTable DameDataTableDeDataGridView(DataGridView MiGrid)
        {
            DataTable dtNuevo = new DataTable();
            DataColumn colNueva;
            DataRow filaNueva;
            int numCols;
            int numRows = 1;

           // Replicamos las columnas del DataGridView en el DataTable nuevo
            foreach (DataGridViewColumn dataGridViewCol in MiGrid.Columns)
           {
               colNueva = new DataColumn(dataGridViewCol.DataPropertyName); 
               dtNuevo.Columns.Add(colNueva);
           }
               
            numCols = dtNuevo.Columns.Count;

           // Rellenamos los valores del DataTable nuevo con los valores de las celdas del DataGridView
            foreach (DataGridViewRow filaDatos in MiGrid.Rows)
           {
               if (numRows <= (MiGrid.Rows.Count - 1))
               {
                   
                   if (filaDatos.Cells[0].Value != null && Int16.Parse(filaDatos.Cells[0].Value.ToString()) >= 0)
                   {
                       filaNueva = dtNuevo.NewRow();
                       for (int i = 0; i <= (numCols - 1); i++)
                       {
                           if (filaDatos.Cells[i].Value == null)
                           {
                               filaNueva[i] = 1;
                           }
                           else
                           {
                               filaNueva[i] = filaDatos.Cells[i].Value;
                           }
                       }
                       dtNuevo.Rows.Add(filaNueva);
                   }
               }
               numRows += 1;
           }
           return dtNuevo;
        }

    }

    public static class MainFormGlobal
    {
        private static Form _InstanciaMain;

        public static Form InstanciaMain
        {
            get
            {
                return _InstanciaMain;
            }
            set
            {
                _InstanciaMain = value;
            }
        }
    }

    public static class ProductoBuscarGlobal
    {
        private static string _IdProducto;

        public static string IdProducto
        {
            get
            {
                return _IdProducto;
            }
            set
            {
                _IdProducto = value;
            }
        }

    }

   }

#region      Creditos de Consumo

public class EncabezadoCreditoConsumo
{

    private static Int64 _IdCreditoConsumo;

    public Int64 IdCreditoConsumo
    {
        get
        {
            return _IdCreditoConsumo;
        }
        set
        {
            _IdCreditoConsumo = value;
        }
    }
    
    private static Int64  _IdCliente;

    public Int64 IdCliente
    {
        get 
        {
            return _IdCliente; 
        }
        set 
        {
            _IdCliente = value;
        }
    }

    private static Int16  _Producto;

    public Int16 Producto
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

    private static Decimal _Cupo;

    public Decimal Cupo
    {
        get
        {
            return _Cupo;
        }
        set
        {
            _Cupo = value;
        }
    }

    private static Int16 _TipoCredito;

    public Int16 TipoCredito
    {
        get
        {
            return _TipoCredito;
        }
        set
        {
            _TipoCredito = value;
        }
    }

    private static DateTime _FechaCreacion;

    public DateTime FechaCreacion
    {
        get
        {
            return _FechaCreacion;
        }
        set
        {
            _FechaCreacion = value;
        }
    }

    private static DateTime _FechaExpira;

    public DateTime FechaExpira
    {
        get
        {
            return _FechaExpira;
        }
        set
        {
            _FechaExpira = value;
        }
    }

    private static DateTime _FechaUpdate;

    public DateTime FechaUpdate
    {
        get
        {
            return _FechaUpdate;
        }
        set
        {
            _FechaUpdate = value;
        }
    }

    private static Boolean _Estado;

    public Boolean Estado
    {
        get
        {
            return _Estado;
        }
        set
        {
            _Estado = value;
        }
    }

    private static string _Nombre;

    public string Nombre
    {
        get 
        { 
            return _Nombre; 
        }
        set 
        {
            _Nombre = value;
        }
    }

    private static string _TipoFactucion;

    public string TipoFactucion
    {
        get 
        {
            return _TipoFactucion;
        }
        set 
        {
            _TipoFactucion = value;
        }
    }

    //public EncabezadoCreditoConsumo RecuperarEncabezadoCredito(string Nuip)
    //{
    //    Helper oHelper = new Helper();
    //    DataSet dsCliente = new DataSet();
    //    Int64 IdCliente;
    //    EncabezadoCreditoConsumo oEncabezado = new EncabezadoCreditoConsumo();

    //    dsCliente.Load(oHelper.RecuperarCliente(Nuip), LoadOption.Upsert, "Clientes");

    //    foreach (DataRow rCliente in dsCliente.Tables[0].Rows)
    //    {
    //        IdCliente = rCliente["IdCliente"];
    //    }




    //}

}

public class DetalledoCreditoConsumo
{
    
    private static Int64 _IdCreditoVehiculo;

    public Int64 IdCreditoVehiculo
    {
        get
        {
            return _IdCreditoVehiculo;
        }
        set
        {
            _IdCreditoVehiculo = value;
        }
    }


    private static Int64 _IdCreditoConsumo;

    public Int64 IdCreditoConsumo
    {
        get
        {
            return _IdCreditoConsumo;
        }
        set
        {
            _IdCreditoConsumo = value;
        }
    }

    private static Int64 _IdVehiculo;

    public Int64 IdVehiculo
    {
        get
        {
            return _IdVehiculo;
        }
        set
        {
            _IdVehiculo = value;
        }
    }

    private static DateTime _FechaIngreso;

    public DateTime FechaIngreso
    {
        get
        {
            return _FechaIngreso;
        }
        set
        {
            _FechaIngreso = value;
        }
    }

    private static Boolean _Estado;

    public Boolean Estado
    {
        get
        {
            return _Estado;
        }
        set
        {
            _Estado = value;
        }
    }
}

public class EscalasAnticipo
{
    private static Int64 _IdEscala;

    public Int64 IdEscala
    {
        get
        {
            return _IdEscala;
        }
        set
        {
            _IdEscala = value;
        }
    }

    private static Decimal _ValorInicialAnticipo;

    public Decimal ValorInicialAnticipo
    {
        get
        {
            return _ValorInicialAnticipo;
        }
        set
        {
            _ValorInicialAnticipo = value;
        }
    }

    private static Decimal _ValorFinalAnticipo;

    public Decimal ValorFinalAnticipo
    {
        get
        {
            return _ValorFinalAnticipo;
        }
        set
        {
            _ValorFinalAnticipo = value;
        }
    }

    private static Int16 _CaducidadDias;

    public Int16 CaducidadDias
    {
        get
        {
            return _CaducidadDias;
        }
        set
        {
            _CaducidadDias = value;
        }
    }

    private static Int32 _ValorAdicional;

    public Int32 ValorAdicional
    {
        get
        {
            return _ValorAdicional;
        }
        set
        {
            _ValorAdicional = value;
        }
    }

    private static Boolean _Activo;

    public Boolean Activo
    {
        get
        {
            return _Activo;
        }
        set
        {
            _Activo = value;
        }
    }

}

public class Clientes
{
    private Helper OHelper = new Helper();

    private static Int64 _IdCliente;

    public Int64 IdCliente
    {
        get
        {
            return _IdCliente;
        }
        set
        {
            _IdCliente = value;
        }
    }

    private static string  _Nombre;

    public string  Nombre
    {
        get
        {
            return _Nombre;
        }
        set
        {
            _Nombre = value;
        }
    }

    public Clientes RecuperarCliente(string Nuip)
    {
        DataSet tbCliente = new DataSet();

        Clientes eCliente = new Clientes();

        try
        {
            tbCliente.Load(OHelper.RecuperarClienteLocal(Nuip), LoadOption.Upsert, "Cliente");

            foreach (DataRow rFila in tbCliente.Tables[0].Rows)
            {
                //eCliente 
                eCliente.IdCliente = Int64.Parse(rFila["IdCliente"].ToString());
                eCliente.Nombre = rFila["Nombre"].ToString();
                
            }

            tbCliente.Clear();
            tbCliente = null;

            return eCliente;
        }
        catch (Exception ex)
        {
            throw ex;            
        }
    }

}

#endregion