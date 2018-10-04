namespace PosStation.MenuGerenciamiento
{
    partial class MenuGerenciamiento
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuGerenciamiento));
            this.Popup = new PopupNotifier();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnTarjetas = new System.Windows.Forms.Button();
            this.btnRenovarCupo = new System.Windows.Forms.Button();
            this.btnCredito = new System.Windows.Forms.Button();
            this.btnPrecioCliente = new System.Windows.Forms.Button();
            this.btnKilometraje = new System.Windows.Forms.Button();
            this.btnRestricciones = new System.Windows.Forms.Button();
            this.btnVehiculo = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Popup
            // 
            this.Popup.BodyColor = System.Drawing.Color.SteelBlue;
            this.Popup.CloseButton = false;
            this.Popup.ContentColor = System.Drawing.Color.White;
            this.Popup.ContentFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Popup.ContentText = null;
            this.Popup.HeaderColor = System.Drawing.Color.SteelBlue;
            this.Popup.Image = null;
            this.Popup.ImagePosition = new System.Drawing.Point(12, 21);
            this.Popup.ImageSize = new System.Drawing.Size(32, 32);
            this.Popup.OptionsMenu = null;
            this.Popup.ShowGrip = false;
            this.Popup.Size = new System.Drawing.Size(400, 100);
            this.Popup.TextPadding = new System.Windows.Forms.Padding(0);
            this.Popup.TitleFont = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.Popup.TitleText = null;
            // 
            // btnTarjetas
            // 
            this.btnTarjetas.AutoSize = true;
            this.btnTarjetas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnTarjetas.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Actualizar__2_;
            this.btnTarjetas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTarjetas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTarjetas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTarjetas.Image = global::gasolutions.UInterface.Properties.Resources.MnuTarjeta;
            this.btnTarjetas.Location = new System.Drawing.Point(668, 225);
            this.btnTarjetas.Margin = new System.Windows.Forms.Padding(2);
            this.btnTarjetas.Name = "btnTarjetas";
            this.btnTarjetas.Size = new System.Drawing.Size(164, 114);
            this.btnTarjetas.TabIndex = 22;
            this.btnTarjetas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnTarjetas, "Previsualizar Renovacion de Creditos");
            this.btnTarjetas.UseVisualStyleBackColor = false;
            this.btnTarjetas.Click += new System.EventHandler(this.btnTarjetas_Click);
            // 
            // btnRenovarCupo
            // 
            this.btnRenovarCupo.AutoSize = true;
            this.btnRenovarCupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnRenovarCupo.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Actualizar__2_;
            this.btnRenovarCupo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRenovarCupo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRenovarCupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRenovarCupo.Image = ((System.Drawing.Image)(resources.GetObject("btnRenovarCupo.Image")));
            this.btnRenovarCupo.Location = new System.Drawing.Point(500, 225);
            this.btnRenovarCupo.Margin = new System.Windows.Forms.Padding(2);
            this.btnRenovarCupo.Name = "btnRenovarCupo";
            this.btnRenovarCupo.Size = new System.Drawing.Size(164, 114);
            this.btnRenovarCupo.TabIndex = 21;
            this.btnRenovarCupo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnRenovarCupo, "Previsualizar Renovacion de Creditos");
            this.btnRenovarCupo.UseVisualStyleBackColor = false;
            this.btnRenovarCupo.Click += new System.EventHandler(this.btnRenovarCupo_Click);
            // 
            // btnCredito
            // 
            this.btnCredito.AutoSize = true;
            this.btnCredito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnCredito.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Actualizar__2_;
            this.btnCredito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCredito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCredito.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCredito.Image = ((System.Drawing.Image)(resources.GetObject("btnCredito.Image")));
            this.btnCredito.Location = new System.Drawing.Point(332, 225);
            this.btnCredito.Margin = new System.Windows.Forms.Padding(2);
            this.btnCredito.Name = "btnCredito";
            this.btnCredito.Size = new System.Drawing.Size(164, 114);
            this.btnCredito.TabIndex = 20;
            this.btnCredito.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnCredito, "Previsualizar Creditos a Facturarse");
            this.btnCredito.UseVisualStyleBackColor = false;
            this.btnCredito.Click += new System.EventHandler(this.btnCredito_Click);
            // 
            // btnPrecioCliente
            // 
            this.btnPrecioCliente.AutoSize = true;
            this.btnPrecioCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnPrecioCliente.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Actualizar__2_;
            this.btnPrecioCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPrecioCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrecioCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrecioCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnPrecioCliente.Image")));
            this.btnPrecioCliente.Location = new System.Drawing.Point(164, 225);
            this.btnPrecioCliente.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrecioCliente.Name = "btnPrecioCliente";
            this.btnPrecioCliente.Size = new System.Drawing.Size(164, 114);
            this.btnPrecioCliente.TabIndex = 19;
            this.btnPrecioCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnPrecioCliente, "Previsualizar Creditos a Facturarse");
            this.btnPrecioCliente.UseVisualStyleBackColor = false;
            this.btnPrecioCliente.Click += new System.EventHandler(this.btnPrecioCliente_Click);
            // 
            // btnKilometraje
            // 
            this.btnKilometraje.AutoSize = true;
            this.btnKilometraje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnKilometraje.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKilometraje.BackgroundImage")));
            this.btnKilometraje.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnKilometraje.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKilometraje.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKilometraje.Image = ((System.Drawing.Image)(resources.GetObject("btnKilometraje.Image")));
            this.btnKilometraje.Location = new System.Drawing.Point(668, 100);
            this.btnKilometraje.Margin = new System.Windows.Forms.Padding(2);
            this.btnKilometraje.Name = "btnKilometraje";
            this.btnKilometraje.Size = new System.Drawing.Size(164, 114);
            this.btnKilometraje.TabIndex = 18;
            this.btnKilometraje.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnKilometraje, "Previsualizar Creditos a Facturarse");
            this.btnKilometraje.UseVisualStyleBackColor = false;
            this.btnKilometraje.Click += new System.EventHandler(this.btnKilometraje_Click);
            // 
            // btnRestricciones
            // 
            this.btnRestricciones.AutoSize = true;
            this.btnRestricciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnRestricciones.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Actualizar__2_;
            this.btnRestricciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRestricciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestricciones.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRestricciones.Image = ((System.Drawing.Image)(resources.GetObject("btnRestricciones.Image")));
            this.btnRestricciones.Location = new System.Drawing.Point(500, 100);
            this.btnRestricciones.Margin = new System.Windows.Forms.Padding(2);
            this.btnRestricciones.Name = "btnRestricciones";
            this.btnRestricciones.Size = new System.Drawing.Size(164, 114);
            this.btnRestricciones.TabIndex = 17;
            this.btnRestricciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnRestricciones, "Previsualizar Creditos a Facturarse");
            this.btnRestricciones.UseVisualStyleBackColor = false;
            this.btnRestricciones.Click += new System.EventHandler(this.btnRestricciones_Click);
            // 
            // btnVehiculo
            // 
            this.btnVehiculo.AutoSize = true;
            this.btnVehiculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnVehiculo.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Actualizar__2_;
            this.btnVehiculo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnVehiculo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVehiculo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVehiculo.Image = ((System.Drawing.Image)(resources.GetObject("btnVehiculo.Image")));
            this.btnVehiculo.Location = new System.Drawing.Point(332, 100);
            this.btnVehiculo.Margin = new System.Windows.Forms.Padding(2);
            this.btnVehiculo.Name = "btnVehiculo";
            this.btnVehiculo.Size = new System.Drawing.Size(164, 114);
            this.btnVehiculo.TabIndex = 16;
            this.btnVehiculo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnVehiculo, "Previsualizar Creditos a Facturarse");
            this.btnVehiculo.UseVisualStyleBackColor = false;
            this.btnVehiculo.Click += new System.EventHandler(this.btnVehiculo_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.AutoSize = true;
            this.btnCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnCliente.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Actualizar__2_;
            this.btnCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnCliente.Image")));
            this.btnCliente.Location = new System.Drawing.Point(164, 101);
            this.btnCliente.Margin = new System.Windows.Forms.Padding(2);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(164, 113);
            this.btnCliente.TabIndex = 15;
            this.btnCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnCliente, "Previsualizar Creditos a Facturarse");
            this.btnCliente.UseVisualStyleBackColor = false;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // MenuGerenciamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnTarjetas);
            this.Controls.Add(this.btnRenovarCupo);
            this.Controls.Add(this.btnCredito);
            this.Controls.Add(this.btnPrecioCliente);
            this.Controls.Add(this.btnKilometraje);
            this.Controls.Add(this.btnRestricciones);
            this.Controls.Add(this.btnVehiculo);
            this.Controls.Add(this.btnCliente);
            this.Name = "MenuGerenciamiento";
            this.Size = new System.Drawing.Size(834, 341);
            this.Load += new System.EventHandler(this.MenuGerenciamiento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal PopupNotifier Popup;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnCredito;
        private System.Windows.Forms.Button btnPrecioCliente;
        private System.Windows.Forms.Button btnKilometraje;
        private System.Windows.Forms.Button btnRestricciones;
        private System.Windows.Forms.Button btnVehiculo;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnRenovarCupo;
        private System.Windows.Forms.Button btnTarjetas;
    }
}
