using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using Controles;

namespace gsRestricciones
{
    public partial class gsRestricciones : UserControl
    {

        #region "   Declaracion de Variables    "
            Helper oHelper = new Helper();
            string oTexto;
            Int64 NoRestriccion;
            Int64 Vehiculo;
            DataTable oTableHora = new DataTable();
            DataTable oTableHoraDia = new DataTable();
            DataTable oTableDia = new DataTable();
            DataTable oTableProducto = new DataTable();
            DataTable oTableBasica = new DataTable();
            Boolean Guardado = false;
        #endregion

        #region "   Definicion de Propiedades   "

            public string mPlaca
            {
                set 
                {
                    oTexto = value;
                }
            }

        #endregion


        public gsRestricciones()
        {
            InitializeComponent();
        }

        public void IniciarForma()
        {
            try
            {
                DataGridViewComboBoxColumn Combo = (DataGridViewComboBoxColumn)this.dtgProducto.Columns["IdProducto"];
                Combo.DisplayMember = "Nombre";
                Combo.ValueMember = "IdProducto";
                Combo.DataSource = oHelper.RecuperarProductosDataset().Tables[0];

                DataGridViewComboBoxColumn ComboDia = (DataGridViewComboBoxColumn)this.dtgDia.Columns["IdDia"];
                ComboDia.DisplayMember = "Nombre";
                ComboDia.ValueMember = "IdDia";
                ComboDia.DataSource = oHelper.RecuperarDiasSemana();

                DataGridViewComboBoxColumn ComboHoraDia = (DataGridViewComboBoxColumn)this.dtgHoraDia.Columns["dhIdDia"];
                ComboHoraDia.DisplayMember = "Nombre";
                ComboHoraDia.ValueMember = "IdDia";
                ComboHoraDia.DataSource = oHelper.RecuperarDiasSemana();

                dtgHoraDia.DataSource = oTableHoraDia;
                dtgDia.DataSource = oTableDia;
                dtgHoras.DataSource = oTableHora;
                dtgBasica.DataSource = oTableBasica;
                dtgProducto.DataSource = oTableProducto;
                lblCliente.Text = "";
                lblPlaca.Text = "";
                Vehiculo = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Restricciones - IniciarForma", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dtgDia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mnuGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tabRestricciones.SelectedIndex)
                {
                    case 0:
                        // Restriccion Básica
                        TabBasica(true);
                        TabBasica(false);
                        break;
                    case 1:
                        // Restriccion Día
                        TabDia(true);
                        TabDia(false);
                        break;
                    case 2:
                        // Restriccion Hora
                        TabHora(true);
                        TabHora(false);
                        break;
                    case 3:
                        // Restriccion Producto
                        TabProducto(true);
                        TabProducto(false);
                        break;
                    case 4:
                        // Restriccion Día Hora
                        TabHoraDia(true);
                        TabHoraDia(false);
                        break;
                }
                NoRestriccion = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TabBasica(Boolean oGuardar)
        {
            bool GuardoDatos = false;
            try
            {
                if (oGuardar)
                {
                    foreach (DataGridViewRow oRow in dtgBasica.Rows)
                    {
                        if (oRow.Index < dtgBasica.RowCount - 1)
                        {
                            if (oRow.Cells["Tanqueos"].Value != null)
                                try
                                {
                                    Decimal oDecimalVal;

                                    oDecimalVal = 0;
                                    if (oRow.Cells["Galones"].Value != null)
                                    {
                                        if (!string.IsNullOrEmpty(oRow.Cells["Galones"].Value.ToString()))
                                        {
                                            Decimal.TryParse(oRow.Cells["Galones"].Value.ToString(), out oDecimalVal);


                                            if (oDecimalVal < 0)
                                                throw new Exception("Debe Ingresar un valor mayor igual que cero para los galones.");
                                        }
                                        else
                                        {
                                            throw new Exception("Debe Ingresar un valor para los galones.");
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("Debe Ingresar un valor para los galones.");
                                    }


                                    oDecimalVal = 0;
                                    if (oRow.Cells["VolumenSemanal"].Value != null)
                                    {
                                        if (!string.IsNullOrEmpty(oRow.Cells["VolumenSemanal"].Value.ToString()))
                                        {
                                            Decimal.TryParse(oRow.Cells["VolumenSemanal"].Value.ToString(), out oDecimalVal);
                                            if (oDecimalVal < 0)
                                                throw new Exception("Debe Ingresar un valor mayor igual que cero para los Consumo Semanal.");
                                        }
                                        else
                                        {
                                            throw new Exception("Debe Ingresar un valor para el consumo semanal.");
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("Debe Ingresar un valor para el consumo semanal.");
                                    }

                                    oDecimalVal = 0;
                                    if (oRow.Cells["VolumenMensual"].Value != null)
                                    {
                                        if (!string.IsNullOrEmpty(oRow.Cells["VolumenMensual"].Value.ToString()))
                                        {
                                            Decimal.TryParse(oRow.Cells["VolumenMensual"].Value.ToString(), out oDecimalVal);
                                            if (oDecimalVal < 0)
                                                throw new Exception("Debe Ingresar un valor mayor igual que cero para los Consumo Mensual.");
                                        }
                                        else
                                        {
                                            throw new Exception("Debe Ingresar un valor para el consumo mensual.");
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("Debe Ingresar un valor para el consumo mensual.");
                                    }

                                    //oDecimalVal = 0;
                                    //Decimal.TryParse(oRow.Cells["VolumenSemanal"].Value.ToString(), out oDecimalVal);


                                    //oDecimalVal = 0;
                                    //Decimal.TryParse(oRow.Cells["VolumenMensual"].Value.ToString(), out oDecimalVal);


                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            NoRestriccion = oHelper.InsertarRestriccion(Vehiculo, Int64.Parse(oRow.Cells["Tanqueos"].Value.ToString()), Decimal.Parse(oRow.Cells["Galones"].Value.ToString()), Decimal.Parse(oRow.Cells["VolumenSemanal"].Value.ToString()), Decimal.Parse(oRow.Cells["VolumenMensual"].Value.ToString()), Boolean.Parse(oRow.Cells["Estado"].Value.ToString()));
                            GuardoDatos = true;
                            Guardado = true;
                        }
                        else
                        {

                            if (GuardoDatos == false && oGuardar == true)
                            {
                                throw new Exception("Hay campos que no han sido completados");    
                            }
                            
                        }
                    }
                    if (Guardado == true)
                    {
                        MessageBox.Show("La restricción se guardo satisfactoriamente. ");
                        Guardado = false;
                    }
                }
                else
                {
                    oTableBasica.Clear();
                    oTableBasica = oHelper.RecuperarRestriccionBasica(lblPlaca.Text);
                    dtgBasica.DataSource = oTableBasica;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Restricciones - Basicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void TabDia(Boolean oGuardar)
        {
           
            try
            {
                if (oGuardar)
                {
                    foreach (DataGridViewRow oRow in dtgDia.Rows)
                    {
                        if (oRow.Cells["IdDia"].Value != null)
                        {
                            if (string.IsNullOrEmpty(oRow.Cells["IdDia"].Value.ToString()) == false)
                            {
                                oHelper.InsertarRestriccionDia(lblPlaca.Text, Int64.Parse(oRow.Cells["IdDia"].Value.ToString()));
                                Guardado = true;
                            }
                        }

                    }
                    if (Guardado == true){
                        MessageBox.Show("La restricción se guardo satisfactoriamente. ");
                        Guardado = false;
                    }
                }
                else
                {   
                    oTableDia.Clear();
                    oTableDia = oHelper.RecuperarRestriccionDia(lblPlaca.Text);
                    dtgDia.DataSource = oTableDia;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Restricciones - Basicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TabHora(Boolean oGuardar)
        {
            try
            {
                if (oGuardar)
                {
                    foreach (DataGridViewRow oRow in dtgHoras.Rows)
                    {
                        if (oRow.Index < dtgHoras.RowCount - 1)
                        {
                            if (oRow.Cells["HoraInicial"].Value != null && oRow.Cells["HoraFinal"].Value != null)
                            {
                                oHelper.InsertarRestriccionHora(lblPlaca.Text, DateTime.Parse(oRow.Cells["HoraInicial"].Value.ToString()).ToString("HH:mm"), DateTime.Parse(oRow.Cells["HoraFinal"].Value.ToString()).ToString("HH:mm"));
                                Guardado = true;
                            }
                        }
                    }
                    if (Guardado == true)
                    {
                        MessageBox.Show("La restricción se guardo satisfactoriamente. ");
                        Guardado = false;
                    }
                }
                else
                {
                    oTableHora.Clear();
                    oTableHora = oHelper.RecuperarRestriccionHora(lblPlaca.Text);
                    dtgHoras.DataSource = oTableHora;
                }
            }
            catch (Exception ex)
            {
                if(!ex.Message.Contains("DateTime"))
                  MessageBox.Show(ex.Message, "Restricciones - Basicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                  MessageBox.Show("Formato Invalido", "Restricciones - Basicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TabProducto(Boolean oGuardar)
        {
            try
            {
                if (oGuardar)
                {
                    foreach (DataGridViewRow oRow in dtgProducto.Rows)
                    {
                        if (oRow.Cells["IdProducto"].Value != null)
                        {
                            if (string.IsNullOrEmpty(oRow.Cells["IdProducto"].Value.ToString()) == false)
                                oHelper.InsertarRestriccionProducto(Vehiculo, Int16.Parse(oRow.Cells["IdProducto"].Value.ToString()));
                            Guardado = true;
                        }
                    }
                    if (Guardado == true)
                    {
                        MessageBox.Show("La restricción se guardo satisfactoriamente. ");
                        Guardado = false;
                    }
                }
                else
                {
                    oTableProducto.Clear();
                    oTableProducto = oHelper.RecuperarRestriccionProducto(lblPlaca.Text);
                    dtgProducto.DataSource = oTableProducto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Restricciones - Basicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        private void TabHoraDia(Boolean oGuardar)
        {
            try
            {
                if (oGuardar)
                {
                    foreach (DataGridViewRow oRow in dtgHoraDia.Rows)
                    {
                        if (oRow.Cells["dhIdDia"].Value != null)
                            if (!(String.IsNullOrEmpty(oRow.Cells["dhIdDia"].Value.ToString())))
                            {
                                oHelper.InsertarRestriccionHoraDia(lblPlaca.Text, Int16.Parse(oRow.Cells["dhIdDia"].Value.ToString()), DateTime.Parse(oRow.Cells["dHoraInicial"].Value.ToString()).ToString("HH:mm"), DateTime.Parse(oRow.Cells["dHoraFinal"].Value.ToString()).ToString("HH:mm"));
                                Guardado = true;
                            }
                    }
                    if (Guardado == true)
                    {
                        MessageBox.Show("La restricción se guardo satisfactoriamente. ");
                        Guardado = false;
                    }
                }
                else
                {
                    oTableHoraDia.Clear();
                    oTableHoraDia = oHelper.RecuperarRestriccionHoraDia(lblPlaca.Text);
                    dtgHoraDia.DataSource = oTableHoraDia;
                }
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("DateTime"))
                    MessageBox.Show(ex.Message, "Restricciones - Basicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("Formato Invalido", "Restricciones - Basicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        //private void TabHoraDia(Boolean oGuardar)
        //{
        //    try
        //    {
        //        if (oGuardar)
        //        {
        //            foreach (DataGridViewRow oRow in dtgHoraDia.Rows)
        //            {
        //                if (oRow.Index < dtgHoraDia.RowCount - 1)
        //                {
        //                    if (oRow.Cells["dhIdDia"].Value != null)
        //                        oHelper.InsertarRestriccionHoraDia(lblPlaca.Text, Int16.Parse(oRow.Cells["dhIdDia"].Value.ToString()), DateTime.Parse(oRow.Cells["dHoraInicial"].Value.ToString()).ToString("HH:mm"), DateTime.Parse(oRow.Cells["dHoraFinal"].Value.ToString()).ToString("HH:mm"));
        //                }
        //            }
        //        }
        //        else
        //        {
        //            oTableHoraDia.Clear();
        //            oTableHoraDia = oHelper.RecuperarRestriccionHoraDia(lblPlaca.Text);
        //            dtgHoraDia.DataSource = oTableHoraDia;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Restricciones - Basicas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //}

        public event EventHandler oClosed;
        private void mnuSalir_Click(object sender, EventArgs e)
        {
            oTableHoraDia.Clear();
            oTableDia.Clear();
            oTableHora.Clear();
            oTableBasica.Clear();
            oTableProducto.Clear();
            this.Visible = false;
            oClosed(sender, e);
        }

        private void mnuBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable oRestriccion = new DataTable();
                Int16 oIndice;
                frmAyuda oAyuda = new frmAyuda();
                string oNuip = Inputbox.Show("Buqueda Placa","Digite la placa que desea consultar.", FormStartPosition.CenterScreen);
                oAyuda.Informacion = oHelper.RecuperarDatosVehiculoRestriccion(oNuip);
                oAyuda.ColumnReturn =0;
                oAyuda.ShowDialog();
                if (string.IsNullOrEmpty(oAyuda.ValorRegistroSeleccionado) == false)
                {
                    Vehiculo = Int64.Parse(oAyuda.RowSelect.Cells[0].Value.ToString());
                    lblPlaca.Text = oAyuda.RowSelect.Cells[1].Value.ToString();
                    lblCliente.Text = oAyuda.RowSelect.Cells[2].Value.ToString();
                    TabBasica(false);
                    TabProducto(false);
                    TabDia(false);
                    oRestriccion = oHelper.RecuperarRestriccionesTipo(lblPlaca.Text);
                    if (oRestriccion.Rows.Count > 0)
                    {
                        oIndice = Int16.Parse(oRestriccion.Rows[0][0].ToString());
                        switch(oIndice)
                         {
                            case 0:                             
                                dtgHoraDia.DataSource = oRestriccion;
                                dtgHoraDia.Columns[0].Visible = false;
                                break;
                            case 2:
                                dtgDia.DataSource = oRestriccion;
                                break;
                            case 1:
                                dtgHoras.DataSource = oRestriccion;
                                break;
                         }
                    }
                }
                oAyuda.Close();
                oAyuda.Dispose();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Restricciones - Buscar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //Inputbox.Show(
        }

        private void dtgHoras_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		if (this.dtgHoras.Columns[e.ColumnIndex].Name == "HoraInicial" || this.dtgHoras.Columns[e.ColumnIndex].Name == "HoraFinal")
		{
			if (e.Value != null)
			{
				ToTime(e);
			}
		}
	}

        private void dtgHoraDia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
        if (this.dtgHoraDia.Columns[e.ColumnIndex].Name == "dHoraInicial" || this.dtgHoraDia.Columns[e.ColumnIndex].Name == "dHoraFinal")
		{
			if (e.Value != null)
			{
				ToTime(e);
			}
		}
	}

	    private static void ToTime(DataGridViewCellFormattingEventArgs formatting)
	{
		if (formatting.Value != null)
		{
			try
			{
				System.Text.StringBuilder dateString = new System.Text.StringBuilder();
				DateTime theTime = DateTime.Parse(formatting.Value.ToString());

				string Temp = "0" + theTime.Hour.ToString();
				dateString.Append(Temp.Substring(Temp.Length - 2, 2));
				dateString.Append(":");
				Temp = "0" + theTime.Minute.ToString();
				dateString.Append(Temp.Substring(Temp.Length - 2, 2));

				formatting.Value = dateString.ToString();
				formatting.FormattingApplied = true;
			}
			catch (FormatException)
			{
				formatting.FormattingApplied = false;
			}
		}
	}

        private void dtgBasica_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                // Elimina Restriccion
                oHelper.EliminarRestriccionBasica(Int64.Parse(dtgBasica.Rows[e.Row.Index].Cells["IdRestriccion"].Value.ToString()));
                oTableHoraDia.Clear();
                oTableDia.Clear();
                oTableHora.Clear();
                //oTableBasica.Clear();
                oTableProducto.Clear();
                dtgHoraDia.DataSource = oTableHoraDia;
                dtgDia.DataSource = oTableDia;
                dtgHoras.DataSource = oTableHora;
                //dtgBasica.DataSource = oTableBasica;
                dtgProducto.DataSource = oTableProducto;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgHoras_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                // Elimina Restriccion
                oHelper.EliminarRestriccionHora(Int64.Parse(dtgHoras.Rows[e.Row.Index].Cells["IdRestriccionHora"].Value.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgDia_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                // Elimina Restriccion
                oHelper.EliminarRestriccionDia(Int64.Parse(dtgDia.Rows[e.Row.Index].Cells["IdRestriccionDia"].Value.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgProducto_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                // Elimina Restriccion
                oHelper.EliminarRestriccionProducto(Int64.Parse(dtgProducto.Rows[e.Row.Index].Cells["IdProducto"].Value.ToString()), Vehiculo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgHoraDia_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                // Elimina Restriccion
                oHelper.EliminarRestriccionHoraDia(Int64.Parse(dtgHoraDia.Rows[e.Row.Index].Cells["ResDia"].Value.ToString()), Int64.Parse(dtgHoraDia.Rows[e.Row.Index].Cells["ResHora"].Value.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgBasica_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (this.dtgBasica.Columns[e.ColumnIndex].Name == "VolumenSemanal" || this.dtgBasica.Columns[e.ColumnIndex].Name == "VolumenMensual" || this.dtgBasica.Columns[e.ColumnIndex].Name == "Galones")
            //{
            //    if (e.Value != null)
            //    {
            //        try
            //        {
            //            Decimal oDecimalVal;
            //            Decimal.TryParse(e.Value.ToString(), out oDecimalVal);
            //            if (oDecimalVal > 0)
            //                throw new Exception("Debe Ingresar un valor mayor que cero.");
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Debe ingresar un valor valido para esta casilla.");
            //    }
            //}
        }

        private void dtgBasica_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dtgDia_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dtgHoras_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dtgHoraDia_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dtgBasica_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (dtgBasica.IsCurrentCellInEditMode)
                {
                    if (dtgBasica.Columns[e.ColumnIndex].Name == "Tanqueos")
                    {
                        if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            MessageBox.Show("El nro de tanqueos no puede ser vacío");
                            e.Cancel = true;
                        }
                        else
                        {
                            Int32 Tanqueos;
                            if (!Int32.TryParse(e.FormattedValue.ToString(), out Tanqueos))
                            {
                                MessageBox.Show("El nro de tanqueos no tiene el formato correcto");
                                e.Cancel = true;
                            }
                        }
                    }

                    if (dtgBasica.Columns[e.ColumnIndex].Name == "Galones")
                    {
                        if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            MessageBox.Show("El volumen diario no puede ser vacío");
                            e.Cancel = true;
                        }
                        else
                        {
                            Decimal VolDiario;
                            if (!Decimal.TryParse(e.FormattedValue.ToString(), out VolDiario))
                            {
                                MessageBox.Show("El volumen diario no tiene el formato correcto");
                                e.Cancel = true;
                            }
                        }
                    }

                    if (dtgBasica.Columns[e.ColumnIndex].Name == "VolumenSemanal")
                    {
                        if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            MessageBox.Show("El volumen semanal no puede ser vacío");
                            e.Cancel = true;
                        }
                        else
                        {
                            Decimal VolSemanal;
                            if (!Decimal.TryParse(e.FormattedValue.ToString(), out VolSemanal))
                            {
                                MessageBox.Show("El volumen semanal no tiene el formato correcto");
                                e.Cancel = true;
                            }
                        }
                    }

                    if (dtgBasica.Columns[e.ColumnIndex].Name == "VolumenMensual")
                    {
                        if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            MessageBox.Show("El volumen mensual no puede ser vacío");
                            e.Cancel = true;
                        }
                        else
                        {
                            Decimal VolMensual;
                            if (!Decimal.TryParse(e.FormattedValue.ToString(), out VolMensual))
                            {
                                MessageBox.Show("El volumen mensual no tiene el formato correcto");
                                e.Cancel = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gsRestricciones_Load(object sender, EventArgs e)
        {

        }

    }
}