namespace ConsultasLog {
	partial class Filtro {
		/// <summary> 
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de componentes

		/// <summary> 
		/// Método necesario para admitir el Diseñador. No se puede modificar 
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filtro));
			this.comboFiltrar = new System.Windows.Forms.ComboBox();
			this.textBoxValor = new System.Windows.Forms.TextBox();
			this.comboBoxOperador = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonEliminarFiltro = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// comboFiltrar
			// 
			this.comboFiltrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboFiltrar.FormattingEnabled = true;
			this.comboFiltrar.Location = new System.Drawing.Point(64, 1);
			this.comboFiltrar.Name = "comboFiltrar";
			this.comboFiltrar.Size = new System.Drawing.Size(229, 21);
			this.comboFiltrar.TabIndex = 2;
			this.comboFiltrar.SelectedIndexChanged += new System.EventHandler(this.comboFiltrar_SelectedIndexChanged);
			// 
			// textBoxValor
			// 
			this.textBoxValor.Location = new System.Drawing.Point(438, 1);
			this.textBoxValor.Name = "textBoxValor";
			this.textBoxValor.Size = new System.Drawing.Size(229, 20);
			this.textBoxValor.TabIndex = 3;
			// 
			// comboBoxOperador
			// 
			this.comboBoxOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxOperador.FormattingEnabled = true;
			this.comboBoxOperador.Location = new System.Drawing.Point(299, 1);
			this.comboBoxOperador.Name = "comboBoxOperador";
			this.comboBoxOperador.Size = new System.Drawing.Size(133, 21);
			this.comboBoxOperador.TabIndex = 4;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(710, 2);
			this.panel1.TabIndex = 5;
			// 
			// buttonEliminarFiltro
			// 
			this.buttonEliminarFiltro.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.buttonEliminarFiltro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonEliminarFiltro.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
			this.buttonEliminarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonEliminarFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonEliminarFiltro.Image = ((System.Drawing.Image)(resources.GetObject("buttonEliminarFiltro.Image")));
			this.buttonEliminarFiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonEliminarFiltro.Location = new System.Drawing.Point(673, 1);
			this.buttonEliminarFiltro.Name = "buttonEliminarFiltro";
			this.buttonEliminarFiltro.Size = new System.Drawing.Size(30, 21);
			this.buttonEliminarFiltro.TabIndex = 8;
			this.buttonEliminarFiltro.UseVisualStyleBackColor = false;
			this.buttonEliminarFiltro.Click += new System.EventHandler(this.buttonEliminarFiltro_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Filtrar Por:";
			// 
			// Filtro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonEliminarFiltro);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.comboBoxOperador);
			this.Controls.Add(this.textBoxValor);
			this.Controls.Add(this.comboFiltrar);
			this.Name = "Filtro";
			this.Size = new System.Drawing.Size(710, 26);
			this.Load += new System.EventHandler(this.Filtro_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboFiltrar;
		private System.Windows.Forms.TextBox textBoxValor;
		private System.Windows.Forms.ComboBox comboBoxOperador;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonEliminarFiltro;
		private System.Windows.Forms.Label label1;
	}
}
