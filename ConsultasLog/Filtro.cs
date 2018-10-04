using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POSstation.AccesoDatos;


namespace ConsultasLog {
	public partial class Filtro : UserControl {
		//Variable que contiene el tipo de filtros
		//0 para numeros, 1 para texto
		private Dictionary<int, Dictionary<string, string>> Filtros;

		private Dictionary<string, int> _columnasFiltro;

		private DataTable _tablaColumnas;

		


		public delegate void EliminarFiltro(Filtro sender);

		public event EliminarFiltro OnEliminarFiltro;

		public string FiltrarPor {
			get {
				return this.comboFiltrar.SelectedItem.ToString();
			}
		}

		public string Operador {
			get {
				return this.comboBoxOperador.SelectedValue.ToString();
			}
		}

		public string Valor {
			get {
				return this.textBoxValor.Text;
			}
		}

		public int EsNumeirco {
			get {
				string sel = comboFiltrar.SelectedItem.ToString();
				return _columnasFiltro[sel];
			}
		}

		public Filtro(DataTable ColumnasFiltro) {
			

			InitializeComponent();
			Filtros = new Dictionary<int, Dictionary<string, string>>();

			Dictionary<string, string> Opciones = new Dictionary<string, string>();

			//Opciones para texto
			Opciones.Add("=", "Igual");
			Opciones.Add("<>", "Diferente");
			Opciones.Add("LIKE=", "Que contiene");
			Opciones.Add("LIKE!", "Que no contiene");
			Opciones.Add("LIKE^", "Que empieza por");
			Opciones.Add("LIKE$", "Que termina por");
			Opciones.Add("_", "Cadena vacía");
			Opciones.Add("!", "Cadena no vacía");
			Opciones.Add("NULL", "Valor Nulo");
			Opciones.Add("!NULL", "Valor No Nulo");
			Filtros.Add(0, Opciones);

			//Opciones para numeros
			Opciones = new Dictionary<string, string>();
			Opciones.Add("=", "Igual");
			Opciones.Add("<>", "Diferente");
			Opciones.Add(">", "Mayor");
			Opciones.Add("<", "Menor");
			Opciones.Add(">=", "Mayor o igual");
			Opciones.Add("<=", "Menor o igual");
			Opciones.Add("NULL", "Valor Nulo");
			Opciones.Add("!NULL", "Valor No Nulo");
			Filtros.Add(1, Opciones);


			_columnasFiltro = new Dictionary<string, int>();
			foreach(DataRow dr in ColumnasFiltro.Rows){
				comboFiltrar.Items.Add(dr["Nombre"].ToString());
				_columnasFiltro.Add(dr["Nombre"].ToString(), int.Parse(dr["EsNumerico"].ToString()));
			}

		}

		private void Filtro_Load(object sender, EventArgs e) {
			ToolTip toolTip1 = new ToolTip();
			toolTip1.ToolTipIcon = ToolTipIcon.Info;
			toolTip1.ToolTipTitle = "Borrar Filtro";
			toolTip1.SetToolTip(buttonEliminarFiltro, "Utilice esta opción para eliminar este filtro.");

			comboFiltrar.SelectedIndex = 0;
		}

		private void buttonEliminarFiltro_Click(object sender, EventArgs e) {
			OnEliminarFiltro(this);
		}

		private void comboFiltrar_SelectedIndexChanged(object sender, EventArgs e) {
			try {

				string sel=comboFiltrar.SelectedItem.ToString();

				int i=_columnasFiltro[sel];

				Dictionary<string, string> Opciones =Filtros[i]; 


				comboBoxOperador.DataSource = new BindingSource(Opciones, null);
				comboBoxOperador.DisplayMember = "Value";
				comboBoxOperador.ValueMember = "Key";

			} catch (Exception ex) {
				MessageBox.Show("Error consultado los operadores.");
			}
		}
	}
}
