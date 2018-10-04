using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using POSstation.AccesoDatos;
using System.IO;


namespace ConsultasLog {
	public partial class FormPrincipal : Form {
		public FormPrincipal() {
			InitializeComponent();
			ColumnasFiltros = new Dictionary<string, DataTable>();
		}
		Dictionary<string, DataTable> ColumnasFiltros;
		private void FormPrincipal_Load(object sender, EventArgs e) {
			// TODO: esta línea de código carga datos en la tabla 'loggingDataSet.AutorizacionFallidasVenta' Puede moverla o quitarla según sea necesario.

            try{
                Boolean enEjecucion;

                enEjecucion = System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1;

                if (enEjecucion)
                {
                    this.Close();
                }
                else {

                    try
                    {
                        Dictionary<String, String> resultado = new Dictionary<String, String>();


                        NameValueCollection coleccion;
                        coleccion = ConfigurationManager.GetSection("Procesos") as NameValueCollection;

                        foreach (var Clave in coleccion.AllKeys)
                        {
                            resultado.Add(Clave, coleccion.GetValues(Clave).FirstOrDefault());
                            ColumnasFiltros.Add(Clave, new Helper().RecuperarColumnas(Clave).Tables[0]);
                        }


                        ddlProceso.DataSource = new BindingSource(resultado, null);
                        ddlProceso.DisplayMember = "Value";
                        ddlProceso.ValueMember = "Key";


                        ToolTip toolTip1 = new ToolTip();
                        toolTip1.ToolTipIcon = ToolTipIcon.Info;
                        toolTip1.ToolTipTitle = "Adicionar Filtro";
                        toolTip1.SetToolTip(buttonAdicionarFiltro, "Utilice esta opción para adicionar\nun nuevo filtro para la información mostrada.");


                        EnlazarGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                
                
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



		}

		private void EnlazarGrid() {

			GridDatos.Columns.Clear();

			char[] sep = new char[1] { '/' };
			string[] arreglo_fecha;
			string[] arreglo_hora;

			arreglo_fecha = fechaInicial.Text.Split(sep);
			sep[0]=':';
			arreglo_hora = horaInicial.Text.Split(sep);

			int y=int.Parse(arreglo_fecha[2]);
			int m=int.Parse(arreglo_fecha[1]);
			int d=int.Parse(arreglo_fecha[0]);
			int h=int.Parse(arreglo_hora[0]);
			int min=int.Parse(arreglo_hora[1]);
			
			DateTime Fini= new DateTime(y, m, d, h, min, 0);


			sep[0] = '/';
			arreglo_fecha = fechaFinal.Text.Split(sep);
			sep[0] = ':';
			arreglo_hora = horaFinal.Text.Split(sep);

			y = int.Parse(arreglo_fecha[2]);
			m = int.Parse(arreglo_fecha[1]);
			d = int.Parse(arreglo_fecha[0]);
			h = int.Parse(arreglo_hora[0]);
			min = int.Parse(arreglo_hora[1]);

			DateTime Ffin = new DateTime(y, m, d, h, min, 59);


			DataTable datos = new Helper().RecuperarLogeo(ddlProceso.SelectedValue.ToString(), Fini, Ffin, ExtraerCadenaFiltro()).Tables[0];


			DataGridViewTextBoxColumn Columna;
			foreach (DataColumn col in datos.Columns) {
				Columna = new DataGridViewTextBoxColumn();
				Columna.DataPropertyName = col.ColumnName;
				Columna.HeaderText = col.ColumnName;
				Columna.ReadOnly = true;
				GridDatos.Columns.Add(Columna);
			}

			GridDatos.DataSource = datos;

			//GridDatos.Columns.
		}

		private void buttonAdicionarFiltro_Click(object sender, EventArgs e) {
			try {
				Filtro f = new Filtro(ColumnasFiltros[ddlProceso.SelectedValue.ToString()]);
				f.OnEliminarFiltro += f_OnEliminarFiltro;
				panelFiltros2.Controls.Add(f);
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}


		}

		void f_OnEliminarFiltro(Filtro sender) {
			try {
				panelFiltros2.Controls.Remove(sender);
				sender.Dispose();
			} catch (Exception ex) {
				MessageBox.Show("Error eliminado el filtro - " + ex.Message);
			}
		}

		private void ddlProceso_SelectedIndexChanged(object sender, EventArgs e) {
			try {
				panelFiltros2.Controls.Clear();
				for (int i = 0; i < panelFiltros2.Controls.Count; i++) {
					Filtro f = panelFiltros2.Controls[i] as Filtro;
					f.Dispose();
				}
				panelFiltros2.Controls.Clear();
			} catch (Exception ex) {
				MessageBox.Show("Error borrando los filtros - " + ex.Message);
			}
		}

		private void buttonBuscar_Click(object sender, EventArgs e) {
			try {
				EnlazarGrid();
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		private string ExtraerCadenaFiltro() {
			StringBuilder resultado = new StringBuilder("");
			for (int i = 0; i < panelFiltros2.Controls.Count; i++) {
				Filtro f = panelFiltros2.Controls[i] as Filtro;
				if (f.EsNumeirco == 0) {
					if (f.Operador.Contains("LIKE")) {		 
						switch (f.Operador[4].ToString()) {
							case "^":
								resultado.Append(string.Format(" AND LOWER({0}) LIKE '{1}%'", f.FiltrarPor, f.Valor));
								break;
							case "$":
								resultado.Append(string.Format(" AND LOWER({0}) LIKE '%{1}'", f.FiltrarPor, f.Valor));
								break;
							case "=":
								resultado.Append(string.Format(" AND LOWER({0}) LIKE '%{1}%'", f.FiltrarPor, f.Valor));
								break;
							case "!":
								resultado.Append(string.Format(" AND LOWER({0}) NOT LIKE '%{1}%'", f.FiltrarPor, f.Valor));
								break;
						}
					} else {
						switch (f.Operador) {
							case "_":
								resultado.Append(string.Format(" AND LEN({0})<1", f.FiltrarPor));
								break;
							case "!":
								resultado.Append(string.Format(" AND LEN({0})>0", f.FiltrarPor));
								break;
							case "NULL":
								resultado.Append(string.Format(" AND {0} IS NULL", f.FiltrarPor));
								break;
							case "!NULL":
								resultado.Append(string.Format(" AND {0} IS NOT NULL", f.FiltrarPor));
								break;
							default:
								resultado.Append(string.Format(" AND LOWER({0}) {1} '{2}'", f.FiltrarPor, f.Operador, f.Valor.ToLower()));
								break;
						}
					}

				} else {
					switch (f.Operador) {
						case "NULL":
							resultado.Append(string.Format(" AND {0} IS NULL", f.FiltrarPor));
							break;
						case "!NULL":
							resultado.Append(string.Format(" AND {0} IS NOT NULL", f.FiltrarPor));
							break;
						default:
							resultado.Append(string.Format(" AND {0} {1} {2}", f.FiltrarPor, f.Operador, f.Valor));
							break;
					}
				}	   
			}

			return resultado.ToString();
		}

	}
}
