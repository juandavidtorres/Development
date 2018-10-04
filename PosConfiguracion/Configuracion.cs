using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using System.Collections;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;
using POSstation.Fabrica;

namespace PosConfiguracion
{
    public partial class Configuracion : UserControl
    {
        Boolean EsGridContruido;
        Boolean EsGridSurtidorContruido;
        Boolean EsGridCaraContruido;
        Boolean EsCincoDigitos;

        Int32 NumeroIslas;

        Helper oHelper = new Helper();

        public Configuracion()
        {
            try
            {
                InitializeComponent();
            }
            catch
            {
                throw;
            }

        }

	
	#region Event Handlers


        public void CargaDatosControl()
        {
            IniciarForma();
        }

	private void IniciarForma()
	{
		try
		{
			this.Cursor = Cursors.WaitCursor;
            			
			RecuperarIslas();
			RecuperarSurtidores();
            RecuperarManguerasFullStation();
            RecuperarCaras();
            //RecuperarCarasSurtidoresFullStation();

			this.Cursor = Cursors.Default;

		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
    }

    #endregion

    //private void RecuperarProductos()
    //{
    //    try
    //    {
    //        DataSet data = new DataSet();
    //        data.Load(oHelper.RecuperarProductos(), LoadOption.Upsert, "Productos");
    //        this.cmbProducto.DisplayMember = "Nombre";
    //        this.cmbProducto.ValueMember = "IdProducto";
    //        this.cmbProducto.DataSource = data.Tables[0];

    //        if (cmbProducto.SelectedIndex != -1)
    //        {
    //            this.RecuperarHistoricoPrecio(Int32.Parse(cmbProducto.SelectedValue.ToString()));
    //        }

    //        EsComboProductosContruido = true;
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //}

    //private void RecuperarHistoricoPrecio(Int32 idProducto)
    //{
    //    try
    //    {
    //        DataSet data = new DataSet();
    //        data.Load(oHelper.RecuperarHistoricoPrecio(idProducto), LoadOption.Upsert, "HistoricoPrecio");
    //        this.grdHistoricoPrecio.DataSource = data.Tables[0];
    //        EsGridHistoricoPrecioContruido = true;
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //}

    //private void RecuperarHorarios()
    //{
    //    try
    //    {
    //        //this.grdHorarios.DataSource = null;
    //        this.grdHorarios.DataSource = oHelper.RecuperarTurnosHorario().Tables[0];
    //        EsGridHorarioContruido = true;
    //    }
    //    catch 
    //    {
    //        throw;
    //    }
    //}
    //private void RecuperarProtocolos()
    //{
    //    try
    //    {
    //        //this.grdProtocolos.DataSource = null;
    //        this.grdProtocolos.DataSource = oHelper.RecuperarProtocolos().Tables[0];
    //        EsGridProtocoloContruido = true;
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //}
    //private void RecuperarEstaciones()
    //{
    //    DataGridViewComboBoxColumn ComboC = (DataGridViewComboBoxColumn)this.grdEstaciones.Columns["IdCiudadGrillaEstacion"];
    //    ComboC.DisplayMember = "Nombre";
    //    ComboC.ValueMember = "IdCiudad";
    //    ComboC.DataSource = oHelper.RecuperarMunicipios().Tables[0];

    //    this.grdEstaciones.DataSource = oHelper.RecuperarEstaciones().Tables[0];

    //    EsGridEstacionContruido = true;
    //}
    //private void RecuperarImpresoras()
    //{
    //    string ImpresorasInstaladas;
    //    for (Int32 I = 0; I <= PrinterSettings.InstalledPrinters.Count - 1; I++)
    //    {
    //        ImpresorasInstaladas = PrinterSettings.InstalledPrinters[I];
    //        NombreGrillaImpresora.Items.Add(ImpresorasInstaladas);
    //    }

    //    this.grdImpresoras.DataSource = oHelper.RecuperarImpresoras().Tables[0];

    //    EsGridImpresoraContruido = true;
    //}
    //private void RecuperarPuertos()
    //{
    //    try
    //    {
    //        foreach (string strPuertos in SerialPort.GetPortNames())
    //        {
    //            PuertoGrillaPuerto.Items.Add(strPuertos);
    //        }
    //        this.grdPuertos.DataSource = oHelper.RecuperarPuertos().Tables[0];

    //        EsGridPuertoContruido = true;
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //}
    //private void RecuperarDatosBasicos(Helper oHelper)
    //{
    //    try
    //    {
    //        InformacionEstacion oEstacion = oHelper.RecuperarDatosEstacion();

    //        this.datosGenerales1.Codigo = oEstacion.Codigo;
    //        this.datosGenerales1.Nombre = oEstacion.Nombre;
    //        this.datosGenerales1.Nit = oEstacion.Nit;
    //        this.datosGenerales1.Direccion = oEstacion.Direccion;
    //        this.datosGenerales1.Telefono = oEstacion.Telefono;
    //        this.datosGenerales1.Ciudad = oEstacion.Ciudad;
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //}

	private void RecuperarIslas()
	{
		try
		{
			this.cmbIslas.Text = oHelper.RecuperarCantidadIslas().ToString();
			if (String.IsNullOrEmpty(this.cmbIslas.Text))
			{
				this.cmbIslas.Text = "0";
                this.cmbSurtidores.Text = "0";
			}
			NumeroIslas = Int32.Parse(this.cmbIslas.Text);
			DataGridViewComboBoxColumn Combo = (DataGridViewComboBoxColumn)this.grdIslas.Columns["Impresora"];
			Combo.DisplayMember = "Descripcion";
			Combo.ValueMember = "IdImpresora";
			Combo.DataSource = oHelper.RecuperarImpresoras().Tables[0];
			this.grdIslas.DataSource = oHelper.RecuperarIslas().Tables[0];

			EsGridContruido = true;

		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void RecuperarSurtidores()
	{
		try
		{
            DataTable dtIslas = new DataTable();
			//this.txtSurtidores.Text = oHelper.RecuperarCantidadSurtidores().ToString();
            this.cmbSurtidores.Text = oHelper.RecuperarCantidadSurtidores().ToString();

			DataGridViewComboBoxColumn Combo = (DataGridViewComboBoxColumn)this.grdSurtidores.Columns["Protocolo"];
			Combo.DisplayMember = "Nombre";
			Combo.ValueMember = "IdProtocolo";
			Combo.DataSource = oHelper.RecuperarProtocolos().Tables[0];

            dtIslas = oHelper.RecuperarIslas().Tables[0];
            if (dtIslas.Rows.Count > 0)
            {
                DataGridViewComboBoxColumn ComboIsla = (DataGridViewComboBoxColumn)this.grdSurtidores.Columns["IdIsla_"];
                ComboIsla.DisplayMember = "Descripcion";
                ComboIsla.ValueMember = "IdIsla";
                ComboIsla.DataSource = dtIslas;
            }

            DataGridViewComboBoxColumn ComboRed = (DataGridViewComboBoxColumn)this.grdSurtidores.Columns["IdRed"];
            ComboRed.DisplayMember = "idRed";
            ComboRed.ValueMember = "idRed";
            ComboRed.DataSource = oHelper.RecuperarRedSurtidores().Tables[0];
            
            this.grdSurtidores.DataSource = oHelper.RecuperarSurtidores().Tables[0];
            

			EsGridSurtidorContruido = true;

			//RecuperarCaras();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}
            
	private void RecuperarCaras()
	{
		try
		{
            //DataTable dtSurtidor = new DataTable();
            //DataGridViewComboBoxColumn Combo = (DataGridViewComboBoxColumn)this.grdCara.Columns["Lector"];
            //Combo.DisplayMember = "ROM";
            //Combo.ValueMember = "IdLector";
            //Combo.DataSource = oHelper.RecuperarLectores().Tables[0];

            //dtSurtidor = oHelper.RecuperarSurtidores().Tables[0];

            RecuperarLectores();

            if (oHelper.RecuperarSurtidores().Tables[0].Rows.Count > 0)
            {
                DataGridViewComboBoxColumn ComboSurtidor = (DataGridViewComboBoxColumn)this.grdCara.Columns["IdSurtidor"];
                ComboSurtidor.DisplayMember = "Descripcion";
                ComboSurtidor.ValueMember = "IdSurtidor";
                ComboSurtidor.DataSource = oHelper.RecuperarSurtidores().Tables[0];//dtSurtidor;
            }



			this.grdCara.DataSource = oHelper.RecuperarCaras().Tables[0];

			EsGridCaraContruido = true;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}


    private void RecuperarLectores()
    {
        try
        {
            DataTable Tabla = oHelper.RecuperarLectores().Tables[0];

            if (Tabla.Rows.Count > 0)
            {
                DataGridViewComboBoxColumn ComboLector = (DataGridViewComboBoxColumn) this.grdCara.Columns["IdLector"];
                ComboLector.DisplayMember = "ROM";
                ComboLector.ValueMember = "IdLector";
                ComboLector.DataSource = Tabla;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }


    private void RecuperarManguerasFullStation()
    {
        try
        {
            DataTable dtCaras = new DataTable();

            dtCaras = oHelper.RecuperarCaras().Tables[0];
            if (dtCaras.Rows.Count > 0)
            {
                DataGridViewComboBoxColumn ComboCara = (DataGridViewComboBoxColumn)this.grdMangueras.Columns["IdCara_"];
                ComboCara.DisplayMember = "Descripcion";
                ComboCara.ValueMember = "IdCara";
                ComboCara.DataSource = dtCaras;
            }

            //Hacemos lo necesario para llenar el Combo de tanques
            DataTable dtTanque = new DataTable();

            dtTanque = oHelper.RecuperarTanque();
            //Evaluamos si existen tanques, si es así cargamos los datos en el combo
            if (dtTanque.Rows.Count > 0)
            {
                DataGridViewComboBoxColumn ComboTanque = (DataGridViewComboBoxColumn)this.grdMangueras.Columns["IdTanque"];
                ComboTanque.DisplayMember = "Nombre";
                ComboTanque.ValueMember = "IdTanque";
                ComboTanque.DataSource = dtTanque;
            }

            DataGridViewComboBoxColumn ComboProducto = (DataGridViewComboBoxColumn)this.grdMangueras.Columns["IdProducto"];
            DataSet data = new DataSet();
            data.Load(oHelper.RecuperarProductos(), LoadOption.Upsert, "Productos");

            ComboProducto.DisplayMember = "Nombre";
            ComboProducto.ValueMember = "IdProducto";
            ComboProducto.DataSource = data.Tables[0];

            DataSet dataManguera = new DataSet();
            dataManguera.Load(oHelper.RecuperarMangueras(), LoadOption.Upsert, "Mangueras");
            this.grdMangueras.DataSource = dataManguera.Tables[0];
            this.txtMangueras.Text = oHelper.RecuperarCantidadMangueras().ToString();
            //this.cmbMangueras.Text = oHelper.RecuperarCantidadMangueras().ToString();

            foreach (DataGridViewRow row in grdMangueras.Rows)
            {
                if (!String.IsNullOrEmpty(row.Cells["IdTanque"].Value.ToString()))
                {
                    row.Cells["IdProducto"].ReadOnly = true;
                }
            }

            EsGridCaraContruido = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void RecuperarCarasSurtidoresFullStation()
    {
        try
        {
        DataTable dtSurtidor;
        dtSurtidor = oHelper.RecuperarSurtidores().Tables[0];
        if (dtSurtidor.Rows.Count > 0)
        {
            DataGridViewComboBoxColumn ComboSurtidor = (DataGridViewComboBoxColumn)this.grdCaraSurtidor.Columns["Surtidor"];
            ComboSurtidor.DisplayMember = "Descripcion";
            ComboSurtidor.ValueMember = "IdSurtidor";
            ComboSurtidor.DataSource = dtSurtidor;
        }

        this.grdCaraSurtidor.DataSource = oHelper.RecuperarCarasSurtidoresFullStation().Tables[0] ;
        
            EsGridCaraContruido = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

    }

	private static string ToInteger(string Valor)
	{
		return Valor.Substring(0, PosicionSeparadordecimal(Valor));
	}

	private static Int32 PosicionSeparadordecimal(string Valor)
	{
		int Pos = Valor.IndexOf('.');
		if (Pos == -1)
		{
			Pos = Valor.IndexOf(',');
		}

		if (Pos == -1)
		{
			Pos = Valor.Length;
		}
		return Pos;
	}
    
	private void grdIslas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (EsGridContruido)
			{

				NumeroIslas = Int32.Parse(this.cmbIslas.Text);

				oHelper.ActualizarIsla(Int16.Parse(grdIslas.Rows[e.RowIndex].Cells[0].Value.ToString()), Int32.Parse(grdIslas.Rows[e.RowIndex].Cells[2].Value.ToString()), Int32.Parse(grdIslas.Rows[e.RowIndex].Cells[3].Value.ToString()));

				RecuperarSurtidores();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void grdSurtidores_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (EsGridSurtidorContruido)
			{
                oHelper.ActualizarSurtidor(Convert.ToInt16(grdSurtidores.Rows[e.RowIndex].Cells["IdSurtidorX"].Value),
                                           Convert.ToInt32(grdSurtidores.Rows[e.RowIndex].Cells["IdProtocolo"].Value),
                                           Convert.ToInt32(grdSurtidores.Rows[e.RowIndex].Cells["IdIsla_"].Value), 
                                           Convert.ToDecimal(grdSurtidores.Rows[e.RowIndex].Cells["ValorTope"].Value),
                                           Convert.ToInt32(grdSurtidores.Rows[e.RowIndex].Cells["IdRed"].Value), 
                                          false,
                                           grdSurtidores.Rows[e.RowIndex].Cells["CodigoPCC"].Value.ToString()
                                           );

				RecuperarSurtidores();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void grdCara_CellValueChanged( object sender, DataGridViewCellEventArgs e)
	{
        bool sw = false;

		try
		{
			if (EsGridCaraContruido)
			{

                short idCara = Convert.ToInt16(grdCara.Rows[e.RowIndex].Cells["IdCara"].Value.ToString());

                string idLector = grdCara.Rows[e.RowIndex].Cells["IdLector"].Value.ToString();
                int lector = string.IsNullOrEmpty(idLector) ? 0 : Convert.ToInt32(idLector);

                if (lector > 0) oHelper.ValidarLectorCara(idCara);

                sw = true;
				NumeroIslas = Int32.Parse(this.cmbIslas.Text);

                if (string.IsNullOrEmpty(grdCara.Rows[e.RowIndex].Cells["ManejaCincoDigitos"].Value.ToString()))
                    EsCincoDigitos = false;
                else
                    EsCincoDigitos = Boolean.Parse(grdCara.Rows[e.RowIndex].Cells["ManejaCincoDigitos"].Value.ToString());

                oHelper.ActualizarCara(idCara, lector, Boolean.Parse(grdCara.Rows[e.RowIndex].Cells["Estado"].Value.ToString()), Int32.Parse(grdCara.Rows[e.RowIndex].Cells["idSurtidor"].Value.ToString()), +
                        Int32.Parse(grdCara.Rows[e.RowIndex].Cells["CaraAsignada"].Value.ToString()), EsCincoDigitos, Boolean.Parse(grdCara.Rows[e.RowIndex].Cells["PrecioCliente"].Value.ToString()));

				RecuperarSurtidores();
			}
		}
		catch (Exception ex)
		{
            if(!sw) grdCara.Rows[e.RowIndex].Cells["IdLector"].Value = DBNull.Value;
            MessageBox.Show(ex.Message);
		}
	}

    private void grdMangueras_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            if (EsGridCaraContruido)
            {
                Nullable<Int32> IdTanqueValue = null;
                if (!String.IsNullOrEmpty(grdMangueras.Rows[e.RowIndex].Cells["IdTanque"].Value.ToString()))
                {
                    IdTanqueValue = Int32.Parse(grdMangueras.Rows[e.RowIndex].Cells["IdTanque"].Value.ToString());
                }

                oHelper.ActualizarMangueraFullStation(Int32.Parse(grdMangueras.Rows[e.RowIndex].Cells["IdManguera"].Value.ToString()), Int32.Parse(grdMangueras.Rows[e.RowIndex].Cells["IdCara_"].Value.ToString()), Int16.Parse(grdMangueras.Rows[e.RowIndex].Cells["IdProducto"].Value.ToString()), Int32.Parse(grdMangueras.Rows[e.RowIndex].Cells["Grado"].Value.ToString()), IdTanqueValue, Boolean.Parse(grdMangueras.Rows[e.RowIndex].Cells["EsActiva"].Value.ToString()));

                RecuperarManguerasFullStation();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void grdCara_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
        MessageBox.Show(e.Exception.Message);
	}

    private void grdMangueras_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
        MessageBox.Show("Configuracion (" + e.RowIndex.ToString() + ")");
    }

	private void grdIslas_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		MessageBox.Show("Islas (" + e.RowIndex.ToString() + ")");
	}

    private void grdSurtidores_DataError(object sender, DataGridViewDataErrorEventArgs e)
	{
		MessageBox.Show("Surtidores (" + e.RowIndex.ToString() + ")");
	}

    private void grdCaraSurtidor_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
        //MessageBox.Show("Surtidores (" + e.RowIndex.ToString() + ")");
        
    }

    private void grdCaraSurtidor_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            if (EsGridCaraContruido)
            {
                oHelper.ActualizarCarasSurtidorFullStation(Int16.Parse(grdCaraSurtidor.Rows[e.RowIndex].Cells["IdCaraSurtidor"].Value.ToString()), Int16.Parse(grdCaraSurtidor.Rows[e.RowIndex].Cells["Surtidor"].Value.ToString()));
                RecuperarCarasSurtidoresFullStation();
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void grdCaraSurtidor_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
    {
        try
        {
            if (MessageBox.Show("¿Desea eliminar el registro # " + (e.Row.Index + 1) + " de la Configuracion de Caras ?", "Gas Station Config Desktop®",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                 MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                oHelper.EliminarCaraSurtidorFullStation(Int16.Parse(grdCaraSurtidor.Rows[e.Row.Index].Cells["IdCaraSurtidor"].Value.ToString()));
            }
            else
            {
                e.Cancel = true;
            }
        }
        catch (Exception ex)
        {
            e.Cancel = true;
            MessageBox.Show(ex.Message);
        }
    }

    private void grdCaraSurtidor_UserDeleteRow(object sender, DataGridViewRowCancelEventArgs e)
    {
        try
        {
            RecuperarCarasSurtidoresFullStation();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        
    }

    private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Boolean Modificar = true;

                if (NumeroIslas > Int32.Parse(cmbIslas.Text))
                {

                    DialogResult Rta = MessageBox.Show("Esta opción eliminará las Islas sobrantes, y por consiguiente sus respectivos surtidores, ¿Desea Continuar?", "Gas Station Config Desktop®", MessageBoxButtons.YesNo);

                    if (Rta == DialogResult.No)
                    {
                        cmbIslas.Text = NumeroIslas.ToString();
                        Modificar = false;
                    }
                }

                if ((Modificar) & Int32.Parse(this.cmbIslas.Text.ToString()) <= Int32.Parse( this.cmbSurtidores.Text.ToString()) && Int32.Parse(this.txtMangueras.Text.ToString()) >= Int32.Parse(this.cmbSurtidores.Text.ToString()))
                {
                    if (Int16.Parse(this.cmbIslas.Text.ToString()) == 0)
                    {
                        oHelper.InsertarIsla(Int32.Parse(this.cmbIslas.Text));
                    }
                    else
                    {
                        oHelper.InsertarIsla(Int32.Parse(this.cmbIslas.Text));
                        oHelper.InsertarSurtidorFullStation(Int32.Parse(this.cmbSurtidores.Text.ToString()));
                        oHelper.InsertarManguerasFullStation(Int32.Parse(this.txtMangueras.Text.ToString()));
                    }
                    IniciarForma();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

    private void grdSurtidores_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void grdSurtidores_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            if (e.RowIndex >= 0)
            {
                Decimales oDecimal = new Decimales();
                oDecimal.Surtidor = Int32.Parse(grdSurtidores.Rows[e.RowIndex].Cells["IdSurtidorX"].Value.ToString());
                oDecimal.StartPosition = FormStartPosition.CenterScreen;
                oDecimal.ShowDialog();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Creditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

            
    }   
}
